using FluentValidation;
using NS.STMS.DTO.SystemTables.Language;

namespace NS.STMS.Business.Modules.SystemTables.Validations.FluentValidation
{
	public class CreateLanguageValidator : AbstractValidator<CreateLanguageRequestDto>
	{

		public CreateLanguageValidator()
		{

			RuleFor(x => x.UserId).NotEmpty();

			RuleFor(i => i.LanguageKey).MaximumLength(50);
			RuleFor(i => i.trTR).MaximumLength(500);
			RuleFor(i => i.enUS).MaximumLength(500);

		}

	}
}
