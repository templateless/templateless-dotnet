using System;
using System.Threading.Tasks;
using Templateless;

namespace SimpleExample
{
	class Program
	{
		static async Task Main(string[] args)
		{
			try
			{
				var content = Content.Builder()
					.Text("Hello world")
					.Build();

				var email = Email.Builder()
					.To(new EmailAddress("<YOUR_CUSTOMERS_EMAIL_ADDRESS>"))
					.Subject("Hello")
					.Content(content)
					.Build();

				var templatelessClient = new TemplatelessClient("<YOUR_API_KEY>");
				var emailIds = await templatelessClient.SendEmailAsync(email);

				Console.WriteLine(string.Join(", ", emailIds));
			}
			catch (TemplatelessException ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An unexpected error occurred: {ex.Message}");
			}
		}
	}
}
