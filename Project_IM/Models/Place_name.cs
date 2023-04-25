namespace Project_IM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Place_name
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Place_name()
        {
            Video = new HashSet<Video>();
            Video1 = new HashSet<Video>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short 地點ID { get; set; }

        [Required]
        [StringLength(50)]
        public string 地點名稱 { get; set; }

        public bool? 是否起點 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Video> Video { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Video> Video1 { get; set; }
    }
}
