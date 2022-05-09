public class Customer
{
    public int Id { get; set; }

    public string Username { get; set; }

    public int CustomerTypeId { get; set; }

    public CustomerType CustomerType { get; set; }
}