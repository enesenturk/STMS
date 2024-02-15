using PostSharp.Aspects;

namespace NS.STMS.Business.SystemTables.EntityPropertySettings
{
	[Serializable]
	public class ValidateEntityPropertyAspect : LocationInterceptionAspect
	{

		public override void OnGetValue(LocationInterceptionArgs args)
		{
			base.OnGetValue(args);

			if (args.Value is null || (int)args.Value is 0)
				throw new Exception("Something went wrong while setting system properties. Please contact to the system admin.");
		}

	}
}
