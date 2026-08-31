namespace FinalApi.DTOS
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Qty { get; set; }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}
