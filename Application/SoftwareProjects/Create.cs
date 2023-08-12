using Application.Core;
using Domain;
using MediatR;
using Persistance;

namespace Application.SoftwareProjects
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ProjectCreateDto SoftwareProject { get; set; }
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
                var manager = await _context.ProjectManagers.FindAsync(request.SoftwareProject.AssignedProjectManager);

                if (client == null || manager == null) return null;

                var team = new Team
                {
                    ProjectManagerId = manager.Id,
                    Manager = manager,
                    AssignedDevelopers = new List<DeveloperTeamPlacement>()
                };

                var project = new SoftwareProject
                {
                    ClientId = client.Id,
                    Name = request.SoftwareProject.Name,
                    Description = request.SoftwareProject.Description,
                    DueDate = DateTime.Parse(request.SoftwareProject.DueDate),
                    Finished = false,
                    AssignedTeam = team,
                    Client = client,
                    Phases = new List<ProjectPhase>(),
                    DeveloperRatings = new List<Rating>()
                };

                var projectPhases = new List<ProjectPhase>{
                    new ProjectPhase{
                        Project = project,
                        SerialNumber = 0,
                        Name = "Requirements Analysis",
                        Description = "The first phase of the increment, where the requirements are analyzed and the increment is planned."
                    },
                    new ProjectPhase{
                        Project = project,
                        SerialNumber = 1,
                        Name = "Design",
                        Description = "The second phase of the increment, where the design of the increment is created."
                    },
                    new ProjectPhase{
                        Project = project,
                        SerialNumber = 2,
                        Name = "Implementation",
                        Description = "The third phase of the increment, where the increment is implemented."
                    },
                    new ProjectPhase{
                        Project = project,
                        SerialNumber = 3,
                        Name = "Testing",
                        Description = "The fourth phase of the increment, where the increment is tested."
                    },
                    new ProjectPhase{
                        Project = project,
                        SerialNumber = 4,
                        Name = "Deployment",
                        Description = "The fifth phase of the increment, where the increment is deployed."
                    },
                    new ProjectPhase{
                        Project = project,
                        SerialNumber = 5,
                        Name = "Done",
                        Description = "The final phase of the increment, where the increment is finished."
                    }
                };

                project.Phases = projectPhases;

                team.Project = project;

                _context.Teams.Add(team);
                _context.ProjectPhases.AddRange(projectPhases);
                _context.SoftwareProjects.Add(project);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create project");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}