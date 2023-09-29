using FluentValidation;
using LojaGames.Model;

namespace LojaGames.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Tipo)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);
        }
    }
}
