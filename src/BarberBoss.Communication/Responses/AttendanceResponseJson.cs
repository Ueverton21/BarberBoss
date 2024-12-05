using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Responses;

public class AttendanceResponseJson
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime Data { get; set; }
    public PaymentType PaymentType { get; set; }
}
