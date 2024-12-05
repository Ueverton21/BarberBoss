using BarberBoss.Application.UseCases.Attendances.Create;
using BarberBoss.Application.UseCases.Attendances.Delete;
using BarberBoss.Application.UseCases.Attendances.GetAll;
using BarberBoss.Application.UseCases.Attendances.GetById;
using BarberBoss.Application.UseCases.Attendances.Update;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AttendanceController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AttendanceResponseJson),StatusCodes.Status201Created)]
    public async Task<IActionResult> Add(
        [FromServices]ICreateAttendanceUseCase useCaseCreate, 
        [FromBody] AttendanceRequestJson request)
    {

        return Created(string.Empty, await useCaseCreate.Execute(request));
    }
    [HttpGet]
    [ProducesResponseType(typeof(List<AttendanceResponseJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll([FromServices] IGetAllAttendanceUseCase useCaseGetAll)
    {
        var attendances = await useCaseGetAll.Execute();

        if (attendances.Count == 0)
        {
            return NoContent();
        }

        return Ok(attendances);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AttendanceResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromRoute] int id,
        [FromServices] IGetByIdAttendanceUseCase useCaseGetId)
    {
        var attendance = await useCaseGetId.Execute(id);

        return Ok(attendance);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(
        [FromRoute] int id,
        [FromServices] IUpdateAttendanceUseCase useCaseUpdate,
        [FromBody] AttendanceRequestJson request)
    {
        await useCaseUpdate.Execute(id,request);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromRoute] int id,
        [FromServices] IDeleteAttendanceUseCase useCaseDelete)
    {
        await useCaseDelete.Execute(id);

        return NoContent();
    }
}
