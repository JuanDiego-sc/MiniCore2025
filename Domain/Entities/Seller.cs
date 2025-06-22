using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Seller
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string SellerName { get; set; }
    public double Commission { get; set; }

    #region Relationships
    public ICollection<Sale> Sales { get; set; } = [];
    #endregion

}
