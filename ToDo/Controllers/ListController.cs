using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using ToDo.Interfaces;
using ToDo.Models;
using ToDo.Models.Requests;

namespace ToDo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListController : Controller
    {
        private readonly IToDoListProvider _provider;
        //Add a list
        //    b.Get all lists

        public ListController(
            IToDoListProvider provider
            )
        {
            _provider = provider;
        }

        [HttpPost("list")]
        public async Task<IActionResult> CreateListAsync([FromBody] CreateListRequest request)
        {
            var list = new ToDoList()
            {
                Id = default(int),
                UserId = request.UserId,
                Label = request.Label
            };
            var result = new ApiResponse<int>()
            {
                Data = await _provider.SaveAsync(list),
                SuccessMessage = $"Successfully created list {request.Label}"
            };
            return new OkObjectResult(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllListsAsync(
            [FromQuery] int userid
        )
        {
            return new OkObjectResult(new ApiResponse<IEnumerable<ToDoList>>()
            {
                Data = await _provider.GetAllListsForUser(userid),
                Sucess = true,
                SuccessMessage = "Successfully retrieved all lists for user"
            });
        }
    }
}
