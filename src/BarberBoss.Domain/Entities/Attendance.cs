using BarberBoss.Domain.Enums;

namespace BarberBoss.Domain.Entities;

public class Attendance
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public PaymentType PaymentType { get; set; }
    public decimal Value { get; set; }
    public string? Description { get; set; }
}
