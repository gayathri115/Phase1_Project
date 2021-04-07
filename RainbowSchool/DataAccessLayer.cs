using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace RainbowSchool
{
    public class DataAccessLayer
    {
        //int static counter=0;
        string filepath = "C:\\SimpliLearn\\RainBowSchool.txt";
        //string filepath1 = "C:\\SimpliLearn\\RainBowSchoolRetrieve.txt";
        public static List<int> TeacherId = new List<int>();
        public void Store(Teacher tObj)
        {
            StreamWriter stObj;
            stObj = File.AppendText(filepath);
            stObj.WriteLine(tObj.TeacherId1 + "|" + tObj.TeacherName1 + "|" + tObj.Class1 + "|" + tObj.Section1);
            stObj.Close();
            Console.WriteLine("Record stored successfully!");
        }
        public static void ReadExistingData()
        {
            string line;
            int counter = 0;
            DataAccessLayer dObj = new DataAccessLayer();
            if(File.Exists(dObj.filepath))
            {
                StreamReader file = new StreamReader(dObj.filepath);
                while ((line = file.ReadLine()) != null)
                {
                    int index = line.IndexOf('|');
                    TeacherId.Add(Convert.ToInt32(line.Substring(0, index)));
                    counter++;
                }
                file.Close();
            }
           
        }

        public void Update(Teacher tObj)
        {
            //Read data from file
            //Store in DAta Table 
            //Update
            #region File Writer Logic
            string line, NewData="", OldData="";
            int counter = 0;
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite);
            StreamReader file = new StreamReader(fs);
            //string content = File.ReadAllText(filepath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(tObj.TeacherId1.ToString()))
                {
                    string[] details = line.Split('|');

                    if (details[0].Equals(tObj.TeacherId1.ToString()))
                    {
                        //file.Close();

                        //fs.Seek()
                        //fs.Seek(3, SeekOrigin.Begin);
                        //int pos1, pos2, pos3;
                        //pos1 = details[0].Length + 2;
                        NewData = tObj.TeacherId1 + "|" + tObj.TeacherName1 + "|" + tObj.Class1 + "|" + tObj.Section1;
                        OldData = line;
                        //content = content.Replace(OldData, NewData);
                        //byte[] data = Encoding.UTF8.GetBytes(NewData);
                        //fs.Write(data, 0, data.Length);

                    }

                }
               
            }
            
            file.Close();
            fs.Close();
            string content = File.ReadAllText(filepath);
            content = content.Replace(OldData, NewData);
            File.WriteAllText(filepath, content);
            #endregion


        }
        public void Retrive(Teacher tObj)
        {
            string line;
            int counter = 0;
            StreamReader file = new StreamReader(filepath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(tObj.TeacherId1.ToString()))
                {
                    string[] details=line.Split('|');
                    if(details[0].Equals(tObj.TeacherId1.ToString()))
                    {
                        Console.WriteLine("The requested Details are:");
                        Console.WriteLine("Teachers Id : "+ details[0]);
                        Console.WriteLine("Teachers Name : " + details[1]);
                        Console.WriteLine("Teachers Class : " + details[2]);
                        Console.WriteLine("Teachers Section : " + details[3]);
                    }
                    
                }

            }
            file.Close();
        }
        public void RetriveAll()
        {
            if(File.Exists(filepath))
            {
                string text = System.IO.File.ReadAllText(filepath);
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("DataBase is empty as of now");
            }
            
        }
    }
}
