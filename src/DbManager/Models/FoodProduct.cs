using System.ComponentModel.DataAnnotations.Schema;

namespace DbManager.Models
{
    public class FoodProduct
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid MiId { get; set; }
        public string MiCategory { get; set; }
        public byte[] MiImage { get; set; }
        public string MiName { get; set; }
        public float MiPrice { get; set; }
    }
}
