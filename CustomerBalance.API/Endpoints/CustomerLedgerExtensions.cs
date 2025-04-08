using CustomerBalance.API.DTO.Response;
using CustomerBalance.API.Mappers;
using CustomerBalance.Shared.Data.Data;
using CustomerBalance.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CustomerBalance.API.Endpoints;

public static class CustomerLedgerExtensions
{
    public static void AddEndPointsCustomerLedger(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("customer-ledger")
            .WithTags("CustomerLedger");
        #region Endpoint CustomerLedger

        groupBuilder.MapGet("", ([FromServices] DAL<CustomerLedger> dalCustomerLedger) =>
        {
            var customersList = dalCustomerLedger.Listar();

            if (customersList is null)
            {
                return Results.NotFound();
            }

            var response = CustomerLedgerMapper.FromEntityList(customersList);
            return Results.Ok(response);
        }).WithSummary("List all Customers");

        groupBuilder.MapGet("balance/{an8}", ([FromServices] DAL<CustomerLedger> dalCustomerLedger, int an8) =>
        {
            var customerLedgerListByAN8 = dalCustomerLedger.GetListByFilter(c => c.AN8 == an8);
            if (customerLedgerListByAN8.IsNullOrEmpty())
            {
                return Results.NotFound();
            }
            
            var balance = customerLedgerListByAN8
                .Where(c => c.AID == "O")
                .Sum(c => c.AG);

            var response = CustomerBalanceSummaryMapper.FromCustomerLedgerToBalanceResponse(an8, customerLedgerListByAN8);
            return Results.Ok(response);
        }).WithSummary("Balance Rule: the total balance is the sum of all AG values where AID equals 'O'");

        groupBuilder.MapGet("balance-summary", ([FromServices] DAL<CustomerLedger> dalCustomerLedger) =>
        {
            var customerLedgers = dalCustomerLedger.Listar();

            if (customerLedgers.IsNullOrEmpty())
            {
                return Results.NotFound();
            }

            var summaryList = CustomerBalanceSummaryMapper.FromCustomerLedgerList(customerLedgers);
            return Results.Ok(summaryList);
        }).WithSummary("List balance summary per AN8, considering only AID = 'O'");
        #endregion
    }
}
