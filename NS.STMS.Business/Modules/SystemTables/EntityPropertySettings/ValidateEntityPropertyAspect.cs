using NS.STMS.Core.Utilities.ExceptionHandling;
using PostSharp.Aspects;

namespace NS.STMS.Business.Modules.SystemTables.EntityPropertySettings
{
    [Serializable]
    public class ValidateEntityPropertyAspect : LocationInterceptionAspect
    {

        public override void OnGetValue(LocationInterceptionArgs args)
        {
            base.OnGetValue(args);

            if (args.Value is null || (int)args.Value is 0)
                throw new FatalException();
        }

    }
}
