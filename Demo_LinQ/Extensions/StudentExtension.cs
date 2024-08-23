using Demo_LinQ.Models;

namespace Demo_LinQ.Extensions
{
    public static class StudentExtension
    {
        public static string SayHello(this Student student)
        {
            return $"{student.Firstname} {student.Lastname} vous dit bonjour !";
        }


      
    }
}
