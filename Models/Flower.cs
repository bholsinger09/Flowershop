using System.ComponentModel.DataAnnotations;

namespace burgershack.Models
{
  public class Flower
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Range(.90, 100)]
    public double Price { get; set; }

  }
}