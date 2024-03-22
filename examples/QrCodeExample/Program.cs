using Templateless;
using Header = Templateless.Collection;
using Footer = Templateless.Collection;
using Templateless.Components;

namespace QrCodeExample
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

				var appStoreLink = "https://apps.apple.com/us/app/example/id1234567890";
				var googlePlayLink = "https://play.google.com/store/apps/details?id=com.example";

				var footer = Footer.Builder()
					.Socials(new List<SocialItem>
					{
						new SocialItem(Service.Twitter, "MyCo"),
						new SocialItem(Service.GitHub, "MyCo")
					})
					.Build();

				var content = Content.Builder()
					.Theme(Theme.Simple)
					.Header(header)
					.Text("Hey Alex,")
					.Text("Thank you for choosing MyCo! To get started with our mobile experience, simply pair your account with our mobile app.")
					.Text("Here's how to do it:")
					.Text(string.Join("\n",
						$"1. Download the MyCo app from the [App Store]({appStoreLink}) or [Google Play]({googlePlayLink}).",
						"1. Open the app and select _Pair Device_.",
						"1. Scan the QR code below with your mobile device:"
					))
					.QrCode("https://example.com/qr-code-link")
					.Text("Enjoy your seamless experience across devices!")
					.Footer(footer)
					.Build();

				var email = Email.Builder()
					.To(new EmailAddress(emailAddress))
					.Subject("How to Pair Device")
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
