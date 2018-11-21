using System.ComponentModel.DataAnnotations;

namespace TestWebClient.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[Display(Name = "User's name")]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Required]
		[Compare("Password", ErrorMessage = "Password is incorrect")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm a password")]
		public string PasswordConfirm { get; set; }
	}
}
