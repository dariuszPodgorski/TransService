//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TransServiceWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleCard
    {
        public int IdVehicleCard { get; set; }
        public Nullable<int> IdVehicle { get; set; }
        public System.DateTime DateOC { get; set; }
        public string NumberOC { get; set; }
        public System.DateTime DateTechnicalExamination { get; set; }
        public string TotalMieage { get; set; }
    
        public virtual Vehicle Vehicle { get; set; }
    }
}
