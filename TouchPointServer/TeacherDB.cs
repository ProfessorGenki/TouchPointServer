namespace TouchPointServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeacherDB")]
    public partial class TeacherDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Teacher_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public int SSN { get; set; }

        [Required]
        [StringLength(30)]
        public string Address { get; set; }

        public int Phone { get; set; }

        [Column("E-Mail")]
        [Required]
        [StringLength(30)]
        public string E_Mail { get; set; }
    }
}
