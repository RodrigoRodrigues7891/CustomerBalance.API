using CustomerBalance.API.DTO.Response;
using CustomerBalance.Shared.Model;

namespace CustomerBalance.API.Mappers
{
    public static class CustomerLedgerMapper
    {
        public static ICollection<CustomerLedgerResponse> FromEntityList(IEnumerable<CustomerLedger> ledgers)
        {
            return ledgers.Select(FromEntity).ToList();
        }

        public static CustomerLedgerResponse FromEntity(CustomerLedger ledger)
        {
            return new CustomerLedgerResponse(
                ledger.AN8,
                ledger.DCT,
                ledger.DOC,
                ledger.DTR,
                ledger.DVJ,
                ledger.AID,
                ledger.AG,
                ledger.AAP,
                ledger.AAR
            );
        }
    }
}
