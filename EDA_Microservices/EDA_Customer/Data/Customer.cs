namespace EDA_Customer.Data;

public class Customer
{
    public int id { get; set; }
    public string Name { get; set; }
    public Guid ProdcutID { get; set; }
    public int ItemInCart { get; set; }
}