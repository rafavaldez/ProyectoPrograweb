namespace Proyecto_Grupal_PrograWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    using System.Data.Entity.Validation;
    using System.IO;
    using System.Web;

    [Table("usuario")]
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            score = new HashSet<score>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string apellido { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(45)]
        public string password { get; set; }

        [StringLength(45)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<score> score { get; set; }

        //metodos
        //Listar

        public List<usuario> Listar()
        {
            var objUsuario = new List<usuario>();
            try
            {
                using (var db = new ModeloSistema())
                {
                    objUsuario = db.usuario.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuario;
        }

        //Metodo Obtener

        public usuario Obtener(int id)
        {
            var objUsuario = new usuario();
            try
            {
                using (var db = new ModeloSistema())
                {
                    objUsuario = db.usuario
                        .Where(x => x.id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuario;
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

        //Validar Login
        public ResponseModel ValidarLogin(string usuario, string password)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new ModeloSistema())
                {
                    //password = HashHelper.MD5(password);

                    var user = db.usuario.Where(x => x.email == usuario)
                               .Where(x => x.password == password)
                               .SingleOrDefault();

                    if (user != null)
                    {
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
        public ResponseModel GuardarPerfil(HttpPostedFileBase Foto, string clave)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    var Usu = db.Entry(this);
                    Usu.State = EntityState.Modified;

                    if (Foto != null)
                    {
                        string extension = Path.GetExtension(Foto.FileName).ToLower();

                        int size = 1024 * 1024 * 5;

                        var filtro = new[] { ".jpg", ".png", ".jpeg", ".gif", };

                        if (filtro.Contains(extension) && (Foto.ContentLength <= size))
                        {
                            
                            //string archivo = Path.GetFileName(Foto.FileName);
                            //Foto.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/" + archivo));
                            //this.AVATAR = archivo;
                        }
                    }
                    else
                    {
                        //Usu.Property(x => x.AVATAR).IsModified = false;
                    }
                    if (this.id == 0)
                    {
                        Usu.Property(x => x.id).IsModified = false;
                    }
                    if (this.nombre == null)
                    {
                        Usu.Property(x => x.nombre).IsModified = false;
                    }
                    if (this.apellido == null)
                    {
                        Usu.Property(x => x.apellido).IsModified = false;
                    }
                    if (this.email == null)
                    {
                        Usu.Property(x => x.email).IsModified = false;
                    }
                    if (this.password == null)
                    {
                        Usu.Property(x => x.password).IsModified = false;
                    }
                    else
                    {
                        //Cambiar la Contraseña y Reformarla a MD5
                        //string clave2 = HashHelper.MD5(clave);
                        this.password = clave;
                    }
                    if (this.estado == null)
                    {
                        Usu.Property(x => x.estado).IsModified = false;
                    }

                    db.SaveChanges();
                    rm.SetResponse(true);
                }
            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return rm;
        }
    }
}
