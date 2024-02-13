using Newtonsoft.Json;
using Xunit;
using Templateless;

namespace Templateless.Tests
{
	public class EmailAddressTests
	{
		[Fact]
		public void Serialize_WithoutName_ProducesCorrectJson()
		{
			var email = new EmailAddress("test@example.com");
			var expectedJson = "{\"email\":\"test@example.com\"}";

			var json = JsonConvert.SerializeObject(email);

			Assert.Equal(expectedJson, json);
		}

		[Fact]
		public void Serialize_WithName_ProducesCorrectJson()
		{
			var email = new EmailAddress("John Doe", "john@example.com");
			var expectedJson = "{\"name\":\"John Doe\",\"email\":\"john@example.com\"}";

			var json = JsonConvert.SerializeObject(email);

			Assert.Equal(expectedJson, json);
		}
	}
}
