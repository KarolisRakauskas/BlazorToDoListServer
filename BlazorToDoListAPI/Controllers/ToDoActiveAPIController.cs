using BlazorToDoListAPI.Models;
using BlazorToDoListAPI.Repository.IRepository;
using BlazorToDoListLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlazorToDoListAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ToDoActiveAPIController : Controller
	{
		private readonly APIResponse _response;
		private readonly IToDoActiveRepository _context;

		public ToDoActiveAPIController(IToDoActiveRepository context)
		{
			this._response = new();
			_context = context;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<APIResponse>> GetToDoActive()
		{
			try
			{
				IEnumerable<ToDoActive> toDoActives = await _context.GetAllAsync();
				_response.Result = toDoActives;
				_response.StatusCode = HttpStatusCode.OK;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return _response;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<APIResponse>> GetOneToDoActive(int id)
		{
			if (id == 0)
			{
				_response.StatusCode = HttpStatusCode.BadRequest;
				return BadRequest(_response);
			}

			try
			{
				ToDoActive toDoActive = await _context.GetAsync(id);

				if (toDoActive == null)
				{
					_response.StatusCode = HttpStatusCode.NotFound;
					return NotFound(_response);
				}

				_response.Result = toDoActive;
				_response.StatusCode = HttpStatusCode.OK;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}

			return _response;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<APIResponse>> CreateToDoActive([FromBody] ToDoActive toDoActive)
		{
			try
			{
				if (toDoActive == null)
				{
					return BadRequest(toDoActive);
				}

				toDoActive.DateTimeCreate = DateTime.Now;

				await _context.CreateAsync(toDoActive);

				_response.Result = toDoActive;
				_response.StatusCode = HttpStatusCode.Created;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<APIResponse>> DeleteToDoActive(int id)
		{
			var toDoActive = await _context.GetAsync(id);

			try
			{
				if (id == 0)
				{
					_response.StatusCode = HttpStatusCode.BadRequest;
					return BadRequest(_response);
				}
				else if (toDoActive == null)
				{
					_response.StatusCode = HttpStatusCode.NotFound;
					return NotFound(_response);
				}

				await _context.DeleteAsync(toDoActive);

				_response.StatusCode = HttpStatusCode.NoContent;
				_response.IsSuccess = true;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] ToDoActive toDoActive)
		{
			try
			{
				if (toDoActive == null || id != toDoActive.Id)
				{
					_response.StatusCode = HttpStatusCode.BadRequest;
					return BadRequest(_response);
				}

				await _context.UpdateAsync(toDoActive);

				_response.StatusCode = HttpStatusCode.NoContent;
				_response.IsSuccess = true;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}
	}
}
