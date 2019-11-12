namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUSTOMERS")]
    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            INVOICEs = new HashSet<INVOICE>();
        }

        [StringLength(10)]
        public string CustomerID { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? BirthDay { get; set; }

        public bool? Sex { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string CustomerTypeID { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public int? Point { get; set; }

        public virtual CUSTOMERTYPE CUSTOMERTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
    }
}
