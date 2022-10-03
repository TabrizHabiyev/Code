using Code.Aplication.Common.Interfaces;
using MediatR;

namespace Code.Domain.Catergories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand:IRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; } = null!;
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IAplicationDbContext _context;
        public UpdateCategoryCommandHandler(IAplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.FindAsync(new object[] {request.Id},cancellationToken);
            if (entity == null)
            {
                throw new Exception("");
            }

            entity.CategoryName = request.CategoryName;
            entity.Description = request.Description;

           await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }


}
