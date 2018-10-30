using System;
using System.ComponentModel.DataAnnotations;

namespace coreapi.Models
{
    public class Property
    {
        [Required]
        public int ID { get; set; }
        public int MlsDb { get; set; }
        [Required]
        public string MlsNumber { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
    }
}
