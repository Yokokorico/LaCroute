using Microsoft.CodeAnalysis.CSharp.Formatting;

namespace LaCroute.Models
{
    public class MenuViewModel
    {
        public IEnumerable<TypeModel> Types { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
        public IEnumerable<LabelModel> Labels { get; set; }
    }
}