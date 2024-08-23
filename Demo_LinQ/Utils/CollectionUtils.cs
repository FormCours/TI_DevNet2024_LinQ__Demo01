using Demo_LinQ.Models;

namespace Demo_LinQ.Utils
{
    public class CollectionUtils
    {
        public delegate bool StudentDelegate(Student student);

        public List<Student> GetStudents(List<Student> students, StudentDelegate condition)
        {
            List<Student> result = new List<Student>();

            for (int i = 0; i < students.Count; i++)
            {
                if (condition(students[i]))
                {
                    result.Add(students[i]);
                }
            }

            return result;
        }

        // GetStudentsOk(students)          => GetStudents(students, (st) => st.Result >= 50);
        // GetStudentsBad(students)         => GetStudents(students, (st) => st.Result < 50);
        // GetStudentsLetter(students, "o") => GetStudents(students, (s) => s.Firstname.Contains("o"));

        public List<Student> GetStudentsOk(List<Student> students)
        {
            List<Student> result = new List<Student>();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Result >= 50)
                {
                    result.Add(students[i]);
                }
            }

            return result;
        }

        public List<Student> GetStudentsBad(List<Student> students)
        {
            List<Student> result = new List<Student>();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Result < 50)
                {
                    result.Add(students[i]);
                }
            }

            return result;
        }

        public List<Student> GetStudentsLetter(List<Student> students, string letter)
        {
            List<Student> result = new List<Student>();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Firstname.Contains(letter))
                {
                    result.Add(students[i]);
                }
            }

            return result;
        }
    }
}
