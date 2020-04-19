using ElevaManageSchools.Entities;
using ElevaManageSchools.Infrastructure;
using ElevaManageSchools.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<IEnumerable<ClassResponse>> Get()
        {

            return await _context.Classes.OrderByDescending(x => x.CreatedDate).Select(x => new ClassResponse
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                School = x.School
            }).ToListAsync();

        }

        public async Task<ClassResponse> Create(ClassRequest request)
        {
            try
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
                    CreatedDate = _class.Entity.CreatedDate,
                    School = _class.Entity.School
                };
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message);
            }
        }
    }
}
