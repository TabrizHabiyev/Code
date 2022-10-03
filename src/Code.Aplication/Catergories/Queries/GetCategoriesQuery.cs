

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Code.Aplication.Common.Interfaces;
using Code.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Code.Domain.Catergories.Queries
{
    public class CategoryDto : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }

    public record GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>;

    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly IAplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IAplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
           var categories = await _context.Categories.AsNoTracking()
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .OrderBy(x=>x.CategoryName)
                .ToListAsync(cancellationToken);
            return categories;
        }
    }
}
