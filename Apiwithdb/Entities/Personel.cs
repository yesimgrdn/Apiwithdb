﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apiwithdb.Entities
{
    public class Personel
    {
        [Key]
        public int Id { get; set; }
        public string ?Name { get; set; }    
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City ?City { get; set; }
    }
}
