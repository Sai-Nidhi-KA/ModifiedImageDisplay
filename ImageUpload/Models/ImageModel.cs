using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageUpload.Models
{
    public class ImageModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("Upload Photo")]
        public byte[] Photo { get; set; }


    }
}