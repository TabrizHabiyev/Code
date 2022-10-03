using Code.Aplication.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Code.Domain.Catergories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly IAplicationDbContext _context;
        public UpdateCategoryCommandValidator(IAplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.CategoryName)
                .NotEmpty().WithMessage("Category Name is required")
                .MaximumLength(200).WithMessage("Category must not exceed 200 character")
                .MustAsync(BeUniqName).WithMessage("The specified category");
            _context = context;
        }

        public async Task<bool> BeUniqName(UpdateCategoryCommand model , string categoryName, CancellationToken cancellationToken)
        {
            return await _context.Categories.Where(x=>x.Id != model.Id)
                .AllAsync(x=> x.CategoryName != categoryName , cancellationToken);
        }

    }

}
