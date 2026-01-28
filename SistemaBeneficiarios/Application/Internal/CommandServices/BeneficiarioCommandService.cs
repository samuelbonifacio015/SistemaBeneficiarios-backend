using SistemaBeneficiarios.Domain.Model.Commands;
using SistemaBeneficiarios.Domain.Repositories;
using SistemaBeneficiarios.Domain.Services;

namespace SistemaBeneficiarios.Application.Internal.CommandServices;

public class BeneficiarioCommandService : IBeneficiarioCommandService
    {
        private readonly IBeneficiarioRepository _beneficiarioRepository;
        private readonly IDocumentoIdentidadRepository _documentoRepository;
        private readonly IBeneficiarioDomainService _domainService; 

        public BeneficiarioCommandService(
            IBeneficiarioRepository beneficiarioRepository,
            IDocumentoIdentidadRepository documentoRepository,
            IBeneficiarioDomainService domainService)
        {
            _beneficiarioRepository = beneficiarioRepository;
            _documentoRepository = documentoRepository;
            _domainService = domainService;
        }

        public async Task<int> HandleCreateAsync(CreateBeneficiarioCommand command)
        {
            var documentoConfig = await _documentoRepository.GetByIdAsync(command.DocumentoIdentidadId);

            if (documentoConfig == null || !documentoConfig.Activo)
                throw new InvalidOperationException("El tipo de documento no existe o no está activo.");
            
            _domainService.ValidarDocumento(command.NumeroDocumento, documentoConfig);

            return await _beneficiarioRepository.CreateAsync(command);
        }

        public async Task<bool> HandleUpdateAsync(UpdateBeneficiarioCommand command)
        {
            var documentoConfig = await _documentoRepository.GetByIdAsync(command.DocumentoIdentidadId);
            
            if (documentoConfig == null)
                throw new InvalidOperationException("Documento no válido.");

            _domainService.ValidarDocumento(command.NumeroDocumento, documentoConfig);

            return await _beneficiarioRepository.UpdateAsync(command);
        }

        public async Task<bool> HandleDeleteAsync(int id)
        {
            return await _beneficiarioRepository.DeleteAsync(id);
        }
    }