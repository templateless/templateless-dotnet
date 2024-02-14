# Templateless .NET (C#)

[![Latest version](https://img.shields.io/nuget/v/Templateless)](https://www.nuget.org/packages/Templateless)
[![Github Actions](https://img.shields.io/github/actions/workflow/status/templateless/templateless-dotnet/tests.yml)](https://github.com/templateless/templateless-dotnet/actions)
[![Downloads](https://img.shields.io/nuget/dt/Templateless)](https://www.nuget.org/packages/Templateless)

## What is Templateless?

[Templateless](https://templateless.com) lets you generate and send transactional emails quickly and easily so you can ship faster 🚀

## ✨ Features

- 👋 **Anti drag-and-drop by design** — emails are a part of your code
- ✅ **Components as code** — function calls turn into email HTML components
- 💻 **SDK for any language** — use your favorite [programming language](https://github.com/orgs/templateless/repositories)
- 🔍 **Meticulously tested** — let us worry about email client compatibility
- 💌 **Use your favorite ESP** — Amazon SES, SendGrid, Mailgun + more
- 💪 **Email infrastructure** — rate-limiting, retries, scheduling + more
- ⚡ **Batch sending** — send 1 email or 1,000 with one API call

## 🚀 Getting started

Install the [NuGet package](https://nuget.org/packages/Templateless):

```bash
Install-Package Templateless
```

Alternatively, using the .NET CLI:

```bash
dotnet add package Templateless
```

## 👩‍💻 Quick example

This is all it takes to send a signup confirmation email:

```cs
using System;
using System.Threading.Tasks;
using Templateless;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var content = Content.Builder()
                .Text("Hi, please **confirm your email**:")
                .Button("Confirm Email", "https://your-company.com/signup/confirm?token=XYZ")
                .Build();

            var email = Email.Builder()
                .To(new EmailAddress("<YOUR_CUSTOMERS_EMAIL_ADDRESS>"))
                .Subject("Confirm your signup 👋")
                .Content(content)
                .Build();

            var templateless = new TemplatelessClient("<YOUR_API_KEY>");
            var emailIds = await templateless.SendEmailAsync(email);

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
```

Note:

1. Get your **free API key** here: <https://app.templateless.com> ✨
1. There are more C# examples in the [examples](examples) folder:

    ```bash
    TEMPLATELESS_API_KEY=<YOUR_API_KEY> \
        TEMPLATELESS_EMAIL_ADDRESS=<YOUR_EMAIL_ADDRESS> \
        dotnet run --project ./examples/SimpleExample/SimpleExample.csproj
    ```

## 🤝 Contributing

- Contributions are more than welcome <3
- Please **star this repo** for more visibility ★

## 📫 Get in touch

- For customer support feel free to email us at [github@templateless.com](mailto:github@templateless.com)

- Have suggestions or want to give feedback? Here's how to reach us:

    - For feature requests, please [start a discussion](https://github.com/templateless/templateless-rust/discussions)
    - Found a bug? [Open an issue!](https://github.com/templateless/templateless-rust/issues)
    - We are also on Twitter: [@Templateless](https://twitter.com/templateless)

## 🍻 License

[MIT](LICENSE)