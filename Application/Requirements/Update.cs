using Application.Core;
using Domain.ModelsDTOs;
using MediatR;
using Persistance;

namespace Application.Requirements
{
    public class Update
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
                var requirement = await _context.Requirements.FindAsync(request.Requirement.Id);

                if (requirement == null) return null;

                requirement.Name = request.Requirement.Name ?? requirement.Name;
                requirement.Description = request.Requirement.Description ?? requirement.Description;
                requirement.Status = request.Requirement.Status;

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update requirement");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}