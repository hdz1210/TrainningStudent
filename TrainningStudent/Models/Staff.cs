namespace TrainningStudent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        public int StaffID { get; set; }

        [StringLength(100)]
        public string StaffName { get; set; }

        [StringLength(100)]
        public string StaffPhone { get; set; }

        [StringLength(100)]
        public string StaffEmail { get; set; }

        [StringLength(100)]
        public string Address { get; set; }
    }
}
