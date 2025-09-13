namespace GraphQLPOC.Model;
// Models/Medicine.cs
public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpiryDate { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}


// Models/MedicineInput.cs
public class MedicineInput
{
    public string Name { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpiryDate { get; set; }
}


public class MedicineUpdateInput
{
    public string? Name { get; set; }
    public string? Company { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
    public DateTime? ExpiryDate { get; set; }
}