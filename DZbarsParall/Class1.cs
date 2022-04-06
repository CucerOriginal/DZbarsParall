using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZbarsParall
{
    public interface IRequestHandler
    {
        string HandleRequest(string message, string[] arguments);
    }

    public class DummyRequestHandler : IRequestHandler
    {
        public string HandleRequest(string message, string[] arguments)
        {
            try
            {
                Thread.Sleep(10_000);
                if (message.Contains("упади"))
                {
                    throw new Exception("Я упал, как сам просил");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Тут тотал: " + ex.Message);
            }
            return Guid.NewGuid().ToString("D");
        }
    }
}
