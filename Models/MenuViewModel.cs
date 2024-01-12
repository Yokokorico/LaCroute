namespace LaCroute.Models
{
    public class MenuViewModel
    {
        public List<ProductModel> Products { get; set; }
        public List<TypeModel> Types { get; set; }
        public Dictionary<int, List<LabelModel>> ProductLabels { get; set; }
    }
}