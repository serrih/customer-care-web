using System.ComponentModel.DataAnnotations;

namespace CustomerCare.MVC.Models;

public class Customer
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo Nombre es obligatorio")]
    public required string Name { get; set; }
    public short QueueNumber { get; set; }
}