using System.ComponentModel.DataAnnotations;
using System;

namespace AdvancedProgramming_Lesson1.Models
{
    public class Drzewa
    {
        public int Id { get; set; }
        public int Wysokosc { get; set; }
        public string Rodzaj { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data_posadzenia { get; set; }
        public int Srednica_pnia { get; set; }
        public string Kolor_lisci { get; set; }
    }
}
