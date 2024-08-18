using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLogin.Models
{
    public class ProcesoConArchivosViewModel
    {
        public Proceso Proceso { get; set; }
        public List<Archivo> Archivos { get; set; }
    }

}