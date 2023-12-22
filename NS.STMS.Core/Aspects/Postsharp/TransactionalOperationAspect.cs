using System.Transactions;
using PostSharp.Aspects;

namespace NS.STMS.Core.Aspects.Postsharp
{
	[Serializable]
	public class TransactionalOperationAspect : OnMethodBoundaryAspect
	{
		private TransactionScopeOption _option;

		public TransactionalOperationAspect()
		{

		}

		public TransactionalOperationAspect(TransactionScopeOption option)
		{
			_option = option;
		}

		public override void OnEntry(MethodExecutionArgs args)
		{
			args.MethodExecutionTag = new TransactionScope(_option);
		}

		public override void OnSuccess(MethodExecutionArgs args)
		{
			((TransactionScope)args.MethodExecutionTag).Complete();
		}

		public override void OnExit(MethodExecutionArgs args)
		{
			((TransactionScope)args.MethodExecutionTag).Dispose();
		}
	}
}
