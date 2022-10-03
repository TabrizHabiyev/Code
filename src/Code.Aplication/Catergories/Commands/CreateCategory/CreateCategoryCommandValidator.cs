

using Code.Aplication.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Code.Domain.Catergories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly IAplicationDbContext _context;
        public CreateCategoryCommandValidator()
        {
            RuleFor(v => v.CategoryName)
                .NotEmpty().WithMessage("Category Name is required")
                .MaximumLength(200).WithMessage("Category must not exceed 200 character")
                .MustAsync(BeUniqName).WithMessage("The specified category");
        }

        public async Task<bool> BeUniqName (string categoryName , CancellationToken cancellationToken)
        {
            return await _context.Categories.AllAsync(x => x.CategoryName != categoryName, cancellationToken);
        }

    }



}
