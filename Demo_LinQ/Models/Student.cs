namespace Demo_LinQ.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public double Result { get; set; }

        public Student(int studentId, string firstname, string lastname, double result)
        {
            StudentId = studentId;
            Firstname = firstname;
            Lastname = lastname;
            Result = result;
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname} ({Result}/100)";
        }
    }
}
