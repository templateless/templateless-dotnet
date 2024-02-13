using Newtonsoft.Json;

namespace Templateless.Components
{
	public interface IComponent
	{
		[JsonProperty("id")]
		ComponentId Id { get; }
	}
}
