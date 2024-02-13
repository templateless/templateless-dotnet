using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Templateless
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Theme
	{
		[EnumMember(Value = "UNSTYLED")]
		Unstyled,

		[EnumMember(Value = "SIMPLE")]
		Simple,
	}
}
