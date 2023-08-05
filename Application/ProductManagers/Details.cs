using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.ModelsDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.ProductManagers
{
    public class Details
    {
        public class Query : IRequest<Result<ProductManagerDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ProductManagerDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<ProductManagerDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var productManager = await _context.ProductManagers.Include(pm => pm.AppUser)
                    .ProjectTo<ProductManagerDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(pm => pm.Id == request.Id);

                if (productManager == null) return null;

                return Result<ProductManagerDto>.Success(productManager);
            }
        }
    }
}