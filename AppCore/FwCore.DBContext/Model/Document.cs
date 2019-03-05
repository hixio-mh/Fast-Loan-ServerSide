using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FwCore.DBContext.Model
{
   public class Document
    {
        public int Id { get; set; }

        //[Required]
        [StringLength(255)]
        public string FileName { get; set; }
    }
}
