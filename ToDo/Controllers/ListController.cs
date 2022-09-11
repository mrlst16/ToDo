using Common.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ToDo.Interfaces;
using ToDo.Models;
using ToDo.Models.Requests;

namespace ToDo.Controllers
{
    [ApiController]
    [Route("api/list")]
    public class ListController : Controller
    {
        private readonly IToDoListProvider _provider;
        private readonly IValidator<CreateListRequest> _createListValidator;

        //Add a list
        //    b.Get all lists

        public ListController(
            IToDoListProvider provider,
            IValidator<CreateListRequest> createListValidator
            )
        {
            _provider = provider;
            _createListValidator = createListValidator;
        }

        /// <summary>
        /// Creates a list for the user
        /// </summary>
        /// <param name="request"></param>
        /// <returns>integer representing the id of the list</returns>
        /// <remarks>
        /// Sample Request:
        ///     {
        ///         "UserId":"1",
        ///         "Label": "Workout"
        ///     }
        /// </remarks>
        [HttpPost("create")]
        public async Task<IActionResult> CreateListAsync([FromBody] CreateListRequest request)
        {
            await _createListValidator.ValidateAndThrowAsync(request);
            var list = new ToDoList()
            {
                Id = default(int),
                UserId = request.UserId,
                Label = request.Label
            };
            var result = new ApiResponse<int>()
            {
                Data = await _provider.SaveAsync(list),
                Success = true,
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
                Success = true,
                SuccessMessage = "Successfully retrieved all lists for user"
            });
        }
    }
}
