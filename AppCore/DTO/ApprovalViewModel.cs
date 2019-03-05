using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ApprovalViewModel
    {
        public string OperateBy { get; set; }
        public string ApproveBy { get; set; }
        public string Status { get; set; }
        public DateTime IssueDate { get; set; }
        public int ApplicationId { get; set; }
    }

       
}
