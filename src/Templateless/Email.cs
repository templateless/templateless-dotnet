using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Templateless.Components;
using TemplatelessContent = Templateless.Content;

namespace Templateless
{
	public class Email
	{
		[JsonProperty("to")]
		public HashSet<EmailAddress> _To { get; private set; }

		[JsonProperty("subject")]
		public string _Subject { get; private set; }

		[JsonProperty("content")]
		public TemplatelessContent _Content { get; private set; }

		[JsonProperty("options")]
		public EmailOptions Options { get; private set; }

		private Email()
		{
			_To = new HashSet<EmailAddress>();
			_Subject = string.Empty;
			_Content = TemplatelessContent.Builder();
			Options = new EmailOptions();
		}

		public static Email Builder()
		{
			return new Email();
		}

		public Email To(EmailAddress emailAddress)
		{
			_To.Add(emailAddress);
			return this;
		}

		public Email ToMany(IEnumerable<EmailAddress> emailAddresses)
		{
			foreach (var emailAddress in emailAddresses)
			{
				_To.Add(emailAddress);
			}
			return this;
		}

		public Email Subject(string subject)
		{
			_Subject = subject;
			return this;
		}

		public Email Content(TemplatelessContent content)
		{
			_Content = content;
			return this;
		}

		public Email DeleteAfter(ulong seconds)
		{
			Options.DeleteAfter = seconds;
			return this;
		}

		public Email Build()
		{
			return this;
		}
	}
}
