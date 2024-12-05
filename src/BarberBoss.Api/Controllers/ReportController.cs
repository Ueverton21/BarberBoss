using BarberBoss.Application.UseCases.Reports.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BarberBoss.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    [HttpGet("excel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetExcel(
        [FromServices]IGenerateExpenseReportExcelUseCase useCase, 
        [FromQuery]string month)
    {
        var file = await useCase.Execute(DateOnly.Parse(month));

        return File(file, MediaTypeNames.Application.Octet, "report_attendance.xlsx");
    }
}
