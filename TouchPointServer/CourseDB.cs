namespace TouchPointServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseDB")]
    public partial class CourseDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Course_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        public int Room { get; set; }

        public int Date { get; set; }

        [Required]
        [StringLength(30)]
        public string Teacher_ID { get; set; }
    }
}
