using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FwCore.DBContext.Model
{
    public class CommonEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public long DisplayOrder { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsHidden { get; set; }
        public bool IsParmanent { get; set; }
    }
}
