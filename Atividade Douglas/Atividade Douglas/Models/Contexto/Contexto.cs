using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Atividade_Douglas.Models.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {

        }

        public System.Data.Entity.DbSet<Atividade_Douglas.Models.Modelo3D> Modelo3D { get; set; }
    }
}