using System;
using Newtonsoft.Json;

namespace Templateless
{
	/// <summary>
	/// Represents an email address with an optional name.
	/// </summary>
	[Serializable]
	public class EmailAddress
	{
		/// <summary>
		/// Gets the name associated with the email address. Can be null.
		/// </summary>
		[JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
		public string? Name { get; private set; }

		/// <summary>
		/// Gets the email address.
		/// </summary>
		[JsonProperty("email")]
		public string Email { get; private set; }

		/// <summary>
		/// Initializes a new instance of the EmailAddress class with the specified email.
		/// </summary>
		/// <param name="email">The email address.</param>
		public EmailAddress(string email)
		{
			Email = email;
			Name = null;
		}

		/// <summary>
		/// Initializes a new instance of the EmailAddress class with the specified name and email.
		/// </summary>
		/// <param name="name">The name associated with the email address.</param>
		/// <param name="email">The email address.</param>
		public EmailAddress(string name, string email)
		{
			Name = name;
			Email = email;
		}
	}
}
