using Application.Core;
using Domain;
using Domain.ModelsDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Teams
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public TeamDto Team { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var developers = await _context.Developers.Where(d => request.Team.Developers.Any(x => x.Id == d.Id)).ToListAsync();

                if (developers.Count < request.Team.Developers.Count())
                    return Result<Unit>.Failure("Some developers were not found");

                var projectManager = await _context.ProjectManagers.FindAsync(request.Team.ProjectManagerId);
                var project = await _context.SoftwareProjects.FindAsync(request.Team.ProjectId);

                if (projectManager == null || project == null)
                    return Result<Unit>.Failure("Project manager or project were not found");

                var team = new Team
                {
                    ProjectManagerId = request.Team.ProjectManagerId,
                    Project = project,
                    Manager = projectManager,
                    AssignedDevelopers = developers.Select(d => new DeveloperTeamPlacement
                    {
                        Developer = d
                    }).ToList()
                };

                _context.Teams.Add(team);

                foreach (var developer in team.AssignedDevelopers)
                {
                    developer.DevelopmentTeam = team;
                    developer.DevelopmentTeamId = team.Id;
                }


                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create team");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}