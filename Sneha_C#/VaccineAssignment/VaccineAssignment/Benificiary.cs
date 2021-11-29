using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineDrive
{
    public class Beneficiary
    {
        public int RegNo = 1001;
        public string Name { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public long MobileNumber { get; set; }
        public string City { get; set; }
        
        public List<Vaccine> VaccineDetail = new List<Vaccine>();
        
        

        public void BenificiaryDetails(string name, int age, int gender, long mobile, string address)
        {
            RegNo = RegNo++;
            Name = name;
            MobileNumber = mobile;
            City = address;
            Age = age;
            Gender = (GenderType)gender;
        }

        public string Vaccinate(int vaccine, DateTime date)
        {
            string note = null;
            if (VaccineDetail.Count==0)
            {
                Vaccine details = new Vaccine(vaccine, date, 1);
                VaccineDetail.Add(details);
                note = $"Your Next dose due time is {details.VaccineDate.AddDays(30).ToString("dd/MM/yyyy")}.";
            }
            else if (VaccineDetail.Count == 1)
            {
                    Vaccine details = new Vaccine(vaccine, date, 2);
                    VaccineDetail.Add(details);
                    note = "You have completed the vaccination course. Thanks for your participation in the vaccination drive.";
                    return note;
              
            }
            else
            {
                note = "You had 2 doses already.";
                return note;
            }

            return note;
        }
        public string DueDate()
        {
            string message = null;

            if (VaccineDetail.Count == 1)
            {

                message = $"Your Next due date is {VaccineDetail[0].VaccineDate.AddDays(30).ToString("dd/MM/yyyy")}.";
                return message;

            }
            else
            {
                message = "You have completed the vaccination course. Thanks for your participation in the vaccination drive.";
                return message;
            }
        }

    }
        public enum GenderType
        {
            Male,
            Female,
            Others
        }
    
}
