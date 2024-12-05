using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Requests;

public class AttendanceRequestJson
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Value {  get; set; }
    public DateTime Date { get; set; }
    public PaymentType PaymentType { get; set; }

}
