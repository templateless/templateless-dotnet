using System.Collections.Generic;
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

		public Collection Image(string src, string url, int? width, int? height, string alt)
		{
			Components.Add(new Image(src, alt ?? string.Empty, width ?? 0, height ?? 0, url ?? string.Empty));
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

		public Collection ViewInBrowser(string text)
		{
			Components.Add(new ViewInBrowser(text));
			return this;
		}

		public Collection Build()
		{
			return this;
		}
	}
}
