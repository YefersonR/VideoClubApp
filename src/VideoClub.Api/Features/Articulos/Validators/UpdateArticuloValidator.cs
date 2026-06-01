using FluentValidation;
using VideoClub.Api.Features.Articulos.Commands;

namespace VideoClub.Api.Features.Articulos.Validators;

public class UpdateArticuloValidator : AbstractValidator<UpdateArticuloCommand>
{
    public UpdateArticuloValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Titulo).NotEmpty().MaximumLength(500);
        RuleFor(x => x.TipoArticuloId).GreaterThan(0);
        RuleFor(x => x.GeneroId).GreaterThan(0);
        RuleFor(x => x.IdiomaId).GreaterThan(0);
        RuleFor(x => x.RentaPorDia).GreaterThan(0);
        RuleFor(x => x.DiasRenta).GreaterThan(0);
        RuleFor(x => x.MontoEntregaTardia).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
    }
}
