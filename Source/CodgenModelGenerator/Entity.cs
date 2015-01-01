using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using CodgenAnnotations;
using System.Collections;
using System.Web.Mvc;
using System.ComponentModel;
using System.Web;

namespace CodgenModelGenerator
{
	public class Entity
	{
		public Type Type { get; set; }
		public IEnumerable<Field> Fields { get; set; }
		public string Name { get; set; }
		public string Key { get; set; }
		public string SummaryValue { get; set; }

		public Entity(Type type)
		{
			Name = type.Name;
			Type = type;
			Key = Meta.GetKey (type);
			SummaryValue = Meta.GetSummaryValue(type);
			Fields = type.GetProperties().Select (Field.New).ToList();
		}
	}
}

