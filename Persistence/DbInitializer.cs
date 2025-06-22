using System;
using Domain.Entities;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        if (context.Sellers.Any())
        {
            return;
        }

        var sellers = new List<Seller>
        {
            new() {
                SellerName = "Perico P"
            },
            new () {
                SellerName = "Zoila Baca"
            },
            new () {
                SellerName = "Aquiles C"
            },
            new () {
                SellerName = "Johny M"
            }
        };

         context.Sellers.AddRange(sellers);
         await context.SaveChangesAsync();

        if (context.Rules.Any())
        {
            return;
        }

        var rules = new List<Rule>
        {
            new(){
                RulePercentage = 0.1,
                MinimumAmount = 100
            },
            new(){
                RulePercentage = 0.2,
                MinimumAmount = 200
            },
            new(){
                RulePercentage = 0.3,
                MinimumAmount = 300
            },
            new(){
                RulePercentage = 0.4,
                MinimumAmount = 400
            },
        };

        context.Rules.AddRange(rules);
        await context.SaveChangesAsync();

         if (context.Sales.Any())
        {
            return;
        }

        var sales = new List<Sale>
        {
            new(){
                SalesDate = DateTime.UtcNow.AddMonths(3),
                TotalValue = 400,
                SellerId = sellers[0].Id,
                RuleId = rules[2].Id
            },
            new(){
                SalesDate = DateTime.UtcNow.AddMonths(3),
                TotalValue = 300,
                SellerId = sellers[0].Id,
                RuleId = rules[2].Id
            },
            new(){
                SalesDate = DateTime.UtcNow.AddMonths(2),
                TotalValue = 500,
                 SellerId = sellers[0].Id,
                RuleId = rules[2].Id
            },
            new(){
                SalesDate = DateTime.UtcNow.AddMonths(2),
                TotalValue = 500,
                 SellerId = sellers[1].Id,
                RuleId = rules[1].Id
            },
            new(){
                SalesDate = DateTime.UtcNow.AddMonths(2),
                TotalValue = 800,
                SellerId = sellers[1].Id,
                RuleId = rules[1].Id
            },
            new(){
                SalesDate = DateTime.UtcNow.AddDays(2),
                TotalValue = 200,
                 SellerId = sellers[2].Id,
                RuleId = rules[0].Id
            }
        };

       
        context.Sales.AddRange(sales);
        await context.SaveChangesAsync();
        
    }
}
