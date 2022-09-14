using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResTask.Model
{
    [Table(name:"Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int OrderId { get; set; }

        [Required]

        public string CustomerName { get; set; }

        [Required]
        [DefaultValue(1)]
        public short Quantity { get; set; }

        #region Navigation Properties to the Menu Model

        [Required]
        public int DishName { get; set; }

        [ForeignKey(nameof(Order.DishName))]
        public Menu Menu { get; set; }

        #endregion



    }
}
