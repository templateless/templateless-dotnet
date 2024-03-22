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

				var email = Email.Builder()
					.To(new EmailAddress(emailAddress))
					.Subject("Hello")
					.Content(
						Content.Builder()
							.Text("Hello world")
							.Build()
					)
					.Build();

				var templateless = new TemplatelessClient(apiKey);
				await templateless.SendEmailAsync(email);
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
