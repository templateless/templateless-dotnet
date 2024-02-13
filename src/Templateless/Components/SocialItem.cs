using Newtonsoft.Json;

namespace Templateless.Components
{
	public class SocialItem
	{
		[JsonProperty("service")]
		public Service Service { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }

		public SocialItem(Service service, string value)
		{
			Service = service;
			Value = value;
		}
	}
}
