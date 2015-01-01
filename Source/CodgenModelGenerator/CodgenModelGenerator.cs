using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CodgenModelGenerator
{
	public static class CodgenModelGenerator
	{
		public static string GetJsonFromClasses(IEnumerable<Type> classes)
		{
			return JsonConvert.SerializeObject(classes.Select(c => new Entity(c)));
		}
	}
}

