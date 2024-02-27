using Newtonsoft.Json;

namespace Templateless.Components
{
	public class ViewInBrowser : IComponent
	{
		[JsonProperty("id")]
		public ComponentId Id { get; private set; }

		[JsonProperty("text")]
		public string Text { get; private set; }

		public ViewInBrowser(string text = "")
		{
			Id = ComponentId.ViewInBrowser;
			Text = text;
		}
	}
}
