using FluentValidation;
using NS.STMS.DTO.SystemTables.Language;

namespace NS.STMS.Business.Modules.SystemTables.Validations.FluentValidation
{
	public class UpdateLanguageValidator : AbstractValidator<UpdateLanguageRequestDto>
	{

		public UpdateLanguageValidator()
		{

			RuleFor(x => x.UserId).NotEmpty();

			RuleFor(i => i.trTR).MaximumLength(500);
			RuleFor(i => i.enUS).MaximumLength(500);

		}

	}
}
