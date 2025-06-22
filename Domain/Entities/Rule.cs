using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Rule
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public double RulePercentage { get; set; }
    public double MinimumAmount { get; set; }

    #region Relationships
    public ICollection<Sale> Sales { get; set; } = [];
    #endregion
}
