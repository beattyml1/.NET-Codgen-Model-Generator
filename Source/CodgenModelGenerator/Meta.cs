using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using CodgenAnnotations;
using System.Collections;
using System.Web.Mvc;
using System.ComponentModel;

namespace CodgenModelGenerator
{
	public static class Meta
	{
		public static string GetKey(Type type)
		{
			return IsObject(type) ? (
				from childProp in type.GetProperties ()
				where childProp.GetCustomAttributes(true).OfType<KeyAttribute>().Any()
				select childProp.Name
			).FirstOrDefault() : null;
		}

		public static bool IsObject(Type type)
		{
			return type.IsClass && !IsCollection (type);
		}

		public static bool IsCollection(Type type)
		{
			return type.IsSubclassOf (typeof(IEnumerable));
		}

		public static bool IsKey(PropertyInfo prop)
		{
			return HasAttribute<KeyAttribute>(prop);
		}

		public static string GetLabel(PropertyInfo prop)
		{
			return prop.GetCustomAttributes(true).OfType<DisplayAttribute>().Select(a => a.Name).FirstOrDefault();
		}

		public static string GetSummaryValue(Type type)
		{
			return type.GetCustomAttributes (true).OfType<EntityDisplayNameFormatAttribute>().Select(x => x.InterpolationString).FirstOrDefault() ??
				type.GetProperties().Where(HasAttribute<IsDisplayNameAttribute>).Select(p => p.Name).FirstOrDefault();
		}

		public static bool IsHidden(PropertyInfo prop)
		{
			return IsKey(prop) || HasAttribute<HiddenInputAttribute>(prop);
		}

		public static bool NotRendered(PropertyInfo prop)
		{
			return false;
		}

		public static bool IsDisplay(PropertyInfo prop)
		{
			return HasAttribute<ReadOnlyAttribute> (prop) && !IsHidden(prop);
		}

		public static bool IsWriteOnce (PropertyInfo prop)
		{
			return HasAttribute<WriteOnceAttribute> (prop);
		}

		public static bool HasAttribute<T>(PropertyInfo prop)
		{
			return prop.GetCustomAttributes (true).OfType<T> ().Any ();
		}

		public static T GetAttribute<T>(PropertyInfo prop)
		{
			return prop.GetCustomAttributes(true).OfType<T>().FirstOrDefault();
		}
	}
}

