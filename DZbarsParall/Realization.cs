using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZbarsParall
{
    internal class Realization
    {
        DummyRequestHandler dummyRequestHandler = new DummyRequestHandler();
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
                List<string> listString = new List<string>();
                Console.WriteLine("Так, а что мне отправить?");
                string? cmd1 = "";
                for (int i = 0; cmd1 != "/end"; i++)
                {
                    cmd1 = Console.ReadLine();
                    if (cmd1 != "/end" && cmd1 != null)
                    {
                        listString.Add(cmd1);
                        Console.WriteLine("Что нибудь еще?");
                    }
                }
                ThreadPool.QueueUserWorkItem(callBack => DummyRealization(cmd, listString.ToArray()));
            }
        }

        void DummyRealization(string cmd, string[] argStrings)
        {
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
