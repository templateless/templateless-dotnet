using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Templateless.Components
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum StoreBadge
	{
		[EnumMember(Value = "APP_STORE")]
		AppStore,

		[EnumMember(Value = "GOOGLE_PLAY")]
		GooglePlay,

		[EnumMember(Value = "MICROSOFT_STORE")]
		MicrosoftStore,
	}
}
