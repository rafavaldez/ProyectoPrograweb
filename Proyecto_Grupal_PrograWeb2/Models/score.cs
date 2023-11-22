namespace Proyecto_Grupal_PrograWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("score")]
    public partial class score
    {
        public int id { get; set; }

        public int? usuario_id { get; set; }

        public int? juego_id { get; set; }

        public double? puntos { get; set; }

        public int? nivel { get; set; }

        public virtual juego juego { get; set; }

        public virtual usuario usuario { get; set; }
    }
}
