using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResTask.Model
{
    [Table(name:"Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Name of the Category")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        #region Navigation Properties to the Book Model

        public ICollection<Menu> Menu { get; set; }

        #endregion
    }
}
