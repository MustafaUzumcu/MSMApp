public class Invoice
{
    public int Id { get; set; }

    public float Total { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public List<InvoiceDetail> InvoiceDetails { get; set; }
}