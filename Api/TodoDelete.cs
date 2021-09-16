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
    public class TodoDelete
    {
        private readonly ITodoData todoData;

        public TodoDelete(ITodoData todoData)
        {
            this.todoData = todoData;
        }

        [FunctionName("TodoDelete")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "todo/{todoId:guid}")] HttpRequest req,
            Guid todoId,
            ILogger log)
        {
            var result = await todoData.DeleteTodoItem(todoId);

            if (result)
            {
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }
    }
}
