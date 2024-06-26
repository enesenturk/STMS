﻿using FluentValidation;
using NS.STMS.Core.CrossCuttingConcerns.Validation.FluentValidation;
using PostSharp.Aspects;

namespace NS.STMS.Core.Aspects.Postsharp
{
	[Serializable]
	public class FluentValidationAspect : OnMethodBoundaryAspect
	{
		Type _validatorType;

		public FluentValidationAspect(Type validatorType)
		{
			_validatorType = validatorType;
		}

		public override void OnEntry(MethodExecutionArgs args)
		{
			var validator = (IValidator)Activator.CreateInstance(_validatorType);
			var entityType = _validatorType.BaseType.GetGenericArguments()[0];
			var entities = args.Arguments.Where(t => t.GetType() == entityType);

			foreach (var entity in entities)
			{
				ValidatorTool.FluentValidate(validator, entity);
			}
		}

	}
}
