using System.ComponentModel.DataAnnotations;

namespace BlazorToDoListLibrary
{
	public class ToDoActive
	{
		[Key]
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public bool IsDone { get; set; }
		public DateTime DateTimeCreate { get; set; }
		public DateTime? DateTimeDue { get; set; }
	}
}