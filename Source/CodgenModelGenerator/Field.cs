using System;
using System.Reflection;

namespace CodgenModelGenerator
{
	public class Field
	{
		public Field(PropertyInfo prop)
		{
			name = prop.Name;
			cstype = prop.PropertyType.Name;
			key = Meta.GetKey (prop.PropertyType);
			IsKey = Meta.IsKey (prop);
			hidden = Meta.IsHidden (prop);
			DisplayOnly = Meta.IsDisplay (prop);
			IsObject = Meta.IsObject (prop.PropertyType);
			IsCollection = Meta.IsCollection (prop.PropertyType);
			label = Meta.GetLabel (prop);
			WriteOnce = Meta.IsWriteOnce (prop);
		}

		public static Field New(PropertyInfo prop)
		{
			return new Field (prop);
		}

		public string name { get; set; }

		public string cstype { get; set; }

		public string key { get; set; }

		public bool hidden { get; set; }

		[JsonProperty(PropertyName="is key")]
		public bool IsKey { get; set; }

		[JsonProperty(PropertyName="display only")]
		public bool DisplayOnly { get; set; }

		[JsonProperty(PropertyName="write once")]
		public bool WriteOnce { get; set; }

		[JsonProperty(PropertyName="is object")]
		public bool IsObject { get; set; }

		[JsonProperty(PropertyName="is collection")]
		public bool IsCollection { get; set; }

		public string label { get; set; }
	}
}

