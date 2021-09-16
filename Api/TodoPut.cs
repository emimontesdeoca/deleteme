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
using System.IO;
using System.Text.Json;

namespace BlazorApp.Api
{
    public class TodoPut
    {
        private readonly ITodoData todoData;

        public TodoPut(ITodoData todoData)
        {
            this.todoData = todoData;
        }

        [FunctionName("TodoPut")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "todo")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var todoItem = JsonSerializer.Deserialize<TodoItem>(body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var newtodoItem = await todoData.UpdateTodoItem(todoItem);
            return new OkObjectResult(newtodoItem);
        }
    }
}
