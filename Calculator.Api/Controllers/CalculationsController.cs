using Calculator;
using Calculator.Api.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace Calculator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculationsController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public CalculationsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<ActionResult<CalculationResult>> Calculate([FromBody] CalculationRequest request)
    {
        ICalculator calculator = request.CalculatorType.ToLower() switch
        {
            "cached" => new CachedCalculator(),
            _ => new SimpleCalculator()
        };

        int result = request.Operation.ToLower() switch
        {
            "add" => calculator.Add(request.A, request.B),
            "subtract" => calculator.Subtract(request.A, request.B),
            "multiply" => calculator.Multiply(request.A, request.B),
            "divide" => calculator.Divide(request.A, request.B),
            _ => throw new ArgumentException("Unknown operation")
        };

        await SaveHistoryAsync(request.A, request.B, request.Operation, request.CalculatorType, result);

        return Ok(new CalculationResult
        {
            Result = result
        });
    }

    private async Task SaveHistoryAsync(int a, int b, string operation, string calculatorType, int result)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        await using var connection = new MySqlConnection(connectionString);
        await connection.OpenAsync();

        const string sql = """
            INSERT INTO calculation_history (operand1, operand2, operation, calculator_type, result)
            VALUES (@a, @b, @operation, @calculatorType, @result);
            """;

        await using var command = new MySqlCommand(sql, connection);
        command.Parameters.AddWithValue("@a", a);
        command.Parameters.AddWithValue("@b", b);
        command.Parameters.AddWithValue("@operation", operation);
        command.Parameters.AddWithValue("@calculatorType", calculatorType);
        command.Parameters.AddWithValue("@result", result);

        await command.ExecuteNonQueryAsync();
    }
}