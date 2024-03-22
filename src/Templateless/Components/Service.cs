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

		[EnumMember(Value = "PHONE")]
		Phone,

		[EnumMember(Value = "FACEBOOK")]
		Facebook,

		[EnumMember(Value = "YOUTUBE")]
		YouTube,

		[EnumMember(Value = "TWITTER")]
		Twitter,

		[EnumMember(Value = "X")]
		X,

		[EnumMember(Value = "GITHUB")]
		GitHub,

		[EnumMember(Value = "INSTAGRAM")]
		Instagram,

		[EnumMember(Value = "LINKEDIN")]
		LinkedIn,

		[EnumMember(Value = "SLACK")]
		Slack,

		[EnumMember(Value = "DISCORD")]
		Discord,

		[EnumMember(Value = "TIKTOK")]
		TikTok,

		[EnumMember(Value = "SNAPCHAT")]
		Snapchat,

		[EnumMember(Value = "THREADS")]
		Threads,

		[EnumMember(Value = "TELEGRAM")]
		Telegram,

		[EnumMember(Value = "MASTODON")]
		Mastodon,

		[EnumMember(Value = "RSS")]
		Rss,
	}
}
