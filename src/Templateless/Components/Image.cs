using Newtonsoft.Json;

namespace Templateless.Components
{
	public class Image : IComponent
	{
		[JsonProperty("id")]
		public ComponentId Id { get; set; }

		[JsonProperty("src")]
		public string Src { get; set; }

		[JsonProperty("alt", NullValueHandling = NullValueHandling.Ignore)]
		public string? Alt { get; set; }

		[JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
		public int? Width { get; set; }

		[JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
		public int? Height { get; set; }

		[JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
		public string? Url { get; set; }

		public Image(string src, string? alt = null, int? width = null, int? height = null, string? url = null)
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
