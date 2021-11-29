using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineDrive
{
    class Program
    {
        static List<Beneficiary> Beneficiaries = new List<Beneficiary>();

        static void Main(string[] args)
        {
            
            int home = 0;

            do
            {
                HomePage();
                home = int.Parse(Console.ReadLine());
                switch (home)
                {
                    case 1:
                        AddDetails(home);
                        break;
                    case 2:
                        VaccinationProcess();
                        break;
                    case 3:
                        Console.WriteLine("Thank You");
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (home != 3);
        }

       

            private static void HomePage()
            {
            Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Welcome to Vaccine Drive!!!");
                Console.WriteLine("1. Beneficiary Registration \n 2. Vaccination \n 3.Exit");
            }
                

            private static void AddDetails(int dose)
            {
            Beneficiary user = new Beneficiary();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("1.Registration!!!");
            Console.WriteLine("---------------------------------------------");
            Console.Write("Enter your name: ");
                 user.Name = Console.ReadLine();
                Console.Write("Enter your age: ");
                user.Age = int.Parse(Console.ReadLine());
                Console.Write("Enter your gender(1.Male 2.Female 3.Others): ");
                int gender = int.Parse(Console.ReadLine());
                Console.Write("Enter your mobile number: ");
                user.MobileNumber = long.Parse(Console.ReadLine());
                Console.Write("Enter your city: ");
                user.City = Console.ReadLine();

            
                Console.WriteLine("Your registration number is " + user.RegNo);
                Console.WriteLine("You have successfully registered!!!");
                Beneficiaries.Add(user);
            }

        private static void VaccinationProcess()
        {

            bool flag = true;
            do
            {
                ShowList();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("2.Vaccination");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Enter your registration ID:");
                int registeredId = int.Parse(Console.ReadLine());
                Beneficiary currentBenificiary = null;
                foreach (Beneficiary beneficiary in Beneficiaries)
                {
                    if (registeredId == beneficiary.RegNo)
                    {
                        currentBenificiary = beneficiary;
                    }
                }
               
                if (currentBenificiary != null)
                {
                    int beneficiaryOption = 1;
                    do
                    {
                        Console.WriteLine($"Hi {currentBenificiary.Name} \nSpecify your options:\n1.Take Vaccination\n2.Vaccination History\n3.Next Dose Due Date\n4.Go to Main Menu");
                        beneficiaryOption = int.Parse(Console.ReadLine());
                        switch (beneficiaryOption)
                        {
                            case 1:
                                TakeVaccination(currentBenificiary);
                                break;
                            case 2:
                                VaccinationHistory(currentBenificiary);
                                break;
                            case 3:
                                Console.WriteLine(currentBenificiary.DueDate());
                                break;
                            case 4:
                                flag = false;
                                break;
                            default:
                                Console.WriteLine("invalid input");
                                break;



                        }
                    } while (beneficiaryOption != 4);
                }
               
                else
                {
                    Console.WriteLine("Invalid number");
                }
            } while (flag);


        }
        
        private static void TakeVaccination(Beneficiary currentBeneficiary)
        {

            do
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Take Vaccination");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Choose your Vaccine:\n1.Covaxin\n2.Covishield\n3.SputniK");
                int vaccineType = int.Parse(Console.ReadLine());
                if (currentBeneficiary.VaccineDetail.Count == 0)
                {
                    Console.WriteLine("Enter Dose (1 or 2): ");
                   int dose = int.Parse(Console.ReadLine());
                    
                    DateTime date=DateTime.Now;
                    Console.WriteLine($"You are partially vaccinated ");
                    break;
                }
                else if (currentBeneficiary.VaccineDetail.Count == 1)
                {
                    if ((Type)vaccineType == currentBeneficiary.VaccineDetail[0].VaccineType)
                    {
                        Console.WriteLine("Enter Dose (1 or 2): ");
                        int dose = int.Parse(Console.ReadLine());

                        DateTime date = DateTime.Now;
                        Console.WriteLine("You have completely vaccinated");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You have selected different vaccine.");
                    }
                }

            } while (true);
        }
       
        private static void VaccinationHistory(Beneficiary currentBeneficiary)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Vacination History");
            Console.WriteLine("-------------------------------------------");
            foreach (Vaccine detail in currentBeneficiary.VaccineDetail)
            {
                Console.WriteLine($"Vaccine: {detail.VaccineType} | Dosage:{detail.Dosage} dose | Date:{detail.VaccineDate.ToString("dd/MM/yyyy")}");
            }


        }
       
        private static void ShowList()
        {
            foreach (Beneficiary beneficiary in Beneficiaries)
            {
                Console.WriteLine($"REGISTRATION ID: {beneficiary.RegNo} | BENEFICIARY NAME:{beneficiary.Name}");
            }
        }

    } 
}

