using Templateless;
using Header = Templateless.Collection;
using Footer = Templateless.Collection;
using Templateless.Components;
using System.Reflection;

namespace FeedbackExample
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
					.Build();

				var content = Content.Builder()
					.Theme(Theme.Simple)
					.Header(header)
					.Text("Hey Alex,")
					.Text("I'm Jamie, founder of **MyCo**.")
					.Text("Could you spare a moment to reply to this email with your thoughts on our service? Your feedback is invaluable and directly influences our improvements.")
					.Text("When you hit reply, your email will go directly to me, and I read each and every one.")
					.Text("Thanks for your support,")
					.Signature("Jamie Parker")
					.Text("Jamie Parker\n\nFounder @ [MyCo](https://example.com)")
					.Footer(footer)
					.Build();

				var email = Email.Builder()
					.To(new EmailAddress(emailAddress))
					.Subject("Thoughts on service?")
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
