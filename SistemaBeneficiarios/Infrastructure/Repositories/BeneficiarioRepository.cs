using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Model.Commands;
using SistemaBeneficiarios.Domain.Repositories;

namespace SistemaBeneficiarios.Infrastructure.Repositories;

public class BeneficiarioRepository : IBeneficiarioRepository
{
    private readonly string _connectionString;

    public BeneficiarioRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<int> CreateAsync(CreateBeneficiarioCommand command)
    {
        using var connection = new SqlConnection(_connectionString);
        
        return await connection.QuerySingleAsync<int>(
            "sp_InsertBeneficiario", 
            new
            {
                command.Nombres,
                command.Apellidos,
                command.DocumentoIdentidadId,
                command.NumeroDocumento,
                command.FechaNacimiento,
                command.Sexo
            },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<Beneficiario>> GetAllAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        
        var result = await connection.QueryAsync<Beneficiario>(
            "sp_GetBeneficiarios", 
            commandType: CommandType.StoredProcedure);

        return result;
    }

    public async Task<bool> UpdateAsync(UpdateBeneficiarioCommand command)
    {
        using var connection = new SqlConnection(_connectionString);
        var rows = await connection.ExecuteAsync("sp_EditarBeneficiario", command, commandType: CommandType.StoredProcedure);
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var rows = await connection.ExecuteAsync("sp_EliminarBeneficiario", new { Id = id }, commandType: CommandType.StoredProcedure);
        return rows > 0;
    }

    public async Task<Beneficiario?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        string sql = "SELECT * FROM Beneficiario WHERE Id = @Id";
        return await connection.QueryFirstOrDefaultAsync<Beneficiario>(sql, new { Id = id });
    }
}