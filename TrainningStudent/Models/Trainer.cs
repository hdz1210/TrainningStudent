namespace TrainningStudent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trainer")]
    public partial class Trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainer()
        {
            Topics = new HashSet<Topic>();
        }

        public int TrainerID { get; set; }

        [StringLength(100)]
        public string TrainerName { get; set; }

        [StringLength(100)]
        public string Type { get; set; }

        [StringLength(100)]
        public string WorkPlace { get; set; }

        public int? Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? CourseID { get; set; }

        public virtual Course Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
