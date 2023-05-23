namespace BlazorToDoListServer.Model
{
	public class TodoItem
	{
		public string? Title { get; set; }
		public bool IsDone { get; set; }
		public DateTime DateTime { get; set; }
	}
}
