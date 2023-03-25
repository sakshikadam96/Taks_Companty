using System.ComponentModel.DataAnnotations;

namespace Product.Models
{
    public class Table2
    {

        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Required")]
        public int db_table1 { get; set; }
    }
}
