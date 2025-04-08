using CustomerBalance.API.DTO.Response;
using CustomerBalance.Shared.Model;

namespace CustomerBalance.API.Mappers
{
    public static class CustomerBalanceSummaryMapper
    {
        public static ICollection<CustomerBalanceSummaryResponse> FromCustomerLedgerList(IEnumerable<CustomerLedger> ledgerList)
        {
            return ledgerList
                .GroupBy(c => c.AN8)
                .Select(group => ToSummary(group))
                .ToList();
        }

        private static CustomerBalanceSummaryResponse ToSummary(IGrouping<int, CustomerLedger> group)
        {
            var balance = group
                .Where(c => c.AID == "O")
                .Sum(c => c.AG);

            return new CustomerBalanceSummaryResponse(group.Key, balance);
        }
    }
}
