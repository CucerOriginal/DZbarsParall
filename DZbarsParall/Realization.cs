using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZbarsParall
{
    internal class Realization
    {
        public void ConsoleRealization()
        {
            Console.WriteLine("Я запустил");

            while (true)
            {
                Console.WriteLine("Как запрос то будет называться? Если не хочешь пиши /exit");
                var cmd = Console.ReadLine();
                if (cmd == "/exit")
                {
                    Console.WriteLine("Все, я вырубаю");
                    break;
                }
                int count = 4;
                string[] argStrings = new string[count];
                Console.WriteLine("Так, а что мне отправить?");
                string? cmd1 = "";
                for (int i = 0; cmd1 != "/end"; i++)
                {
                    if (count <= i)
                    {
                        Array.Resize(ref argStrings, argStrings.Length * 2);
                    }
                    cmd1 = Console.ReadLine();
                    if (cmd1 != "/end" && cmd1 != null)
                    {
                        argStrings[i] = cmd1;
                        Console.WriteLine("Что нибудь еще?");
                    }
                }
                ThreadPool.QueueUserWorkItem(callBack => DummyRealization(cmd, argStrings));
            }
        }

        void DummyRealization(string cmd, string[] argStrings)
        {
            DummyRequestHandler dummyRequestHandler = new DummyRequestHandler();

            try
            {
                Console.WriteLine("Тут все ок, вот пруф " + dummyRequestHandler.HandleRequest(cmd, argStrings));
            }
            catch (Exception ex) {
                Console.WriteLine("Тут тотал, смотри:  " + ex.Message);
            }
        }

    }
}
