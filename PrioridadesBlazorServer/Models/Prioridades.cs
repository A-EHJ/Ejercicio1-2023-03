using System.ComponentModel.DataAnnotations;
namespace PrioridadesBlazorServer.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }
        [Required(ErrorMessage = "La descripción es requerida")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Los dias de compromiso son requeridos")]
        public int DiasCompromiso { get; set; }
    }
}
