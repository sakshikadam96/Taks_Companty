using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Models
{
    public class db_table1
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Required")]
        public int ProductName { get; set; }


        [Required(ErrorMessage = "Required")]
        [Display(Name ="Table2")]
        public int CategoryId{ get; set; }

        [NotMapped]
        public string Table2 { get; set; }




    }
}
