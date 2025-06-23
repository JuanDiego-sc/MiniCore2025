using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Services;

public class CalculateCommissionsService(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<List<Seller>> CommissionsPerSeller(DateTime startDate, DateTime endDate)
    {
        var allSellers = await _context.Sellers.ToListAsync();
        
        foreach (var seller in allSellers)
        {
            seller.Commission = 0;
        }
        
        var sales = await _context.Sales
            .Where(sa => sa.SalesDate >= startDate && sa.SalesDate <= endDate)
            .Select(s => new 
            {
            s.SellerId,
            s.RuleId,
            s.Rule,
            s.TotalValue
            })
            .ToListAsync();

        foreach (var sale in sales)
        {
            if (sale.SellerId != null && sale.RuleId != null)
            {
                double commission = sale.TotalValue * sale.Rule.RulePercentage;
                
                var seller = allSellers.FirstOrDefault(s => s.Id == sale.SellerId);
                if (seller != null)
                {
                    seller.Commission += commission;
                }
            }
        }

        return allSellers;
    }
}


