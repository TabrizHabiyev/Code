

using Code.Aplication.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Code.Domain.Catergories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(int id) : IRequest;


    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly  IAplicationDbContext _aplicationDbContext;

        public DeleteCategoryCommandHandler(IAplicationDbContext aplicationDbContext)
        {
            _aplicationDbContext = aplicationDbContext;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _aplicationDbContext.Categories.Where(x => x.Id == request.id).SingleOrDefaultAsync();

            if(entity == null)
            {
                throw new Exception("");
            }
            _aplicationDbContext.Categories.Remove(entity);
            await _aplicationDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }

}
