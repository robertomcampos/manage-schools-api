using ElevaManageSchools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevaManageSchools.Services
{
    public interface IClassService
    {
        Task<IEnumerable<ClassResponse>> Get();
        Task<ClassResponse> Create(ClassRequest _class);
    }
}
