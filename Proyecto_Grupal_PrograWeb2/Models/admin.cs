namespace Proyecto_Grupal_PrograWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("admin")]
    public partial class admin
    {
        public int id { get; set; }

        [StringLength(225)]
        public string user { get; set; }

        [StringLength(255)]
        public string contra { get; set; }

        [StringLength(255)]
        public string avatar { get; set; }
        //metodos
        //Listar

        public List<admin> Listar()
        {
            var objAdmin = new List<admin>();
            try
            {
                using (var db = new ModeloSistema())
                {
                    objAdmin = db.admin.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objAdmin;
        }

        //Metodo Obtener

        public admin Obtener(int id)
        {
            var objAdmin = new admin();
            try
            {
                using (var db = new ModeloSistema())
                {
                    objAdmin = db.admin
                        .Where(x => x.id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objAdmin;
        }

        //Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    if (this.id > 0) //Cuando si existe el objeto
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else //Cuando no existe el objeto a nivel bd
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Eliminar

        public void Eliminar()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public ResponseModel ValidarLogin(string usuario, string password)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new ModeloSistema())
                {
                    //password = HashHelper.MD5(password);

                    var user = db.admin.Where(x => x.user == usuario)
                                        .Where(x => x.contra == password)
                                        .SingleOrDefault();

                    if (user != null)
                    {
                        // Guarda el ID del usuario en la sesión
                        SessionHelper.AddUserToSession(user.id.ToString());

                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario y/o Password Incorrectos");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return rm;
        }

        //Metodo Perfil
        public ResponseModel GuardarPerfil()
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    var Usu = db.Entry(this);
                    Usu.State = EntityState.Modified;

                    if (this.id == 0) Usu.Property(x => x.id).IsModified = false;
                    if (this.user == null) Usu.Property(x => x.user).IsModified = false;
                    if (this.contra == null || string.IsNullOrEmpty(this.contra)) Usu.Property(x => x.contra).IsModified = false;


                    db.SaveChanges();
                    rm.SetResponse(true);
                }
            }
            catch (Exception ex)
            {
                Exception myException = new Exception(ex.ToString(), ex);
                throw myException;
            }

            return rm;
        }
    }
}
