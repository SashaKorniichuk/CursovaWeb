using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursovaBackend.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id {get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string ImageName { get; set; }
        public IEnumerable<ProductCart> ProductCarts { get; set; }
    }
}
