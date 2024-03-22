using Newtonsoft.Json;

namespace Templateless.Components
{
	public enum Cryptocurrency
	{
		[System.ComponentModel.Description("bitcoin")]
		Bitcoin,

		[System.ComponentModel.Description("ethereum")]
		Ethereum,
	}

	public class QrCode : IComponent
	{
		[JsonProperty("id")]
		public ComponentId Id { get; private set; }

		[JsonProperty("data")]
		public string Data { get; private set; }

		public QrCode(byte[] data)
		{
			Id = ComponentId.QrCode;
			Data = Convert.ToBase64String(data);
		}

		public static QrCode Email(string email)
		{
			return new QrCode(System.Text.Encoding.UTF8.GetBytes($"mailto:{email}"));
		}

		public static QrCode Url(string url)
		{
			return new QrCode(System.Text.Encoding.UTF8.GetBytes(url));
		}

		public static QrCode Phone(string phone)
		{
			return new QrCode(System.Text.Encoding.UTF8.GetBytes($"tel:{phone}"));
		}

		public static QrCode Sms(string text)
		{
			return new QrCode(System.Text.Encoding.UTF8.GetBytes($"smsto:{text}"));
		}

		public static QrCode Coordinates(double lat, double lng)
		{
			return new QrCode(System.Text.Encoding.UTF8.GetBytes($"geo:{lat},{lng}"));
		}

		public static QrCode CryptocurrencyAddress(Cryptocurrency cryptocurrency, string address)
		{
			string cryptoLabel = cryptocurrency.ToString().ToLower();

			var fieldInfo = cryptocurrency.GetType().GetField(cryptocurrency.ToString());
			if (fieldInfo != null)
			{
				var attributes = (System.ComponentModel.DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
				if (attributes.Length > 0)
				{
					cryptoLabel = attributes[0].Description.ToLower();
				}
			}

			return new QrCode(System.Text.Encoding.UTF8.GetBytes($"{cryptoLabel}:{address}"));
		}
	}
}
