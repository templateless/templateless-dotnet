using Newtonsoft.Json;

namespace Templateless.Components
{
	public class Button : IComponent
	{
		[JsonProperty("id")]
		public ComponentId Id { get; private set; }

		[JsonProperty("text")]
		public string Text { get; private set; }

		[JsonProperty("url")]
		public string Url { get; private set; }

		public Button(string text, string url)
		{
			Id = ComponentId.Button;
			Text = text;
			Url = url;
		}
	}
}
