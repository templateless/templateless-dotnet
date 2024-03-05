<h1 align="center">
  <a href="https://templateless.com/">
    <img src="templateless.webp" alt="Templateless" width="450px">
  </a>
  <br />
</h1>

<p align="center">
  <b>Ship faster by treating email as code 🚀</b> <br />
</p>

<h4 align="center">
  <a href="https://templateless.com/">Website</a> &bull;
  <a href="https://app.templateless.com/">Get Your API Key</a> &bull;
  <a href="https://twitter.com/templateless">Twitter</a>
</h4>

---

[![Latest version](https://img.shields.io/nuget/v/Templateless)](https://www.nuget.org/packages/Templateless)
[![Github Actions](https://img.shields.io/github/actions/workflow/status/templateless/templateless-dotnet/tests.yml)](https://github.com/templateless/templateless-dotnet/actions)
[![Downloads](https://img.shields.io/nuget/dt/Templateless)](https://www.nuget.org/packages/Templateless)
[![X (formerly Twitter) Follow](https://img.shields.io/twitter/follow/Templateless)](https://twitter.com/templateless)

[Templateless](https://templateless.com) lets you generate and send transactional emails quickly and easily so you can focus on building your product.

It's perfect for SaaS, web apps, mobile apps, scripts and anywhere you have to send email programmatically.

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

## 🔑 Get Your API Key

You'll need an API key for the example below ⬇️

[![Get Your API Key](https://img.shields.io/badge/Get_Your_API_Key-free-blue?style=for-the-badge)](https://app.templateless.com/)

- 3,000 emails per month
- All popular email provider integrations
- Start sending right away

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

There are more C# examples in the [examples](examples) folder ✨

> [!NOTE]
> 🚧 **The SDK is not stable yet.** This API might change as more features are added. Please watch the repo for the changes in the [CHANGELOG](CHANGELOG.md).

## 🏗 Debugging

You can generate _test API keys_ by activating the **Test Mode** in your dashboard. By using these keys, you'll be able to view your fully rendered emails without actually sending them.

When you use a test API key in your SDK, the following output will appear in your logs when you try to send an email:

```log
Templateless [TEST MODE]: Emailed user@example.com, preview: https://tmpl.sh/ATMxHLX4r9aE
```

The preview link will display the email, but you must be logged in to Templateless to view it.

## 🔳 Components

Emails are crafted programmatically by making function calls. There's no dealing with HTML or drag-and-drop builders.

All of the following components can be mixed and matched to create dynamic emails:

<details>
  <summary>Text / Markdown</summary>

Text component allow you to insert a paragraph. Each paragraph supports basic markdown:

- Bold text: `**bold text**`
- Italic text: `_italic text_`
- Link: `[link text](https://example.com)`
- Also a link: `<https://example.com>`
- Headers (h1-h6):

  - `# Big Header`
  - `###### Small Header`

- Unordered list:

  ```md
  - item one
  - item two
  - item three
  ```

- Ordered list:

  ```md
  1. item one
  1. item two
  1. item three
  ```

```cs
Content.Builder()
    .Text("## Thank you for signing up")
    .Text("Please **verify your email** by [clicking here](https://example.com/confirm?token=XYZ)")
    .Build();
```

</details>
<details><summary>Link</summary>

Link component adds an anchor tag. This is the same as a text component with the link written in markdown:

```cs
Content.Builder()
    .Link("Confirm Email", "https://example.com/confirm?token=XYZ") // or...
    .Text("[Confirm Email](https://example.com/confirm?token=XYZ)")
    .Build();
```

</details>
<details><summary>Button</summary>

Button can also be used as a call to action. Button color is set via your dashboard's app color.

```cs
Content.Builder()
    .Button("Confirm Email", "https://example.com/confirm?token=XYZ")
    .Build();
```

</details>
<details><summary>Image</summary>

Image component will link to an image within your email. Keep in mind that a lot of email clients will prevent images from being loaded automatically for privacy reasons.

```cs
Content.Builder()
    .Image(
        "https://placekitten.com/300/200",  // where the image is hosted
        "https://example.com",              // [optional] link url, if you want it to be clickable
        300,                                // [optional] width
        200,                                // [optional] height
        "Alt text"                          // [optional] alternate text
    )
    .Build();
```

Only the `src` parameter is required; everything else is optional.

**If you have "Image Optimization" turned on:**

1. Your images will be cached and distributed by our CDN for faster loading. The cache does not expire. If you'd like to re-cache, simply append a query parameter to the end of your image url.
1. Images will be converted into formats that are widely supported by email clients. The following image formats will be processed automatically:

    - Jpeg
    - Png
    - Gif
    - WebP
    - Tiff
    - Ico
    - Bmp
    - Svg

1. Maximum image size is 5MB for free accounts and 20MB for paid accounts.
1. You can specify `width` and/or `height` if you'd like (they are optional). Keep in mind that images will be scaled down to fit within the email theme, if they're too large.

</details>
<details><summary>One-Time Password</summary>

OTP component is designed for showing temporary passwords and reset codes.

```cs
Content.Builder()
    .Text("Here's your **temporary login code**:")
    .Otp("XY78-2BT0-YFNB-ALW9")
    .Build();
```

</details>
<details><summary>Social Icons</summary>

You can easily add social icons with links by simply specifying the username. Usually, this component is placed in the footer of the email.

These are all the supported platforms:

```cs
Content.Builder()
    .Socials(new List<SocialItem>
    {
        new SocialItem(Service.Website, "https://example.com"),
        new SocialItem(Service.Email, "username@example.com"),
        new SocialItem(Service.Phone, "123-456-7890"), // `tel:` link
        new SocialItem(Service.Facebook, "Username"),
        new SocialItem(Service.YouTube, "ChannelID"),
        new SocialItem(Service.Twitter, "Username"),
        new SocialItem(Service.X, "Username"),
        new SocialItem(Service.GitHub, "Username"),
        new SocialItem(Service.Instagram, "Username"),
        new SocialItem(Service.LinkedIn, "Username"),
        new SocialItem(Service.Slack, "Org"),
        new SocialItem(Service.Discord, "Username"),
        new SocialItem(Service.TikTok, "Username"),
        new SocialItem(Service.Snapchat, "Username"),
        new SocialItem(Service.Threads, "Username"),
        new SocialItem(Service.Telegram, "Username")
    })
    .Build();
```

</details>
<details><summary>View in Browser</summary>

If you'd like your recipients to be able to read the email in a browser, you can add the "view in browser" component that will automatically generate a link. Usually, this is placed in the header or footer of the email.

You can optionally provide the text for the link. If none is provided, default is used: "View in browser"

**Anyone who knows the link will be able to see the email.**

```cs
Content.Builder()
    .ViewInBrowser("Read Email in Browser")
    .Build();
```

</details>

---

Components can be placed in the header, body and footer of the email. Header and footer styling is usually a bit different from the body (for example the text is smaller).

```cs
var header = Header.Builder() // header of the email
  .Text("Smaller text")
  .Build();

var content = Content.Builder() // body of the email
  .Text("Normal text")
  .Build();
```

Currently there are 2 themes to choose from: `Theme.Unstyled` and `Theme.Simple`

```cs
var content = Content.Builder()
  .Theme(Theme.Simple)
  .Text("Hello world")
  .Build();
```

## 🤝 Contributing

- Contributions are more than welcome
- Please **star this repo** for more visibility <3

## 📫 Get in touch

- For customer support feel free to email us at [github@templateless.com](mailto:github@templateless.com)

- Have suggestions or want to give feedback? Here's how to reach us:

    - For feature requests, please [start a discussion](https://github.com/templateless/templateless-dotnet/discussions)
    - Found a bug? [Open an issue!](https://github.com/templateless/templateless-dotnet/issues)
    - Say hi [@Templateless](https://twitter.com/templateless) 👋

## 🍻 License

[MIT](LICENSE)