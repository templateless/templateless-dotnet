using Newtonsoft.Json;

namespace Templateless.Components
{
	public class StoreBadgeItem
	{
		[JsonProperty("key")]
		public StoreBadge Key { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }

		public StoreBadgeItem(StoreBadge key, string value)
		{
			Key = key;
			Value = value;
		}
	}
}
