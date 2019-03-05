using System;
using System.Collections.Generic;
using System.Text;

namespace FwCore.DBContext.Model
{
    public class VerificationSource
    {
        public int VerificationSourceId { get; set; }

        public string VerificationType { get; set; }

        public string VerificationCode { get; set; }

    }
}
