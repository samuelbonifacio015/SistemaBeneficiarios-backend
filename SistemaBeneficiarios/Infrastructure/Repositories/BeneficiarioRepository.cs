using System.Data;
using Dapper;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Model.Commands;
using SistemaBeneficiarios.Domain.Repositories;

namespace SistemaBeneficiarios.Infrastructure.Repositories;

/// <summary>
/// Repositorio de infraestructura para la persistencia de datos de Beneficiarios.
/// Utiliza Dapper para interactuar con la base de datos SQL Server.
/// </summary>
public class BeneficiarioRepository : IBeneficiarioRepository
{
    private readonly string _connectionString;

    public BeneficiarioRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    /// <summary>
    /// Crea un nuevo beneficiario en la base de datos utilizando un procedimiento almacenado.
    /// </summary>
    /// <param name="command">Objeto con los datos del nuevo beneficiario.</param>
    /// <returns>El ID asignado al nuevo beneficiario.</returns>
    public async Task<int> CreateAsync(CreateBeneficiarioCommand command)
    {
        using var connection = new SqlConnection(_connectionString);
        
        // Ejecuta el procedimiento almacenado sp_InsertBeneficiario y retorna el valor escalar (ID)
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

    /// <summary>
    /// Obtiene todos los beneficiarios registrados.
    /// </summary>
    /// <returns>Una colección de objetos Beneficiario.</returns>
    public async Task<IEnumerable<Beneficiario>> GetAllAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        
        var result = await connection.QueryAsync<Beneficiario>(
            "sp_GetBeneficiarios", 
            commandType: CommandType.StoredProcedure);

        return result;
    }

    /// <summary>
    /// Actualiza la información de un beneficiario existente.
    /// </summary>
    /// <param name="command">Objeto con los datos actualizados.</param>
    /// <returns>True si se modificó al menos un registro, False si no.</returns>
    public async Task<bool> UpdateAsync(UpdateBeneficiarioCommand command)
    {
        using var connection = new SqlConnection(_connectionString);
        var rows = await connection.ExecuteAsync("sp_EditarBeneficiario", command, commandType: CommandType.StoredProcedure);
        return rows > 0;
    }

    /// <summary>
    /// Elimina un beneficiario de la base de datos por su ID.
    /// </summary>
    /// <param name="id">El identificador del beneficiario.</param>
    /// <returns>True si se eliminó, False si no se encontró.</returns>
    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var rows = await connection.ExecuteAsync("sp_EliminarBeneficiario", new { Id = id }, commandType: CommandType.StoredProcedure);
        return rows > 0;
    }

    /// <summary>
    /// Busca un beneficiario por su ID mediante una consulta SQL directa.
    /// </summary>
    /// <param name="id">El identificador único.</param>
    /// <returns>El beneficiario encontrado o null.</returns>
    public async Task<Beneficiario?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        string sql = "SELECT * FROM Beneficiario WHERE Id = @Id";
        return await connection.QueryFirstOrDefaultAsync<Beneficiario>(sql, new { Id = id });
    }
}