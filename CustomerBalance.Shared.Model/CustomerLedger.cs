namespace CustomerBalance.Shared.Model;

public class CustomerLedger
{
    public int AN8 { get; set; }       // Address Number (Customer ID)
    public string DCT { get; set; }    // Document Type
    public int DOC { get; set; }       // Document Number
    public string DTR { get; set; }    // Document Date (usually in string/Julian format)
    public string DVJ { get; set; }    // Due Date
    public string AID { get; set; }    // Payment Instrument (e.g., "O", "P", "1")
    public decimal AG { get; set; }    // Document Amount (Original Amount)
    public decimal AAP { get; set; }   // Amount Paid
    public decimal AAR { get; set; }   // Amount Remaining
}
