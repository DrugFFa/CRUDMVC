using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SIBKMNET_WebAPP.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Pembaruan { get; set; }

        public Country()
        {
            Id = this.Id;
            Name = this.Name;
            Pembaruan = this.Pembaruan;
        }

        public Country(int id, string name, string pembaruan)
        {
            Id = id;
            Name = name;
            Pembaruan = pembaruan;
        }
    }
    


}
