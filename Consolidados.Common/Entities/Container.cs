namespace Consolidados.Common.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    public class Container
    {
        public int Id { get; set; }

        [Required]
        public string ContainerName { get; set; }

        [Required]
        public int Payload { get; set; }

        public ICollection<State> States { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int IdContract { get; set; }
    }
}