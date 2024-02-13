using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Templateless.Components
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Service
	{
		[EnumMember(Value = "WEBSITE")]
		Website,

		[EnumMember(Value = "EMAIL")]
		Email,

		[EnumMember(Value = "TWITTER")]
		Twitter,

		[EnumMember(Value = "X")]
		X,

		[EnumMember(Value = "GITHUB")]
		GitHub,
	}
}
