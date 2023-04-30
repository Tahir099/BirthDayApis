using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace BirthDay.Model
{
    [Table("user_")]
    public class User
    {
        [Key]
        public int id { get; set; } 
        public string name_ { get; set; }
        public string surname_ { get; set; }
        public string photo_ { get; set; }
        public DateTime birthdate { get; set; }
    }
}
