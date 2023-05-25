namespace Entity.Entities
{
    public class Teacher : Person
    {
        public List<Discipline> DisciplinesTaught { get; set; }
    }
}
