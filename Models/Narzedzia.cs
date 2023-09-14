using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace AdvancedProgramming_Lesson1.Models
{
    public class Narzedzia
    {
        public int Id { get; set; }
        public string Typ_narzedzia { get; set; }
        public string Material_wykonania { get; set; }
        public int Waga { get; set; }
        public int Dlugosc { get; set; }
        public int Cena { get; set; }
    }
}
