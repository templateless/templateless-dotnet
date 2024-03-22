using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Templateless.Components
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum SignatureFont
	{
		[EnumMember(Value = "REENIE_BEANIE")]
		ReenieBeanie = 1,

		[EnumMember(Value = "MEOW_SCRIPT")]
		MeowScript = 2,

		[EnumMember(Value = "CAVEAT")]
		Caveat = 3,

		[EnumMember(Value = "ZEYADA")]
		Zeyada = 4,

		[EnumMember(Value = "PETEMOSS")]
		Petemoss = 5,
	}
}
