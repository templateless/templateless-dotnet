using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Templateless.Components
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ComponentId
	{
		[EnumMember(Value = "BUTTON")]
		Button,

		[EnumMember(Value = "IMAGE")]
		Image,

		[EnumMember(Value = "LINK")]
		Link,

		[EnumMember(Value = "OTP")]
		Otp,

		[EnumMember(Value = "POWERED_BY")]
		PoweredBy,

		[EnumMember(Value = "SOCIALS")]
		Socials,

		[EnumMember(Value = "TEXT")]
		Text,

		[EnumMember(Value = "VIEW_IN_BROWSER")]
		ViewInBrowser,
	}
}
