using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuntosVerdes.ModelsCSV
{
    public class Pesaje
    {
        public string Punto { get; set; }
        public int Anio { get; set; }
        public string Mes { get; set; }
        public int Semana { get; set; }
        [Default(0)]
        public float Vidrio { get; set; }
        [Default(0)]
        public float PapelCarton { get; set; }
        [Default(0)]
        public float Metal { get; set; }
        [Default(0)]
        public float Plastico { get; set; }
        [Default(0)]
        public float Telgopor { get; set; }
        [Default(0)]
        public float PlasticosMas { get; set; }
        [Default(0)]
        public float Tetra_brick { get; set; }
        [Default(0)]
        public float Pequenios_elec { get; set; }
        [Default(0)]
        public float Elect_uso { get; set; }
        [Default(0)]
        public float Avus { get; set; }

    }
}
