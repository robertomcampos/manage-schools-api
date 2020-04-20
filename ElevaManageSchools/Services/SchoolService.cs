using ElevaManageSchools.Entities;
using ElevaManageSchools.Infrastructure;
using ElevaManageSchools.Models;
using ElevaManageSchools.Services.Paging;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<PagedList<School>> Get(PagingParameters parameters)
        {
            return await _context.Schools.OrderByDescending(x => x.CreatedDate).PaginateAsync(parameters.Page, parameters.Limit);
        }

        public async Task<IEnumerable<School>> Get()
        {
            return await _context.Schools.OrderByDescending(x => x.CreatedDate).ToListAsync();
        }

        public async Task<SchoolResponse> Create(SchoolRequest request)
        {
            try
            {
                var _scholl = await _context.Schools.AddAsync(new School
                {
                    Name = request.Name,
                    Address = request.Address
                });

                await _context.SaveChangesAsync();

                return new SchoolResponse
                {
                    Id = _scholl.Entity.Id,
                    Name = _scholl.Entity.Name,
                    Address = _scholl.Entity.Address,
                    CreatedDate = _scholl.Entity.CreatedDate
                };
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message);
            }
        }
    }
}
