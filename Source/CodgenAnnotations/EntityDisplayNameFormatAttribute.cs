using System;

namespace CodgenAnnotations
{
	public class EntityDisplayNameFormatAttribute
	{
		public string InterpolationString{ get; private set; }
		public EntityDisplayNameFormatAttribute(string interpolationString)
		{
			InterpolationString = interpolationString;
		}
	}
}

