using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Repositories;

namespace SistemaBeneficiarios.Infrastructure.Repositories;

public class DocumentoIdentidadRepository : IDocumentoIdentidadRepository
{
    private readonly string _connectionString;

    public DocumentoIdentidadRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

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

    public async Task<DocumentoIdentidad?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<DocumentoIdentidad>(
            "SELECT * FROM DocumentoIdentidad WHERE Id = @Id", 
            new { Id = id });
    }
}