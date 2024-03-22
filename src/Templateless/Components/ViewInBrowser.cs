using Newtonsoft.Json;

namespace Templateless.Components
{
	public class ViewInBrowser : IComponent
	{
		[JsonProperty("id")]
		public ComponentId Id { get; private set; }

		[JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
		public string? Text { get; private set; }

		public ViewInBrowser(string? text = null)
		{
			Id = ComponentId.ViewInBrowser;
			Text = text;
		}
	}
}
