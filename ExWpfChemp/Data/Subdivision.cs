//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExWpfChemp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subdivision
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subdivision()
        {
            this.Employee = new HashSet<Employee>();
            this.Subdivision1 = new HashSet<Subdivision>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> HeadId { get; set; }
        public string Info { get; set; }
        public int MainEmployeeId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subdivision> Subdivision1 { get; set; }
        public virtual Subdivision Subdivision2 { get; set; }
    }
}
