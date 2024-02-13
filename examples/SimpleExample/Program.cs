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
				var apiKey = Environment.GetEnvironmentVariable("TEMPLATELESS_API_KEY");
				if (string.IsNullOrEmpty(apiKey))
				{
					throw new InvalidOperationException("Set TEMPLATELESS_API_KEY to your Templateless API key");
				}

				var emailAddress = Environment.GetEnvironmentVariable("TEMPLATELESS_EMAIL_ADDRESS");
				if (string.IsNullOrEmpty(emailAddress))
				{
					throw new InvalidOperationException("Set TEMPLATELESS_EMAIL_ADDRESS to your own email address");
				}

				var content = Content.Builder()
					.Text("Hello world")
					.Build();

				var email = Email.Builder()
					.To(new EmailAddress(emailAddress))
					.Subject("Hello")
					.Content(content)
					.Build();

				var templatelessClient = new TemplatelessClient(apiKey);
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
