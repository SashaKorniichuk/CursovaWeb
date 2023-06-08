using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursovaBackend.Entities
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public float TotalPrice { get; set; }
        public IEnumerable<ProductCart> ProductCarts { get; set; }
    }
}
