using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedMedicalRecord.Shared
{
    public class DoctorAccount
    {
        [ForeignKey("Doctor")]
        public int Id { get; set; }
        public string Password { get; set; } = string.Empty;
        public int OTP { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpiredToken { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
