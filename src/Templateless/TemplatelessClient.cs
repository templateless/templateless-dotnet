using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Templateless
{
	public class TemplatelessClient
	{
		private readonly HttpClient _client;
		private readonly string _apiKey;

		public TemplatelessClient(string apiKey)
		{
			_apiKey = apiKey;

			_client = new HttpClient
			{
				BaseAddress = new Uri("https://api.templateless.com")
			};
		}

		public async Task<List<string>> SendEmailAsync(Email email)
		{
			return await SendEmailsAsync(new List<Email> { email });
		}

		public async Task<List<string>> SendEmailsAsync(List<Email> emails)
		{
			var content = new StringContent(JsonConvert.SerializeObject(new { payload = emails }, Formatting.Indented));
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

			var response = await _client.PostAsync("/v1/emails", content);

			if (!response.IsSuccessStatusCode)
			{
				var errorContent = await response.Content.ReadAsStringAsync();
				var error = JsonConvert.DeserializeObject<TemplatelessError>(errorContent);

				ErrorType errorType = response.StatusCode switch
				{
					HttpStatusCode.Unauthorized => ErrorType.Unauthorized,
					HttpStatusCode.Forbidden => ErrorType.Forbidden,
					HttpStatusCode.BadRequest => ErrorType.BadRequest,
					HttpStatusCode.UnprocessableEntity => ErrorType.InvalidParameter,
					HttpStatusCode.ServiceUnavailable => ErrorType.Unavailable,
					_ => ErrorType.Unknown,
				};

				throw new TemplatelessException(errorType, error?.Error, error?.Code, error?.Field);
			}

			var responseContent = await response.Content.ReadAsStringAsync();
			var res = JsonConvert.DeserializeObject<EmailResponse>(responseContent);

			if (res.Previews != null)
			{
				foreach (var preview in res.Previews)
				{
					Console.WriteLine($"Templateless [TEST MODE]: Emailed {preview.Email}, preview: https://tmpl.sh/{preview.Preview}");
				}
			}

			return res?.Emails ?? new List<string>();
		}

		private ErrorType ParseErrorType(HttpStatusCode statusCode)
		{
			return statusCode switch
			{
				HttpStatusCode.Unauthorized => ErrorType.Unauthorized,
				HttpStatusCode.Forbidden => ErrorType.Forbidden,
				HttpStatusCode.BadRequest => ErrorType.BadRequest,
				HttpStatusCode.UnprocessableEntity => ErrorType.InvalidParameter,
				HttpStatusCode.ServiceUnavailable => ErrorType.Unavailable,
				_ => ErrorType.Unknown,
			};
		}
	}

	public class EmailResponsePreview
	{
		[JsonProperty("preview")]
		public string Preview { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
	}

	public class EmailResponse
	{
		[JsonProperty("emails")]
		public List<string>? Emails { get; set; }
		[JsonProperty("previews")]
		public List<EmailResponsePreview>? Previews { get; set; }
	}
}
