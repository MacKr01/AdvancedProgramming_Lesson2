using System.ComponentModel.DataAnnotations;
using System;

namespace AdvancedProgramming_Lesson1.Models
{
    public class Warzywa
    {
        public int Id { get; set; }
        public string Typ_warzywa { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data_siewu { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data_zbioru { get; set; }
        public int Waga { get; set; }
        public int Cena { get; set; }
    }
}