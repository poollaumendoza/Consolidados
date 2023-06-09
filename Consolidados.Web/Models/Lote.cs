//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Consolidados.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lote()
        {
            this.CompraDetalle = new HashSet<CompraDetalle>();
            this.ContratoLote = new HashSet<ContratoLote>();
            this.LlenadoContenedor = new HashSet<LlenadoContenedor>();
            this.Movimiento = new HashSet<Movimiento>();
        }
    
        public int IdLote { get; set; }
        public int IdAlmacen { get; set; }
        public int IdEmpresa { get; set; }
        public string Descripcion { get; set; }
        public string NroLote { get; set; }
        public int Cantidad { get; set; }
        public int IdEstado { get; set; }
    
        public virtual Almacen Almacen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompraDetalle> CompraDetalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContratoLote> ContratoLote { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Estado Estado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LlenadoContenedor> LlenadoContenedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movimiento> Movimiento { get; set; }
    }
}