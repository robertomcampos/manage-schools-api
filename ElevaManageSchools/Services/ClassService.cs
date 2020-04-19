using ElevaManageSchools.Entities;
using ElevaManageSchools.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevaManageSchools.Services
{
    public class ClassService : IClassService
    {
        private readonly ApplicationContext _context;
        public ClassService(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<ClassResponse> Get()
        {
            return _context.Classes.Select(x => new ClassResponse
            {
                Id = x.Id,
                Name = x.Name,
                School = x.School
            }).ToList();
        }

        public async Task<ClassResponse> Create(ClassRequest request)
        {
            var _class = await _context.Classes.AddAsync(new Class
            {
                SchoolId = request.SchoolId,
                Name = request.Name,
            });

            await _context.SaveChangesAsync();

            return new ClassResponse
            {
                Id = _class.Entity.Id,
                Name = _class.Entity.Name,
                School = _class.Entity.School
            };
        }
    }
}
