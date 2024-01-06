using System.ComponentModel.DataAnnotations;

namespace Cafe.Data.Model
{
    public class AddIns
    {
        // Unique identifier for each hobby, automatically generated.
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The Name is Required")]  // Required attribute ensures that this Name field is mandatory.
        public string Name { get; set; }

        [Required(ErrorMessage = "The Price is Required")]  // Required attribute ensures that this Name field is mandatory.
        public string Price { get; set; }
    }
}
