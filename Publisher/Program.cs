using Entity.Entities;
using Entity.Repository;
using NetMQ;
using NetMQ.Sockets;

// Iniciando um publicador em uma thread separada.
Thread publisherThread = new Thread(Publisher);
publisherThread.Start();


List<Thread> subscriberThreads = new List<Thread>();

// Iniciando diversos assinantes em threads separadas.
foreach (Student student in StudentRepository.GetAll())
{
    subscriberThreads.Add(new Thread(Subscriber));
    subscriberThreads.Last().Start(student);
}

/*foreach (Thread thread in subscriberThreads)
{
    thread.Join();
}*/

// publisherThread.Join();

static void Publisher()
{
    using (var publisher = new PublisherSocket())
    {
        Console.WriteLine("Publisher socket ON. \n");

        publisher.Bind("tcp://*:5555");

        for (int i = 1; i <= 5; i++)
        {
            Teacher randomTeacher = TeacherRepository.GetRandom();

            Discipline discipline = DisciplineRepository.GetDisciplineByTeacher(randomTeacher);

            Message randomMessage = MessageRepository.GetRandom();

            string message = $"{randomTeacher.Name} - {randomMessage.Title} - {randomMessage.Content}";

            string topic = discipline.Name;

            publisher.SendMoreFrame(topic).SendFrame(message);

            Console.WriteLine($"Publisher: [{topic}] - {message} \n");

            Thread.Sleep(2000);
        }
    }
}

static void Subscriber(object entity)
{
    Student student = (Student)entity;

    using (var subscriber = new SubscriberSocket())
    {
        subscriber.Connect("tcp://localhost:5555");

        foreach (Discipline discipline in student.DisciplinesEnrolled)
        {
            string topic = discipline.Name;

            subscriber.Subscribe(topic);

            Console.WriteLine($"Subscriber {student.Name} on {discipline.Name} channel. \n");
        }

        while (true)
        {
            string messageTopicReceived = subscriber.ReceiveFrameString();
            string messageReceived = subscriber.ReceiveFrameString();

            Console.WriteLine($"Subscriber: [{student.Name}] - [{messageTopicReceived}] - {messageReceived} \n");
        }
    }
}