//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebSystemRest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_plato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_plato()
        {
            this.tb_receta = new HashSet<tb_receta>();
            this.tb_menu = new HashSet<tb_menu>();
        }
    
        public int id_plato { get; set; }
        public string nom_plato { get; set; }
        public int id_tipo { get; set; }
    
        public virtual tb_tipo tb_tipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_receta> tb_receta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_menu> tb_menu { get; set; }
    }
}
