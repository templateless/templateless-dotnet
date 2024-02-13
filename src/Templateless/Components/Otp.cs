using Newtonsoft.Json;
using Templateless.Components;

namespace Templateless.Components
{
	public class Otp : IComponent
	{
		[JsonProperty("id")]
		public ComponentId Id { get; private set; }

		[JsonProperty("text")]
		public string Text { get; private set; }

		public Otp(string text)
		{
			Id = ComponentId.Otp;
			Text = text;
		}
	}
}
