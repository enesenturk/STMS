using NS.STMS.Business.Modules.SystemTables.EntityPropertySettings.Data;
using NS.STMS.Core.Utilities.ExceptionHandling;
using NS.STMS.DAL.SystemTables.Accessors.Abstract;
using NS.STMS.Entity.Context;
using NS.STMS.Settings.AssemblySettings;
using System.Reflection;

namespace NS.STMS.Business.Modules.SystemTables.EntityPropertySettings
{
	public class EntityPropertyHelper
	{

		public static void SetEntityProperties(IPropertyTypeDal propertyTypeDal, IPropertyDal propertyDal)
		{
			List<t_property_type> propertyTypes = propertyTypeDal.GetList(x => x.name);
			List<t_property> properties = propertyDal.GetList(x => x.name);

			SetPropertyTypes(propertyTypes);
			SetProperties(propertyTypes, properties);
		}

		private static void SetPropertyTypes(List<t_property_type> propertyTypes)
		{
			foreach (t_property_type propertyType in propertyTypes)
			{
				Type entityPropertyType = typeof(EntityPropertyType);

				PropertyInfo property = entityPropertyType.GetProperty(propertyType.name);

				if (property is null)
					ThrowError();

				property.SetValue(null, propertyType.id);
			}
		}

		private static void SetProperties(List<t_property_type> propertyTypes, List<t_property> systemProperties)
		{
			foreach (t_property_type propertyType in propertyTypes)
			{
				string className = propertyType.name;

				Assembly preferencesAssembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == BusinessAssemblySettings.BusinessNamespace);

				Type classType = preferencesAssembly.GetType($"{BusinessAssemblySettings.EntityPropertyNamespace}.{className}");

				if (classType is null)
					ThrowError();

				string propertyTypeName = classType.Name;
				int propertyTypeId = Convert.ToInt32(typeof(EntityPropertyType).GetProperty(propertyTypeName).GetValue(null, null));

				PropertyInfo[] classProperties = classType.GetProperties();

				foreach (PropertyInfo classProperty in classProperties)
				{
					List<t_property> entityProperties = systemProperties.Where(x => x.name == classProperty.Name && x.t_property_type_id == propertyTypeId).ToList();

					if (entityProperties.Count == 0)
						ThrowError();

					if (entityProperties.Count == 1)
						classProperty.SetValue(null, entityProperties[0].id);

					else ThrowError();
				}
			}
		}

		private static void ThrowError()
		{
			throw new FatalException();
		}

	}
}
