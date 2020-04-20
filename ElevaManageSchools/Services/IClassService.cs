using ElevaManageSchools.Entities;
using ElevaManageSchools.Models;
using ElevaManageSchools.Services.Paging;
using System.Threading.Tasks;

namespace ElevaManageSchools.Services
{
    public interface IClassService
    {
        Task<PagedList<Class>> Get(PagingParameters parameters);
        Task<ClassResponse> Create(ClassRequest _class);
    }
}
