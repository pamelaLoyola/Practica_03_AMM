using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica_03
{
    public class PersonItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string DNI { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FecNacimiento { get; set; }
    }
}
