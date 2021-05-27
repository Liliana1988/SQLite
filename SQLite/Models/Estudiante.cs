using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLite.Models
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }


        [MaxLength(255)]
        public string Nombre { set; get; }


        [MaxLength(255)] 
        public string Usuario { set; get; }
        

        [MaxLength(255)]
        public string Contrasena { set; get; }
     

    }
}
