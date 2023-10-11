using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2512. 奖励最顶尖的 K 名学生
    /// </summary>
    internal class TopStudents
    {
        public static IList<int> Run(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k)
        {
            HashSet<string> positive = new HashSet<string>(positive_feedback);
            HashSet<string> negative = new HashSet<string>(negative_feedback);
            List<Student> students = new List<Student>();
            for (int i = 0; i < student_id.Length; i++)
            {
                Student student = new Student(student_id[i]);
                int score = 0;
                foreach (string tag in report[i].Split(' '))
                {
                    if (positive.Contains(tag))
                    {
                        score += 3;
                    }
                    else if (negative.Contains(tag))
                    {
                        score -= 1;
                    }
                }

                student.Score = score;
                students.Add(student);
            }

            students.Sort();

            return students.Select(s => s.Id).Take(k).ToList();
        }

        public class Student : IComparable
        {
            public Student(int id)
            {
                Id = id;
            }

            public int Id { get; }

            public int Score { get; set; }

            public int CompareTo(object? obj)
            {
                if (obj is Student student)
                {
                    if(Score > student.Score)
                        return -1;
                    else if(Score < student.Score)
                        return 1;
                    else
                        return Id.CompareTo(student.Id);
                }

                return -1;
            }

            public override bool Equals(object? obj)
            {
                if (obj is Student student)
                {
                    return student.Id == Id;
                }

                return false;
            }

            public override int GetHashCode()
            {
                return Id;
            }
        }
    }
}
