using ElevaManageSchools.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElevaManageSchools.Services
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolResponse>> Get();
        Task<SchoolResponse> Create(SchoolRequest school);
    }
}
