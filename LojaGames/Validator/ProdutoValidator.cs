﻿using FluentValidation;
using LojaGames.Model;

namespace LojaGames.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator() 
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);
            RuleFor(p => p.Descricao)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);
            RuleFor(p => p.Console)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);
            RuleFor(p => p.DataLancamento)
                .NotEmpty();
            RuleFor(p => p.Preco)
                .NotNull()
                .GreaterThan(0)
                .PrecisionScale(10, 2, false);
            RuleFor(p => p.Foto)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);
        }
    }
}
