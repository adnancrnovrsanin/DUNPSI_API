using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.ModelsDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.ProjectManagers
{
    public class Details
    {
        public class Query : IRequest<Result<ProjectManagerDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ProjectManagerDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Result<ProjectManagerDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var projectManager = await _context.ProjectManagers
                    .Include(pm => pm.AppUser)
                    .Include(pm => pm.ManagedTeams)
                    .ProjectTo<ProjectManagerDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(pm => pm.Id == request.Id);

                if (projectManager == null) return null;

                return Result<ProjectManagerDto>.Success(projectManager);
            }
        }
    }
}