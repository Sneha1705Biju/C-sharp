using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineDrive
{
    public class Vaccine
    {
        public DateTime VaccineDate { get; set; }
        public Type VaccineType { get; set; }
        public int Dosage { get; set; }
        public Vaccine(int vaccine,DateTime date,int dose)
        {
            VaccineType = (Type)vaccine;
            VaccineDate = date;
            Dosage = dose;
        }
    }
    public enum Type
    {
        Covaxin,
        Covidshield
    }
}
