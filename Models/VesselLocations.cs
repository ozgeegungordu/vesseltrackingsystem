﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VesselTrackingSystem.Models
{
    public partial class VesselLocations
    {
        public int Id { get; set; }
        public int VesselId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public short Heading { get; set; }
        public DateTime AnnouncedAt { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Vessels Vessel { get; set; }
    }
}