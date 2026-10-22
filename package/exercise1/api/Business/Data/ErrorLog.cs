using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StargateAPI.Business.Data;

[Table("ErrorLog")]
public class ErrorLog
{
    [Key]
    public int Id { get; set; }

    public int ErrorCode { get; set; }

    public string? Message { get; set; }

    public string? StackTrace { get; set; }
}