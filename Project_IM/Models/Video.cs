namespace Project_IM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Video")]
    public partial class Video
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short 影片ID { get; set; }

        public short 開始地點 { get; set; }

        public short 結束地點 { get; set; }

        [Required]
        [StringLength(200)]
        public string 影片網址 { get; set; }

        [StringLength(100)]
        public string 路徑地圖 { get; set; }

        public virtual Place_name Place_name { get; set; }

        public virtual Place_name Place_name1 { get; set; }
    }
}
