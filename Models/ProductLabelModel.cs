using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LaCroute.Models
{
    public class ProductLabelModel
    {
        public int ProductId { get; set; }
        public int LabelId { get; set; }

        public ProductModel Product { get; set; }
        public LabelModel Label { get; set; }
    }
}
