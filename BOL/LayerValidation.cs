using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BOL
{
   public class LayerValidation
    {

     
        public string fileName { get; set; }

        [Display(Name = "Titre")]
        [Required]
        public string title { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string description { get; set; }

        public System.DateTime dateAdded { get; set; }
        [Display(Name = "Catégorie")]
        [Required]
        public int categoryId { get; set; }

        [Display(Name = "Type")]
        [Required]
        public int layerTypeId { get; set; }

      
        public System.DateTime validFrom { get; set; }

        public System.DateTime validTo { get; set; }

        public string imageName { get; set; }
    }



    [MetadataType(typeof(LayerValidation))]
    public partial class tbl_LAYER
    {


    }
}
