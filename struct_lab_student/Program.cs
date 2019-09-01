using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace struct_lab_student
{
    partial class Program
    {
        static Student[] ReadData(string fileName)
        {
            int count = File.ReadLines(fileName).Count();
            /*
            int count = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (reader.ReadLine() != null)
                {
                    count++;
                }
            }
            */
            Student[] students = new Student[count];
            StreamReader sr = new StreamReader(fileName, Encoding.Default);
            string line;
            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                students[i] = new Student(line);
                i++;
            }
            sr.Close();
            return students;
        }
        
        static double ToValue(char symbol)
        {
            if (symbol == '-')
            {
                return 2;
            }
            else
            {
                return char.GetNumericValue(symbol);
            }
        }

        static void Average(Student[] studs)
        {
            double average;
            foreach (Student info in studs)
            {
                average = 0;
                if (info.scholarship == 0)
                {
                    average += (ToValue(info.mathematicsMark) + ToValue(info.physicsMark) + ToValue(info.informaticsMark)) / 3;
                    Console.WriteLine("{0} {1} {2} {3:0.###}", info.firstName, info.surName, info.patronymic, average);
                }
            }
        }

        static void Main(string[] args)
        {
            Student[] studs = ReadData("data.txt");
            Average(studs);
            Console.ReadKey();
        }
    }
}
