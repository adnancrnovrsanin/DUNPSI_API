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
                    .ThenInclude(x => x.Requirements)
                    .SingleOrDefaultAsync(x => x.Id == request.Requirement.ProjectId);
                var requirementPhase = project.Phases.SingleOrDefault(x => x.Name == "Requirements Analysis");

                if (project == null) return null;

                var requirement = new Requirement
                {
                    Name = request.Requirement.Name,
                    Description = request.Requirement.Description,
                    Status = (request.Requirement.Status == "APPROVED") ? RequirementApproveStatus.APPROVED : RequirementApproveStatus.PENDING,
                    ProjectId = request.Requirement.ProjectId,
                    PhaseId = requirementPhase.Id,
                    Project = project,
                    Phase = requirementPhase,
                    Assignees = new List<RequirementManagement>()
                };

                foreach(var req in requirementPhase.Requirements)
                {
                    req.SerialNumber++;
                }
                _context.Requirements.UpdateRange(requirementPhase.Requirements);
                
                _context.Requirements.Add(requirement);
                requirementPhase.Requirements.Add(requirement);


                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create requirement");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}