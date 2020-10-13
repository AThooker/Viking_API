using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Viking_API.Models
{
    public enum Job
    {
        Raider,
        Blacksmith,
        Farmer,
        King,
        Queen,
        Slave
    }
    public class Viking
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Tribe { get; set; }
        [Required]
        public Job Job { get; set; }
    }
}