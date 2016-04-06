    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


namespace ASP5MVC6EF7ReversedWorkaround.Models
{
       [Table("vwEvent")]
 public class vwEvent
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEvent { get; set; }

        [Column(Order = 1, TypeName = "smalldatetime")]
        public DateTime dLogged { get; set; }

        [Column(Order = 2)]
        public DateTime dtLogged { get; set; }

        [Column(Order = 3)]
        public DateTime dtLoggedUtc { get; set; }

        [Column(Order = 4)]
        public DateTime dtLocal { get; set; }

        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short siPriority { get; set; }

        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short idLevel { get; set; }

        [Column(Order = 7)]
        [StringLength(32)]
        public string sLevel { get; set; }

        [Column(Order = 8)]
        public byte idOrigin { get; set; }

        [Column(Order = 9)]
        [StringLength(32)]
        public string sOrigin { get; set; }

        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iEventId { get; set; }

        [Column(Order = 11)]
        [StringLength(255)]
        public string sMessage { get; set; }

        public string sExtended { get; set; }

        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idMachine { get; set; }

        [Column(Order = 13)]
        [StringLength(32)]
        public string sMachine { get; set; }

        [Column(Order = 14)]
        [StringLength(48)]
        public string sIpAddr { get; set; }

        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idUserAcct { get; set; }

        [Column(Order = 16)]
        [StringLength(255)]
        public string sUserAcct { get; set; }

        [StringLength(255)]
        public string sSource { get; set; }

        public int? siWinPID { get; set; }

        [StringLength(255)]
        public string sProcess { get; set; }

        public int? siWinTID { get; set; }

        [StringLength(255)]
        public string sThread { get; set; }

        [StringLength(255)]
        public string sMessageTag { get; set; }
    }
}
