using ElevaManageSchools.Entities;
using ElevaManageSchools.Infrastructure;
using ElevaManageSchools.Models;
using ElevaManageSchools.Services.Paging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ElevaManageSchools.Services
{
    public class ClassService : IClassService
    {
        private readonly ApplicationContext _context;

        public ClassService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Class>> Get(PagingParameters parameters)
        {
            return await _context.Classes
                .Include(x => x.School)
                .OrderByDescending(x => x.CreatedDate)
                .PaginateAsync(parameters.Page, parameters.Limit);
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
