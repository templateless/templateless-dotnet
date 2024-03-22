using Newtonsoft.Json;

namespace Templateless.Components
{
	public class Signature : IComponent
	{
		[JsonProperty("id")]
		public ComponentId Id { get; private set; }

		[JsonProperty("text")]
		public string Text { get; private set; }

		[JsonProperty("font", NullValueHandling = NullValueHandling.Ignore)]
		public SignatureFont? Font { get; private set; }

		public Signature(string text, SignatureFont? font = null)
		{
			Id = ComponentId.Signature;
			Text = text;
			Font = font;
		}
	}
}
