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
    public class TodoGet
    {
        private readonly ITodoData todoData;

        public TodoGet(ITodoData todoData)
        {
            this.todoData = todoData;
        }

        [FunctionName("TodoPost")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "todo")] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(await todoData.GetTodoItems());
        }
    }
}
