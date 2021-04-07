using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RainbowSchool
{
    public class Program
    {
        DataAccessLayer dalObj = new DataAccessLayer();
        static void Main(string[] args)
        {
           
            if (!Directory.Exists(@"C:/SimpliLearn"))
                Directory.CreateDirectory(@"C:/SimpliLearn/");
            DataAccessLayer.ReadExistingData();
            Intro();                       
        }
        //Funcion to give user the option to select operation
        public static void Intro()
        {
            var input = "";
            Console.WriteLine("*****************RAINBOW SCHOOL TEACHERS DATA MANAGEMENT**************");
            Console.WriteLine("Select an operation to perform");
            Console.WriteLine("1.Store Teachers Data");
            Console.WriteLine("2.Update Teachers Data");
            Console.WriteLine("3.Retrive Teachers Data");
            Console.WriteLine("4.View Entire Teachers Data");
            Console.WriteLine("5.Exit");
            Console.WriteLine("Please select one of the options to perform action (1 or 2 or 3 or 4 or 5)");
            input = Console.ReadLine();
            Program p = new Program();
            p.Operation(input);
        }
        //Funcion to call various operation
        public void Operation(string operationId)
        {
            Teacher tObj = new Teacher();
            
            //List<int> TeacherId = new List<int>();
            //dalObj.ReadExistingData();
            if(operationId.Equals("1"))
            {
                Console.WriteLine("********************");
                Console.WriteLine("Store Teachers Data");
                Console.WriteLine("********************");
                //Perform Store Operation
                Console.WriteLine("Enter Teacher's Id(Should be Number)");
                tObj.TeacherId1 = Convert.ToInt32(Console.ReadLine());
                if(DataAccessLayer.TeacherId.Count>0)
                {
                    //foreach (int id in DataAccessLayer.TeacherId)
                    //{
                        if (!DataAccessLayer.TeacherId.Contains(tObj.TeacherId1))
                        {
                            DataAccessLayer.TeacherId.Add(tObj.TeacherId1);
                            Console.WriteLine("Enter Teacher's Name");
                            tObj.TeacherName1 = Console.ReadLine();
                            Console.WriteLine("Enter Teacher's Class");
                            tObj.Class1 = Console.ReadLine();
                            Console.WriteLine("Enter Teacher's Section");
                            tObj.Section1 = Console.ReadLine();
                            dalObj.Store(tObj);
                        }
                        else
                        {
                            Console.WriteLine("Id already exists!!!");
                        }
                    //}
                }
                else
                {
                    DataAccessLayer.TeacherId.Add(tObj.TeacherId1);
                    Console.WriteLine("Enter Teacher's Name");
                    tObj.TeacherName1 = Console.ReadLine();
                    Console.WriteLine("Enter Teacher's Class");
                    tObj.Class1 = Console.ReadLine();
                    Console.WriteLine("Enter Teacher's Section");
                    tObj.Section1 = Console.ReadLine();
                    dalObj.Store(tObj);
                }
                //End Store Operation
                Intro();
            }
            else if(operationId.Equals("2"))
            {
                Console.WriteLine("********************");
                Console.WriteLine("Update Teachers Data");
                Console.WriteLine("********************");
                //Perform Operation
                if (DataAccessLayer.TeacherId.Count > 0)
                {
                    Console.WriteLine("Enter Teacher's Id");
                    tObj.TeacherId1 = Convert.ToInt32(Console.ReadLine());
                    if (DataAccessLayer.TeacherId.Contains(tObj.TeacherId1))
                    {
                        Console.WriteLine("Enter Teacher's Name");
                        tObj.TeacherName1 = Console.ReadLine();
                        Console.WriteLine("Enter Teacher's Class");
                        tObj.Class1 = Console.ReadLine();
                        Console.WriteLine("Enter Teacher's Section");
                        tObj.Section1 = Console.ReadLine();
                        dalObj.Update(tObj);
                        Console.WriteLine("Record Updated Sucessfully!!!");
                    }
                    else
                    {
                        Console.WriteLine("There is no such Teacher Id to update data!!!");
                    }
                }
                else
                {
                    Console.WriteLine("There is no record to update!!!");
                }
                    Intro();
            }
            else if (operationId.Equals("3"))
            {
                Console.WriteLine("********************");
                Console.WriteLine("Retrive Teachers Data");
                Console.WriteLine("********************");
                
                //Perform Operation
                if (DataAccessLayer.TeacherId.Count > 0)
                {
                    Console.WriteLine("Enter Teacher's Id");
                    tObj.TeacherId1 = Convert.ToInt32(Console.ReadLine());
                    if (DataAccessLayer.TeacherId.Contains(tObj.TeacherId1))
                    {
                        dalObj.Retrive(tObj);
                    }
                    else
                    {
                        Console.WriteLine("There is no such Teacher Id to retrive data!!!");
                    }
                }
                else
                {
                    Console.WriteLine("There is no record to retrive!!!");
                }
                Intro();
            }
            else if (operationId.Equals("4"))
            {
                Console.WriteLine("******************************");
                Console.WriteLine("View Entire Teachers Data");
                Console.WriteLine("******************************");
                //Perform Operation
                dalObj.RetriveAll();
                Intro();
            }
            else if (operationId.Equals("5"))
            {
                Console.WriteLine("Exiting from Rainbow School Teachers Data Management");
            }
            else
            {
                Console.WriteLine("Invalid Option");
                Intro();
            }
            //Console.ReadKey();
        }

    }
}
