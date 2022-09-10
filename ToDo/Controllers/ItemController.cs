using Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using ToDo.Interfaces;
using ToDo.Models;
using ToDo.Models.Enums;
using ToDo.Models.Requests;

namespace ToDo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IToDoItemProvider _provider;

        //c.Get all TODOS for all lists
        //d.Get all TODOs for specific list
        //e.Add a TODO
        //    f. Edit a TODOs label
        //    g.Toggle a TODO
        //h. Remove a TODO

        public ItemController(
            IToDoItemProvider provider
            )
        {
            _provider = provider;
        }

        [HttpGet("all/user")]
        public async Task<IActionResult> GetAllItmesByUserIdAsync(
            [FromQuery] int userid
        )
        {
            return new OkObjectResult(new ApiResponse<IEnumerable<ToDoItem>>()
            {
                Data = await _provider.GetAllToDosForUser(userid),
                Sucess = true,
                SuccessMessage = "Successfully retrieved all items for user"
            });
        }

        [HttpGet("all/list")]
        public async Task<IActionResult> GetAllItmesByListIdAsync(
            [FromQuery] int userid
        )
        {
            return new OkObjectResult(new ApiResponse<IEnumerable<ToDoItem>>()
            {
                Data = await _provider.GetAllToDosForList(userid),
                Sucess = true,
                SuccessMessage = "Successfully retrieved all items for list"
            });
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateListAsync(
            [FromBody] CreateItemRequest request
        )
        {
            var item = new ToDoItem()
            {
                Id = default(int),
                ToDoListId = request.ListId,
                Label = request.Label,
                Priority = -1,
                Status = ToDoListStatusEnum.Backlog
            };
            return new OkObjectResult(new ApiResponse<int>()
            {
                Data = await _provider.SaveAsync(item),
                Sucess = true,
                SuccessMessage = "Successfully retrieved all items for list"
            });
        }

        [HttpPatch("update_label")]
        public async Task<IActionResult> UpdateLabelAsync(
            [FromBody] UpdateItemLabelRequest request
        )
        {
            return new OkObjectResult(new ApiResponse<int>()
            {
                Data = await _provider.UpdateLabel(request.ItemId, request.Label),
                Sucess = true,
                SuccessMessage = "Successfully retrieved all items for list"
            });
        }

        [HttpPatch("update_status")]
        public async Task<IActionResult> UpdateStatusAsync(
            [FromBody] UpdateItemStatusRequest request
        )
        {
            return new OkObjectResult(new ApiResponse<int>()
            {
                Data = await _provider.UpdateStatus(request.ItemId, request.Status),
                Sucess = true,
                SuccessMessage = "Successfully retrieved all items for list"
            });
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveAsync(
            [FromBody] int id
        )
        {
            return new OkObjectResult(new ApiResponse<bool>()
            {
                Data = await _provider.SoftDeleteAsync(id),
                Sucess = true,
                SuccessMessage = "Successfully retrieved all items for list"
            });
        }
    }
}
