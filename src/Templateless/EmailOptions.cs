using Newtonsoft.Json;

namespace Templateless
{
	public class EmailOptions
	{
		[JsonProperty(PropertyName = "deleteAfter", NullValueHandling = NullValueHandling.Ignore)]
		public ulong? DeleteAfter { get; set; }

		public EmailOptions()
		{
			DeleteAfter = null;
		}
	}
}
