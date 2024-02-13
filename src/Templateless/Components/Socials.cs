using System.Collections.Generic;
using Newtonsoft.Json;

namespace Templateless.Components
{
	public class Socials : IComponent
	{
		[JsonProperty("id")]
		public ComponentId Id { get; private set; }

		[JsonProperty("data")]
		public List<SocialItem> Data { get; private set; }

		public Socials(List<SocialItem> data)
		{
			Id = ComponentId.Socials;
			Data = data;
		}
	}
}
