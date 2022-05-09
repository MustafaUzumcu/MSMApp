public class CustomerType
{
    public int CustomerTypeId { get; set; }

    public string Name { get; set; }

    public float DiscountValue { get; set; }

    public List<Customer> Customers { get; set; }
}