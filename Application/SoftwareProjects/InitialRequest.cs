using Application.Core;
using Domain;
using Domain.ModelsDTOs;
using MediatR;
using Persistance;

namespace Application.SoftwareProjects
{
    public class InitialRequest
    {
        public class Command : IRequest<Result<Unit>>
        {
            public InitialProjectRequestDto InitialProjectRequest { get; set; }
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
                var initialProjectRequest = new InitialProjectRequest {
                    ProjectName = request.InitialProjectRequest.ProjectName,
                    ProjectDescription = request.InitialProjectRequest.ProjectDescription,
                    DueDate = DateTime.Parse(request.InitialProjectRequest.DueDate),
                    Rejected = false,
                    ClientId = request.InitialProjectRequest.ClientId
                };

                _context.InitialProjectRequests.Add(initialProjectRequest);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create initial project request");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}