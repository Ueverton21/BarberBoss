
using AutoMapper;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Attendances;
using ClosedXML.Excel;

namespace BarberBoss.Application.UseCases.Reports.Excel;

public class GenerateReportExcelUseCase : IGenerateExpenseReportExcelUseCase
{
    private IGetAttendanceByMonth _repository;
    private IMapper _mapper;

    public GenerateReportExcelUseCase(IGetAttendanceByMonth repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<byte[]> Execute(DateOnly date)
    {
        var att = await _repository.GetByMonth(date);

        XLWorkbook workbook = new XLWorkbook();

        var worksheet = workbook.AddWorksheet("Atendimentos");

        GenerateNameColums(worksheet);

        if (att != null) {
            PopuleReport(att, worksheet);
        }
        worksheet.Columns().AdjustToContents();

        var file = new MemoryStream();

        workbook.SaveAs(file);

        return file.ToArray();
    }

    private void GenerateNameColums(IXLWorksheet sheet)
    {
        sheet.Cell("A1").Value = "Título";
        sheet.Cell("B1").Value = "Descrição";
        sheet.Cell("C1").Value = "Tipo de pagamento";
        sheet.Cell("D1").Value = "Valor";
        sheet.Cell("E1").Value = "Data";

        SetStyles(sheet);
    }

    private void PopuleReport(List<Attendance> attendances, IXLWorksheet sheet)
    {
        var i = 2;
        foreach (Attendance attendance in attendances) {
            sheet.Cell($"A{i}").Value = attendance.Title;
            sheet.Cell($"B{i}").Value = attendance.Description;
            sheet.Cell($"C{i}").Value = attendance.PaymentType.ToString();
            sheet.Cell($"D{i}").Value = attendance.Value;
            sheet.Cell($"E{i}").Value = attendance.Date;
            i++;
        }
    }

    private void SetStyles(IXLWorksheet sheet)
    {
        sheet.Cells("A1:E1").Style.Fill.SetBackgroundColor(XLColor.Coral);
    }
}
