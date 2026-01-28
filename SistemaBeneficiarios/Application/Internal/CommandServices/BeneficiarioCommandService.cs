using SistemaBeneficiarios.Domain.Model.Commands;
using SistemaBeneficiarios.Domain.Repositories;
using SistemaBeneficiarios.Domain.Services;

namespace SistemaBeneficiarios.Application.Internal.CommandServices;

/// <summary>
/// CommandServices para Beneficiario
/// Implementa la lógica para crear, actualizar y eliminar beneficiarios.
/// </summary>
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

        /// <summary>
        /// Maneja el comando de creación de un nuevo beneficiario.
        /// </summary>
        /// <param name="command">Comando que contiene los datos del beneficiario a crear.</param>
        /// <returns>El ID del nuevo beneficiario creado.</returns>
        /// <remarks>
        /// </remarks>
        public async Task<int> HandleCreateAsync(CreateBeneficiarioCommand command)
        {
            var documentoConfig = await _documentoRepository.GetByIdAsync(command.DocumentoIdentidadId);

            if (documentoConfig == null || !documentoConfig.Activo)
                throw new InvalidOperationException("El tipo de documento no existe o no está activo.");
            
            _domainService.ValidarDocumento(command.NumeroDocumento, documentoConfig);

            return await _beneficiarioRepository.CreateAsync(command);
        }

        /// <summary>
        /// Maneja el comando de actualización de un beneficiario existente.
        /// </summary>
        /// <param name="command">Comando con los datos actualizados del beneficiario.</param>
        /// <returns>True si la actualización fue exitosa, false en caso contrario.</returns>
        /// <remarks>
        /// Valida la existencia del tipo de documento y vuelve a validar el formato del número de documento.
        /// </remarks>
        public async Task<bool> HandleUpdateAsync(UpdateBeneficiarioCommand command)
        {
            var documentoConfig = await _documentoRepository.GetByIdAsync(command.DocumentoIdentidadId);
            
            if (documentoConfig == null)
                throw new InvalidOperationException("Documento no válido.");

            _domainService.ValidarDocumento(command.NumeroDocumento, documentoConfig);

            return await _beneficiarioRepository.UpdateAsync(command);
        }

        /// <summary>
        /// Maneja el comando para eliminar un beneficiario por su ID.
        /// </summary>
        /// <param name="id">El identificador único del beneficiario a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa, false de lo contrario.</returns>
        public async Task<bool> HandleDeleteAsync(int id)
        {
            return await _beneficiarioRepository.DeleteAsync(id);
        }
    }