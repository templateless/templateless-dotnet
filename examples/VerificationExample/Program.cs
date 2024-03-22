using Templateless;
using Header = Templateless.Collection;
using Footer = Templateless.Collection;
using Templateless.Components;

namespace VerificationExample
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

				var header = Header.Builder()
					.Image("https://templateless.net/myco.webp", null, 100, null, "MyCo")
					.Build();

				var footer = Footer.Builder()
					.Socials(new List<SocialItem>
					{
						new SocialItem(Service.Twitter, "MyCo"),
						new SocialItem(Service.GitHub, "MyCo")
					})
					.Link("Unsubscribe", "https://example.com")
					.Build();

				var verifyEmailLink = "https://example.com/verify?token=ABC";

				var content = Content.Builder()
					.Theme(Theme.Simple)
					.Header(header)
					.Text("Hi there,")
					.Text("Welcome to **MyCo**! We're excited to have you on board. Before we get started, we need to verify your email address.")
					.Text("Please confirm your email by clicking the button below:")
					.Button("Verify Email", verifyEmailLink)
					.Text("Or use the link below:")
					.Link(verifyEmailLink, verifyEmailLink)
					.Footer(footer)
					.Build();

				var email = Email.Builder()
					.To(new EmailAddress(emailAddress))
					.Subject("Confirm your email")
					.Content(content)
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
