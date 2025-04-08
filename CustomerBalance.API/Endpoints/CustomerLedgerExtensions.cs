using CustomerBalance.API.Response;
using CustomerBalance.Shared.Data.Data;
using CustomerBalance.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CustomerBalance.API.Endpoints;

public static class CustomerLedgerExtensions
{
    public static void AddEndPointsCustomerLedger(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("customerledger")
            .WithTags("CustomerLedger");
        #region Endpoint CustomerLedger

        groupBuilder.MapGet("", ([FromServices] DAL<CustomerLedger> dalCustomerLedger) =>
        {
            var customersList = dalCustomerLedger.Listar();

            if (customersList is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(EntityListToResponseList(customersList));
        }).WithSummary("List all Customers");

        groupBuilder.MapGet("balance/{id}", ([FromServices] DAL<CustomerLedger> dalCustomerLedger, int id) =>
        {
            var customerLedgerListByAN8 = dalCustomerLedger.GetListByFilter(c => c.AN8 == id);
            if (customerLedgerListByAN8.IsNullOrEmpty())
            {
                return Results.NotFound();
            }
            var balance = customerLedgerListByAN8.Where(c => c.AID == "O").Sum(c => c.AG);

            return Results.Ok(EntityListAndBalanceToResponseBalance(customerLedgerListByAN8, balance));
        }).WithSummary("Balance Rule: the total balance is the sum of all AG values where AID equals 'O'");

        #endregion
    }
    private static CustomerLedgerBalanceResponse EntityListAndBalanceToResponseBalance(IEnumerable<CustomerLedger> ledgerList, decimal balance)
    {
        return new CustomerLedgerBalanceResponse(ledgerList.First().AN8, balance);
    }

    private static ICollection<CustomerLedgerResponse> EntityListToResponseList(IEnumerable<CustomerLedger> listaDeAnimes)
    {
        return listaDeAnimes.Select(a => EntityToResponse(a)).ToList();
    }

    private static CustomerLedgerResponse EntityToResponse(CustomerLedger customerLedger)
    {
        return new CustomerLedgerResponse(customerLedger.AN8, customerLedger.DCT, customerLedger.DOC, customerLedger.DTR, customerLedger.DVJ, customerLedger.AID, customerLedger.AG, customerLedger.AAP, customerLedger.AAR);
    }
}
