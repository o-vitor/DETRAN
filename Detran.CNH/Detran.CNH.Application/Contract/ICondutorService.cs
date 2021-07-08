using Detran.CNH.Application.ViewModel.Request;
using Detran.CNH.Application.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Detran.CNH.Application.Contract
{
    public interface ICondutorService
    {
        Task<CondutorViewModel> GetCondutor(int id);
        Task<CondutorViewModel> GetCondutorByCPF(string cpf);
        Task InsertCondutor(CondutorViewModelRequest entity);
        Task UpdateCondutor(int id, CondutorViewModelRequest entity);
        Task DeleteCondutor(int id);
        Task<List<CondutorViewModel>> ListCondutores();
    }
}
