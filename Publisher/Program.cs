﻿using Entity.Entities;
using Entity.Repository;
using NetMQ;
using NetMQ.Sockets;

// Iniciando um publicador em uma thread separada.
Thread publisherThread = new Thread(Publisher);
publisherThread.Start();

// publisherThread.Join();

static void Publisher()
{
    Thread.Sleep(5000);

    using (var publisher = new PublisherSocket())
    {
        Console.WriteLine($"Publisher socket ON at {DateTime.Now.ToString("HH:mm:ss.fff")} \n");

        publisher.Bind("tcp://*:5555");

        for (int i = 1; i <= 5; i++)
        {
            Teacher randomTeacher = TeacherRepository.GetRandom();

            Discipline discipline = DisciplineRepository.GetDisciplineByTeacher(randomTeacher);

            Message randomMessage = MessageRepository.GetRandom();

            string message = $"{randomTeacher.Name} - {randomMessage.Title} - {randomMessage.Content}";

            string topic = discipline.Name;

            publisher.SendMoreFrame(topic).SendFrame(message);

            Console.WriteLine($"Publisher [{DateTime.Now.ToString("HH:mm:ss.fff")}]: [{topic}] - {message} \n");

            Thread.Sleep(2000);
        }
    }
}