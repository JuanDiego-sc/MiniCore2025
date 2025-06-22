using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Sale
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime SalesDate { get; set; }
    public double TotalValue { get; set; }

    #region Relationships
    public string? SellerId { get; set; }
    public Seller? Seller { get; set; } = null!;
    public string? RuleId { get; set; }
    public Rule? Rule { get; set; } = null!;

    #endregion
}
