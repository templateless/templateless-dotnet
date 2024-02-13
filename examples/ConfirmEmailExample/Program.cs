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
                    .To(new EmailAddress("<YOUR_CUSTOMERS_EMAIL_ADDRESS>"))
                    .Subject("Confirm your email")
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
