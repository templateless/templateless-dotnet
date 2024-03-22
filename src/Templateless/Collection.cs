using Templateless.Components;

namespace Templateless
{
	public class Collection
	{
		public List<IComponent> Components { get; private set; }

		public Collection()
		{
			Components = new List<IComponent>();
		}

		public static Collection Builder()
		{
			return new Collection();
		}

		public Collection Button(string text, string url)
		{
			Components.Add(new Button(text, url));
			return this;
		}

		public Collection Image(string src, string? url = null, int? width = null, int? height = null, string? alt = null)
		{
			Components.Add(new Image(src, alt, width, height, url));
			return this;
		}

		public Collection Link(string text, string url)
		{
			Components.Add(new Link(text, url));
			return this;
		}

		public Collection Otp(string text)
		{
			Components.Add(new Otp(text));
			return this;
		}

		public Collection Socials(List<SocialItem> data)
		{
			Components.Add(new Socials(data));
			return this;
		}

		public Collection Text(string text)
		{
			Components.Add(new Text(text));
			return this;
		}

		public Collection ViewInBrowser(string? text = null)
		{
			Components.Add(new ViewInBrowser(text));
			return this;
		}

		public Collection QrCode(string url)
		{
			Components.Add(Templateless.Components.QrCode.Url(url));
			return this;
		}

		public Collection StoreBadges(List<StoreBadgeItem> data)
		{
			Components.Add(new StoreBadges(data));
			return this;
		}

		public Collection Signature(string text, SignatureFont? font = null)
		{
			Components.Add(new Signature(text, font));
			return this;
		}

		public Collection Component(IComponent component)
		{
			Components.Add(component);
			return this;
		}

		public Collection Build()
		{
			return this;
		}
	}
}
