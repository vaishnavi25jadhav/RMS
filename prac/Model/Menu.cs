using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ResTask.Model
{
    [Table(name:"Menus")]
    public class Menu
    {
        [Key]
        [Required]

        virtual public int DishId { get; set; }

        [Required]
        [StringLength(50)]

        virtual public string DishName { get; set; }

        [Required]

        virtual public short DishPrice { get; set; }

        [Required]
        [DefaultValue(false)]
        virtual public bool IsEnabled { get; set; }

        #region Navigation Properties to the Category Model

        virtual public int CategoryName { get; set; }
        [System.Text.Json.Serialization.JsonIgnore] //[Newtonsoft.Json.JsonIgnore]
        [ForeignKey(nameof(Menu.CategoryName))]

        public Category Category { get; set; }

        #endregion

        #region Navigation Properties to the Author Model
        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }

        #endregion

    }
}
