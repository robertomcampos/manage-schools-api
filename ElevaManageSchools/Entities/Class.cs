using System;
using System.ComponentModel.DataAnnotations;

namespace ElevaManageSchools.Entities
{
    public class Class
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid SchoolId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public School School { get; set; }
        public Class()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}

