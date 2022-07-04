namespace HeadProjectSchool.Model
{
    public class Student
    {
        //A model é uma classe comum.
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public char Sex { get; set; }
        public int  AbsentsTotal { get; set; }       
        public int  TeamId { get; set; }
    }
}
