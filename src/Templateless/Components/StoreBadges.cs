using Newtonsoft.Json;

namespace Templateless.Components
{
	public class StoreBadges : IComponent
	{
		[JsonProperty("id")]
		public ComponentId Id { get; private set; }

		[JsonProperty("data")]
		public List<StoreBadgeItem> Data { get; private set; }

		public StoreBadges(List<StoreBadgeItem> data)
		{
			Id = ComponentId.StoreBadges;
			Data = data;
		}
	}
}
