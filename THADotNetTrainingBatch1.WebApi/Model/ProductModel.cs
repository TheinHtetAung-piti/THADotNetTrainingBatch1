namespace THADotNetTrainingBatch1.WebApi.Model
{
    public class ProductModel
    {
        public int ProductId { get; set; }  

        public string ProductCode { get; set; }

        public string ProductName { get; set; }  

        public string ProductCategory { get; set; } 

        public double Price { get; set; }   

        public int Quantity { get; set; }   

        public DateTime CreateDateTime { get; set; }    

        public int CreatedBy { get; set; }  

        public DateTime ModifiedDateTime { get; set; }  

        public int ModifiedBy { get; set; } 

    }
}
