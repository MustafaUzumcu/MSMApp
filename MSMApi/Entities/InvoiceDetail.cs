public class InvoiceDetail
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    public int ProductId { get; set; }

    public int ProductCategory { get; set; }

    public float ProductPrice { get; set; }

    public float Discount { get; set; }
}