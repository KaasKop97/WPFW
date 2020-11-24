namespace Studenten.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int StudentNummer { get; set; }
        public string StudentNaam { get; set; }
        public string StudentMail { get; set; }
        public int StudentPhonenr { get; set; }
        public int StudentAge { get; set; }
        public int StudentGrade { get; set; }
        List<Student> Vrienden;
    }
}