using System;

namespace BlazorApp.Shared
{
    public class TodoItem
    {
		public Guid Id { get; set; }
		public string Message { get; set; }
		public int Priority { get; set; }
		public bool Done { get; set; }
		

	}
}
