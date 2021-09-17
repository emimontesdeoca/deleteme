using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using BlazorApp.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Api
{
    public interface ITodoData
    {
        Task<TodoItem> AddTodoItem(TodoItem todoItem);
        Task<bool> DeleteTodoItem(Guid id);
        Task<IEnumerable<TodoItem>> GetTodoItems();
        Task<TodoItem> UpdateTodoItem(TodoItem todoItem);
    }

    public class TodoData : ITodoData
    {
        public static List<TodoItem> TodoItemList { get; set; } = new List<TodoItem>() {
            new TodoItem()
                {
                    Id = Guid.NewGuid(),
                    Done = true,
                    Message = "Look at Emi's presentation!",
                },
            new TodoItem()
                {
                    Id = Guid.NewGuid(),
                    Done = true,
                    Message = "Follow on Github!",
                }
        };

		public Task<TodoItem> AddTodoItem(TodoItem todoItem)
		{
            TodoItemList.Add(todoItem);
            return Task.FromResult(todoItem);
        }

		public Task<bool> DeleteTodoItem(Guid id)
		{
            var index = TodoItemList.FindIndex(p => p.Id == id);
            TodoItemList.RemoveAt(index);
            return Task.FromResult(true);
        }

		public Task<IEnumerable<TodoItem>> GetTodoItems()
		{
            return Task.FromResult(TodoItemList.AsEnumerable());
        }

		public Task<TodoItem> UpdateTodoItem(TodoItem todoItem)
		{
            var index = TodoItemList.FindIndex(p => p.Id == todoItem.Id);
            TodoItemList[index] = todoItem;
            return Task.FromResult(todoItem);
        }
	}
}
