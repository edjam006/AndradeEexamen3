using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace AndradeEexamen3.Models
{
    public class Vehiculo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnioFabricacion { get; set; }
        public string Placa { get; set; }
    }
}
