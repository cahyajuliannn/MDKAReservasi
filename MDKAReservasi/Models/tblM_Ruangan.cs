//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MDKAReservasi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblM_Ruangan
    {
        public tblM_Ruangan()
        {
            this.tblT_Reservasi = new HashSet<tblT_Reservasi>();
        }
    
        public int Ruangan_PK { get; set; }
        public string NamaRuangan { get; set; }
        public Nullable<int> Lantai { get; set; }
        public Nullable<int> DayaTampung { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> Status_FK { get; set; }
    
        public virtual tblM_Status tblM_Status { get; set; }
        public virtual ICollection<tblT_Reservasi> tblT_Reservasi { get; set; }
    }
}
