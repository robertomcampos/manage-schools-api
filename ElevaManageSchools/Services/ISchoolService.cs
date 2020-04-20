using ElevaManageSchools.Entities;
using ElevaManageSchools.Models;
using ElevaManageSchools.Services.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElevaManageSchools.Services
{
    public interface ISchoolService
    {
        Task<PagedList<School>> Get(PagingParameters parameters);
        Task<IEnumerable<School>> Get();
        Task<SchoolResponse> Create(SchoolRequest school);
    }
}
