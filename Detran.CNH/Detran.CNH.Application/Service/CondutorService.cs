using Detran.CNH.Application.Contract;
using Detran.CNH.Application.ViewModel.Request;
using Detran.CNH.Application.ViewModel.Response;
using Detran.CNH.Domain.Model;
using Detran.CNH.Domain.Contract.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Detran.CNH.Application.Service
{
    public class CondutorService : ICondutorService
    {
        private readonly IMapper mapper;
        private readonly ICondutorRepository condutorRepository;
        public CondutorService(ICondutorRepository condutorRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.condutorRepository = condutorRepository;
        }
        public async Task DeleteCondutor(int id)
        {
            var cond = await condutorRepository.Get(id);
            if (cond != null)
                condutorRepository.Delete(cond);
        }

        public async Task<CondutorViewModel> GetCondutor(int id)
        {
            return mapper.Map<CondutorViewModel>(await condutorRepository.Get(id));
        }

        public async Task<CondutorViewModel> GetCondutorByCPF(string cpf)
        {
            if (!CPFValido(cpf))
            {
                throw new Exception("CPF deve ter 11 dígitos.");
            }

            return mapper.Map<CondutorViewModel>(await condutorRepository.GetByCPF(cpf));
        }

        public async Task InsertCondutor(CondutorViewModelRequest model)
        {
            try
            {
                ValidaCondutor(model);
                await condutorRepository.Insert(mapper.Map<Condutor>(model));
            }
            catch
            {
                throw;
            }
        }

        private void ValidaCondutor(CondutorViewModelRequest model)
        {
            if (!string.IsNullOrEmpty(model.Email))
            {
                if (!IsValidEmail(model.Email))
                {
                    throw new Exception("E-mail inválido.");
                }
            }

            if (GetAge(model.DataNascimento) < 18)
            {
                throw new Exception("A idade do condutor não pode ser menor que 18 anos.");
            }

            if (!CPFValido(model.CPF))
            {
                throw new Exception("CPF deve ter 11 dígitos.");
            }
        }

        private bool CPFValido(string cpf)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(cpf, @"\d{11}");
        }

        private int GetAge(DateTime birthDate)
        {
            DateTime now = DateTime.Today;
            DateTime birthday = new DateTime(birthDate.Year, birthDate.Month, birthDate.Day);
            int age = now.Year - birthday.Year;
            if (now.Month < birthday.Month || (now.Month == birthday.Month && now.Day < birthday.Day)) 
                age--;
            return age;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<CondutorViewModel>> ListCondutores()
        {
            return mapper.Map<List<CondutorViewModel>>(await condutorRepository.List());
        }

        public async Task UpdateCondutor(int id, CondutorViewModelRequest model)
        {
            try
            {
                ValidaCondutor(model);
                var cond = await condutorRepository.Get(id);
                cond.Nome = model.Nome;
                cond.CPF = model.CPF;
                cond.Email = model.Email;
                cond.Telefone = model.Telefone;
                cond.CNH = model.CNH;
                cond.DataNascimento = model.DataNascimento;

                condutorRepository.Update(cond);
            }
            catch
            {
                throw;
            }
        }
    }
}
