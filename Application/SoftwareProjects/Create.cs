using Application.Core;
using Domain;
using Domain.ModelsDTOs;
using MediatR;
using Persistance;

namespace Application.SoftwareProjects
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public SoftwareProjectDto SoftwareProject { get; set; }
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
                var client = await _context.SoftwareCompanies.FindAsync(request.SoftwareProject.ClientId);
                var team = await _context.Teams.FindAsync(request.SoftwareProject.AssignedTeamId);

                if (client == null || team == null) return null;

                var newProject = new SoftwareProject
                {
                    ClientId = request.SoftwareProject.ClientId,
                    Name = request.SoftwareProject.Name,
                    Description = request.SoftwareProject.Description,
                    DueDate = DateTime.Parse(request.SoftwareProject.DueDate),
                    AssignedTeamId = request.SoftwareProject.AssignedTeamId,
                    AssignedTeam = team,
                    Client = client
                };

                _context.SoftwareProjects.Add(newProject);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create new project");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}