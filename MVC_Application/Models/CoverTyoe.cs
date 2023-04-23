using System.ComponentModel.DataAnnotations;

namespace MVC_Application.Models
{
	public class CoverType
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Cover Type")]
		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

	}
}
