namespace Consolidados.Common.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    public class Contract
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required]
        public string ContractNumber { get; set; }

        [MaxLength(200, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required]
        public string StartingAddress { get; set; }

        [MaxLength(200, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required]
        public string ArrivedAddress { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartingDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ArrivedDate { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public ICollection<State> States { get; set; }

        public ICollection<Container> Containers { get; set; }

        public int ContainerNumber => Containers == null ? 0 : Containers.Count;
    }
}