namespace BarberBoss.Application.UseCases.Reports.Excel;

public interface IGenerateExpenseReportExcelUseCase
{
    public Task<byte[]> Execute(DateOnly month);
}
