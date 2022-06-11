namespace Consolidados.Common.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class State
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}
