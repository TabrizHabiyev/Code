using Code.Aplication.Common.Interfaces;
using Code.Domain.Entity;
using MediatR;

namespace Code.Domain.Catergories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IAplicationDbContext _context;

        public CreateCategoryCommandHandler(IAplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Category
            {
                CategoryName = request.CategoryName,
                Description = request.Description,
            };

            _context.Categories.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }

}
