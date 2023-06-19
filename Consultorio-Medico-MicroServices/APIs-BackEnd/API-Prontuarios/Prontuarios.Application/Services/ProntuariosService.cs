﻿using Prontuarios.Application.InputModels;
using Prontuarios.Application.InterfaceServices;
using Prontuarios.Application.ViewModels;
using Prontuarios.Domain.Entities;
using Prontuarios.Infra.Repositories;

namespace Prontuarios.Application.Services
{
    public class ProntuariosService : IProntuariosService
    {
        private readonly HttpClient _httpClient;
        private readonly IProntuariosRepository _prontuariosRepository;

        public ProntuariosService(HttpClient httpClient, IProntuariosRepository prontuariosRepository)
        {
            _httpClient = httpClient;
            _prontuariosRepository = prontuariosRepository;
        }

        public async Task CriarProntuario2(ProntuariosInputModel model)
        {
            // Obter dados do médico da API externa
            var medicoResponse = await _httpClient.GetAsync($"https://localhost:7176/api/CadMedicos/{model.MedicoId}");
            if (!medicoResponse.IsSuccessStatusCode)
            {
                // Tratar erro ao obter os dados do médico
                return;
            }

            var medicoContent = await medicoResponse.Content.ReadAsStringAsync();
            var medicoId = medicoContent; // Armazena o ID do médico como string

            // Obter dados do paciente da API externa
            var pacienteResponse = await _httpClient.GetAsync($"https://localhost:7099/api/CadClientes/{model.PacienteId}");
            if (!pacienteResponse.IsSuccessStatusCode)
            {
                // Tratar erro ao obter os dados do paciente
                return;
            }

            var pacienteContent = await pacienteResponse.Content.ReadAsStringAsync();
            var pacienteId = pacienteContent; // Armazena o ID do paciente como string

            // Criar o prontuário com os dados obtidos
            var prontuario = new Prontuario(medicoId, pacienteId, model.TextoProntuario);

            // Persistir o prontuário no banco de dados
            _prontuariosRepository.Add(prontuario);
        }



        public Task<ProntuariosViewModel> CriarProntuarioPorId(ProntuariosInputModel model)
        {
            throw new NotImplementedException();
        }

        //public async Task CriarProntuario(ProntuariosInputModel model)
        //{
        //    // Obter dados do médico da API externa
        //    var medicoResponse = await _httpClient.GetAsync($"https://localhost:7176/api/CadMedicos/{model.MedicoId}");
        //    if (!medicoResponse.IsSuccessStatusCode)
        //    {
        //        // Tratar erro ao obter os dados do médico
        //        return;
        //    }

        //    var medicoContent = await medicoResponse.Content.ReadAsStringAsync();
        //    var medico = JsonConvert.DeserializeObject<CadMedicos>(medicoContent);

        //    // Obter dados do cliente da API externa
        //    var clienteResponse = await _httpClient.GetAsync($"https://localhost:7099/api/CadClientes/{model.PacienteId}");
        //    if (!clienteResponse.IsSuccessStatusCode)
        //    {
        //        // Tratar erro ao obter os dados do cliente
        //        return;
        //    }

        //    var clienteContent = await clienteResponse.Content.ReadAsStringAsync();
        //    var cliente = JsonConvert.DeserializeObject<CadClientes>(clienteContent);

        //    // Criar o prontuário apenas com os dados necessários
        //    var prontuario = new Prontuario(model.MedicoId, model.PacienteId, model.TextoProntuario);

        //    // Persistir o prontuário no banco de dados
        //    _prontuariosRepository.Add(prontuario);
        //}

        //public async Task<ProntuariosViewModel> CriarProntuarioPorId(ProntuariosInputModel model)
        //{
        //    // Obter dados do médico da API externa
        //    var medicoResponse = await _httpClient.GetAsync($"https://localhost:7176/api/CadMedicos/{model.Medico.Id}");
        //    if (!medicoResponse.IsSuccessStatusCode)
        //    {
        //        // Tratar erro ao obter os dados do médico
        //        return null;
        //    }

        //    var medicoContent = await medicoResponse.Content.ReadAsStringAsync();
        //    var medico = JsonConvert.DeserializeObject<CadMedicos>(medicoContent);

        //    // Obter dados do cliente da API externa
        //    var clienteResponse = await _httpClient.GetAsync($"https://localhost:7099/api/CadClientes/{model.Cliente.Id}");
        //    if (!clienteResponse.IsSuccessStatusCode)
        //    {
        //        // Tratar erro ao obter os dados do cliente
        //        return null;
        //    }

        //    var clienteContent = await clienteResponse.Content.ReadAsStringAsync();
        //    var cliente = JsonConvert.DeserializeObject<CadClientes>(clienteContent);

        //    // Criar o prontuário
        //    var prontuario = new Prontuario(medico, cliente, model.TextoProntuario);
        //    prontuario.Medico = medico;
        //    prontuario.Cliente = cliente;

        //    // Persistir o prontuário no banco de dados
        //    await _prontuariosRepository.Add(prontuario);

        //    // Mapear o prontuário para o ViewModel
        //    var viewModel = new ProntuariosViewModel
        //    {
        //        Id = prontuario.Id,
        //        IdPaciente = Guid.Parse(prontuario.Cliente.Id),
        //        NomePaciente = prontuario.Cliente.Nome,
        //        CPFPaciente = prontuario.Cliente.CPF,
        //        DataCriacaoPaciente = prontuario.Cliente.DataCriacao,
        //        IdMedico = Guid.Parse(prontuario.Medico.Id),
        //        NomeMedico = prontuario.Medico.Nome,
        //        CPFMedico = prontuario.Medico.CPF,
        //        EspecialidadeMedico = prontuario.Medico.Especialidade,
        //        TextoProntuario = prontuario.TextoProntuario
        //    };

        //    return viewModel;
        //}

        //public async Task<ProntuariosViewModel> CriarProntuarioPorNome(ProntuariosInputModel model)
        //{
        //    // Obter dados do médico da API externa
        //    var medicoResponse = await _httpClient.GetAsync($"https://localhost:7176/api/CadMedicos/{model.Medico.Nome}");
        //    if (!medicoResponse.IsSuccessStatusCode)
        //    {
        //        // Tratar erro ao obter os dados do médico
        //        return null;
        //    }

        //    var medicoContent = await medicoResponse.Content.ReadAsStringAsync();
        //    var medico = JsonConvert.DeserializeObject<CadMedicos>(medicoContent);

        //    // Obter dados do cliente da API externa
        //    var clienteResponse = await _httpClient.GetAsync($"https://localhost:7099/api/CadClientes/{model.Cliente.Nome}");
        //    if (!clienteResponse.IsSuccessStatusCode)
        //    {
        //        // Tratar erro ao obter os dados do cliente
        //        return null;
        //    }

        //    var clienteContent = await clienteResponse.Content.ReadAsStringAsync();
        //    var cliente = JsonConvert.DeserializeObject<CadClientes>(clienteContent);

        //    // Criar o prontuário
        //    var prontuario = new Prontuario(medico, cliente, model.TextoProntuario);

        //    // Persistir o prontuário no banco de dados
        //    await _prontuariosRepository.Add(prontuario);

        //    // Mapear o prontuário para o ViewModel
        //    var viewModel = new ProntuariosViewModel
        //    {
        //        Id = prontuario.Id,
        //        IdPaciente = Guid.Parse(prontuario.Cliente.Id),
        //        NomePaciente = prontuario.Cliente.Nome,
        //        CPFPaciente = prontuario.Cliente.CPF,
        //        DataCriacaoPaciente = prontuario.Cliente.DataCriacao,
        //        IdMedico = Guid.Parse(prontuario.Medico.Id),
        //        NomeMedico = prontuario.Medico.Nome,
        //        CPFMedico = prontuario.Medico.CPF,
        //        EspecialidadeMedico = prontuario.Medico.Especialidade,
        //        TextoProntuario = prontuario.TextoProntuario
        //    };

        //    return viewModel;
        //}


    }
}
