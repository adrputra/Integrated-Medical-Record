using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegratedMedicalRecord.Shared
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int PatientId { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }
        [JsonIgnore]
        public Hospital Hospital { get; set; }
    }
}
