using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegratedMedicalRecord.Shared
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ChiefId { get; set; }
        [JsonIgnore]
        public List<Doctor> Doctors { get; set; }
    }
}
