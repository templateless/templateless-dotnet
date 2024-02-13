using Newtonsoft.Json;

namespace Templateless.Components
{
	public class Image : IComponent
	{
		[JsonProperty("id")]
		public ComponentId Id { get; private set; }

		[JsonProperty("src")]
		public string Src { get; private set; }

		[JsonProperty("alt")]
		public string Alt { get; private set; }

		[JsonProperty("width")]
		public int Width { get; private set; }

		[JsonProperty("height")]
		public int Height { get; private set; }

		[JsonProperty("url")]
		public string Url { get; private set; }

		public Image(string src, string alt, int width, int height, string url)
		{
			Id = ComponentId.Image;
			Src = src;
			Alt = alt;
			Width = width;
			Height = height;
			Url = url;
		}
	}
}
