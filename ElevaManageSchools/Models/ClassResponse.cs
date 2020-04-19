using ElevaManageSchools.Entities;
using System;

namespace ElevaManageSchools.Models
{
    public class ClassResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public School School { get; set; }
    }
}
