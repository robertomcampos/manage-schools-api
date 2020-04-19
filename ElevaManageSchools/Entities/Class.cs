using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevaManageSchools.Entities
{
    public class Class
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid SchoolId { get; set; }

        public School School { get; set; }
    }
}
