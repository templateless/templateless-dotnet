using Newtonsoft.Json;
using Templateless.Components;
using TemplatelessTheme = Templateless.Theme;

namespace Templateless
{
	public class Content
	{
		[JsonProperty("version")]
		public byte Version { get; private set; }

		[JsonProperty("theme")]
		public TemplatelessTheme _Theme { get; private set; }

		[JsonProperty("header")]
		public List<IComponent> _Header { get; private set; }

		[JsonProperty("body")]
		public List<List<IComponent>> Body { get; private set; }

		[JsonProperty("footer")]
		public List<IComponent> _Footer { get; private set; }

		private Content()
		{
			Version = 0;
			_Theme = TemplatelessTheme.Unstyled;
			_Header = new List<IComponent>();
			Body = new List<List<IComponent>> { new List<IComponent>() };
			_Footer = new List<IComponent>();
		}

		public static Content Builder()
		{
			return new Content();
		}

		public Content Theme(TemplatelessTheme theme)
		{
			this._Theme = theme;
			return this;
		}

		public Content Header(Collection header)
		{
			this._Header = header.Components;
			return this;
		}

		public Content Footer(Collection footer)
		{
			this._Footer = footer.Components;
			return this;
		}

		public Content Button(string text, string url)
		{
			Body[0].Add(new Button(text, url));
			return this;
		}

		public Content Image(string src, string? url = null, int? width = null, int? height = null, string? alt = null)
		{
			Body[0].Add(new Image(src, alt, width, height, url));
			return this;
		}

		public Content Link(string text, string url)
		{
			Body[0].Add(new Link(text, url));
			return this;
		}

		public Content Otp(string text)
		{
			Body[0].Add(new Otp(text));
			return this;
		}

		public Content Socials(List<SocialItem> data)
		{
			Body[0].Add(new Socials(data));
			return this;
		}

		public Content Text(string text)
		{
			Body[0].Add(new Text(text));
			return this;
		}

		public Content ViewInBrowser(string? text = null)
		{
			Body[0].Add(new ViewInBrowser(text));
			return this;
		}

		public Content QrCode(string url)
		{
			Body[0].Add(Components.QrCode.Url(url));
			return this;
		}

		public Content StoreBadges(List<StoreBadgeItem> data)
		{
			Body[0].Add(new StoreBadges(data));
			return this;
		}

		public Content Signature(string text, SignatureFont? font = null)
		{
			Body[0].Add(new Signature(text, font));
			return this;
		}

		public Content Component(IComponent component)
		{
			Body[0].Add(component);
			return this;
		}

		public Content Build()
		{
			return this;
		}
	}
}
