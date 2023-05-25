using Entity.Entities;

namespace Entity.Repository
{
    public class MessageRepository
    {
        public List<Message> Messages = new List<Message>(){
            new() { Title = "AULA CANCELADA", Content = $"A aula do dia {DateTime.Now.Date} foi cancelada." },
            new() { Title = "TAREFA CADASTRADA", Content = $"Tarefa inserida no sistema para entrega no dia {DateTime.Now.Date}." },
            new() { Title = "CONTEÚDO CADASTRADO", Content = $"Os conteúdos da aula ministrada hoje foram inseridos." }
        };

        public Message GetRandom()
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            Messages[rand.Next(Messages.Count)].Date = DateTime.Now;

            return Messages[rand.Next(Messages.Count)];
        }
    }
}
