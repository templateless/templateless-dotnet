using Newtonsoft.Json;

namespace Templateless.Components
{
	public class Text : IComponent
	{
		[JsonProperty("id")]
		public ComponentId Id { get; private set; }

		[JsonProperty("text")]
		public string TextContent { get; private set; }

		public Text(string text)
		{
			Id = ComponentId.Text;
			TextContent = text;
		}
	}
}
