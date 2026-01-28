using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Repositories;

namespace SistemaBeneficiarios.Infrastructure.Repositories;

/// <summary>
/// Repositorio de infraestructura para gestionar los tipos de documentos de identidad.
/// </summary>
public class DocumentoIdentidadRepository : IDocumentoIdentidadRepository
{
    private readonly string _connectionString;

    public DocumentoIdentidadRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    /// <summary>
    /// Obtiene la lista de documentos de identidad.
    /// </summary>
    /// <param name="soloActivos">Si es true, ejecuta un SP para filtrar activos. Si es false, trae todos mediante SQL directo.</param>
    /// <returns>Colección de documentos de identidad.</returns>
    public async Task<IEnumerable<DocumentoIdentidad>> GetAllAsync(bool soloActivos)
    {
        using var connection = new SqlConnection(_connectionString);
            
        if (soloActivos)
        {
            return await connection.QueryAsync<DocumentoIdentidad>(
                "sp_GetActiveDocumentosIdentidad",
                commandType: CommandType.StoredProcedure
            );
        }
        else
        {
            return await connection.QueryAsync<DocumentoIdentidad>("SELECT * FROM DocumentoIdentidad");
        }
    }

    /// <summary>
    /// Busca un tipo de documento por su ID.
    /// </summary>
    /// <param name="id">ID del documento.</param>
    /// <returns>El documento encontrado o null.</returns>
    public async Task<DocumentoIdentidad?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<DocumentoIdentidad>(
            "SELECT * FROM DocumentoIdentidad WHERE Id = @Id", 
            new { Id = id });
    }
}