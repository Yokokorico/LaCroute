using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaCroute.Models
{
    public class ProductLabelModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }

        [ForeignKey("LabelModel")]
        public int LabelId { get; set; }

        public ProductModel Product { get; set; }
        public LabelModel Label { get; set; }
    }
}
