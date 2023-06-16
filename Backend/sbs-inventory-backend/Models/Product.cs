public class Product
{
    public int ProductID { get; set; }
    public int SbsID { get; set; }
    public int NcrID { get; set; }
    public string ProductDescription { get; set; }
    // public int MakeID { get; set; }
    public int ModelID { get; set; }
    public int Counts { get; set; }
    public decimal Price { get; set; }
    public decimal Cost { get; set; }
    public bool AdvEA { get; set; }
    public bool Discontinued { get; set; }
    public int LocationID { get; set; }
    public int StatusID { get; set; }
    public string Source { get; set; }
    public string? LocationName { get; set; }
    public string? StatusName { get; set; }
    public int? EmployeeID { get; set; }
}
