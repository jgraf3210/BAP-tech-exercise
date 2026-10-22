using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StargateAPI.Business.Data;

[Table("Log")]
public class Log
{
    [Key]
    public int Id { get; set; }

    public bool IsError { get; set; }

    public int? ErrorCode { get; set; }

    public string? Message { get; set; }

    public string? StackTrace { get; set; }

    public DateTime CreatedTime { get; set; } = DateTime.Now;
}