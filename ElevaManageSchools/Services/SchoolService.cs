using ElevaManageSchools.Entities;
using ElevaManageSchools.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevaManageSchools.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ApplicationContext _context;
        public SchoolService(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<SchoolResponse> Get()
        {
            return _context.Schools.Select(x => new SchoolResponse
            {
                Address = x.Address,
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public async Task<SchoolResponse> Create(SchoolRequest request)
        {
            var _scholl = await _context.Schools.AddAsync(new School { 
                Name = request.Name,
                Address = request.Address
            });

            await _context.SaveChangesAsync();

            return new SchoolResponse
            {
                Id = _scholl.Entity.Id,
                Name = _scholl.Entity.Name,
                Address = _scholl.Entity.Address
            };
        }
    }
}
