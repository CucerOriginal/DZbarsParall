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
                Console.WriteLine("Так, а что мне отправить?");
                string[] arrayString = ReadArguments().ToArray();
                ThreadPool.QueueUserWorkItem(callBack => DummyRealization(cmd, arrayString));
            }
        }

        List<string> ReadArguments()
        {
            List<string> listString = new List<string>();
            string? cmd = "";
            for (int i = 0; cmd != "/end"; i++)
            {
                cmd = Console.ReadLine();
                if (cmd != "/end" && cmd != null)
                {
                    listString.Add(cmd);
                    Console.WriteLine("Что нибудь еще?");
                }
            }
            return listString;
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
