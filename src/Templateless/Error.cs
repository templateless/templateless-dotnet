using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Templateless
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum BadRequestCode
	{
		[EnumMember(Value = "account quota exceeded")]
		AccountQuotaExceeded = 200,

		[EnumMember(Value = "provider key missing")]
		ProviderKeyMissing = 300,

		[EnumMember(Value = "provider key invalid")]
		ProviderKeyInvalid = 301,

		[EnumMember(Value = "email has no content to send")]
		EmailNoContent = 400,
	}

	public class TemplatelessError
	{
		[JsonProperty("field")]
		public string? Field { get; set; }

		[JsonProperty("code")]
		public BadRequestCode? Code { get; set; }

		[JsonProperty("error")]
		public string? Error { get; set; }
	}

	[Serializable]
	public class TemplatelessException : Exception
	{
		public ErrorType Type { get; }
		public BadRequestCode? Code { get; }
		public string? Field { get; }

		public TemplatelessException(ErrorType type, string? message, BadRequestCode? code = null, string? field = null)
			: base(message)
		{
			Type = type;
			Code = code;
			Field = field;
		}
	}

	[JsonConverter(typeof(StringEnumConverter))]
	public enum ErrorType
	{
		[EnumMember(Value = "unauthorized")]
		Unauthorized,

		[EnumMember(Value = "forbidden")]
		Forbidden,

		[EnumMember(Value = "invalid parameter")]
		InvalidParameter,

		[EnumMember(Value = "bad request")]
		BadRequest,

		[EnumMember(Value = "unavailable")]
		Unavailable,

		[EnumMember(Value = "unknown error")]
		Unknown,
	}
}
