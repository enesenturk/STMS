using NS.STMS.Core.Utilities.ExceptionHandling;
using NS.STMS.DAL.SystemTables.Accessors.Abstract;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Modules.SystemTables.Rules
{
	public class LanguageBusinessRules
	{

		#region CTOR

		private readonly ILanguageDal _languageDal;

		public LanguageBusinessRules(ILanguageDal languageDal)
		{
			_languageDal = languageDal;
		}

		#endregion

		public void LanguageKeyCanNotBeDuplicated(string languageKey)
		{
			List<t_language> result = _languageDal.GetList(x => x.id, x => x.language_key == languageKey);

			if (result.Count > 0) throw new BusinessException("Duplicated_Language");
		}

	}
}
