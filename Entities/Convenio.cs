using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaApi.Entities;

[Table("CONVENIO")]
public class Convenio
{
    [Key]
    [Column("ID_CONVENIO")]
    public long IdConvenio { get; set; }

    [Required]
    [Column("CNPJ")]
    public string Cnpj { get; set; } = string.Empty;

    [Required]
    [Column("NOME_FANTASIA")]
    public string NomeFantasia {  get; set; } = string.Empty;

    [Column("REGISTRO_ANS")]
    public string? RegistroAns {  get; set; }
}
