using Application.Core;
using Domain;
using Domain.ModelsDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Requirements
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public RequirementDto Requirement { get; set; }
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
                var project = await _context.SoftwareProjects
                    .Include(x => x.Phases)
                    .SingleOrDefaultAsync(x => x.Id == request.Requirement.ProjectId);
                var phase = await _context.ProjectPhases.FindAsync(request.Requirement.PhaseId);
                var requirementPhase = project.Phases.SingleOrDefault(x => x.Name == "Requirements Analysis");

                if (project == null || phase == null) return null;

                var requirement = new Requirement
                {
                    Name = request.Requirement.Name,
                    Description = request.Requirement.Description,
                    Status = RequirementApproveStatus.PENDING,
                    ProjectId = request.Requirement.ProjectId,
                    PhaseId = requirementPhase.Id,
                    Project = project,
                    Phase = phase,
                    Assignees = new List<RequirementManagement>()
                };

                _context.Requirements.Add(requirement);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create requirement");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}