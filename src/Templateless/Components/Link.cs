using Newtonsoft.Json;

namespace Templateless.Components
{
	public class Link : IComponent
	{
		[JsonProperty("id")]
		public ComponentId Id { get; private set; }

		[JsonProperty("text")]
		public string Text { get; private set; }

		[JsonProperty("url")]
		public string Url { get; private set; }

		public Link(string text, string url)
		{
			Id = ComponentId.Link;
			Text = text;
			Url = url;
		}
	}
}
