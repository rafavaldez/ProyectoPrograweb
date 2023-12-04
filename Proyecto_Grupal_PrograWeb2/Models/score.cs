namespace Proyecto_Grupal_PrograWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

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

        public List<score> ObtenerScoresTodos()
        {
            var scores = new List<score>();
            try
            {
                using (var db = new ModeloSistema())
                {
                    // Filtra todos los scores de todos los usuarios
                    scores = db.score
                        .Include("usuario")
                        .Include("juego")
                     
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return scores;
        }


        public List<score> ObtenerScoresPorUsuario()
        {
            var scores = new List<score>();
            var userId = Convert.ToInt32(SessionHelper.GetUser());
            try
            {
                using (var db = new ModeloSistema())
                {
                    // Filtra los scores por usuarioId y también incluye información sobre el usuario y el juego
                    scores = db.score
                        .Include("usuario")
                        .Include("juego")
                        .Where(s => s.usuario_id == userId)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return scores;
        }


    }
}
