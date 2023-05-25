namespace Entity.Entities
{
    public class Student : Person
    {
        public List<Discipline> DisciplinesEnrolled { get; set; }
    }
}
