using System;
using System.Threading.Tasks;
using Templateless;
using Header = Templateless.Collection;
using Footer = Templateless.Collection;
using Templateless.Components;

namespace ConfirmEmailExample
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
                    .Text("# ExampleApp")
                    .Build();
                
                var footer = Footer.Builder()
                    .Socials(new List<SocialItem>
                    {
                        new SocialItem(Service.Twitter, "ExampleApp"),
                        new SocialItem(Service.GitHub, "ExampleApp")
                    })
                    .Link("Unsubscribe", "https://example.com/unsubscribe?id=123")
                    .Build();

                var content = Content.Builder()
                    .Header(header)
                    .Text("Hello world")
                    .Footer(footer)
                    .Build();

                var email = Email.Builder()
                    .To(new EmailAddress(emailAddress))
                    .Subject("Confirm your email")
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
