namespace TrainningStudent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trainee")]
    public partial class Trainee
    {
        public int TraineeID { get; set; }

        [StringLength(100)]
        public string TraineeName { get; set; }

        [StringLength(100)]
        public string Account { get; set; }

        [StringLength(100)]
        public string Majors { get; set; }

        [StringLength(100)]
        public string Classroom { get; set; }

        public int? CourseID { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        public virtual Course Course { get; set; }
    }
}
