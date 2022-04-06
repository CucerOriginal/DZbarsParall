using DZbarsParall;

DummyRequestHandler dummyRequestHandler = new DummyRequestHandler();
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
    string[] argSrings = new string[count];
    Console.WriteLine("Так, а что мне отправить?");
    string? cmd1 = "";
    for (int i = 0; cmd1 != "/end"; i++)
    {
        if (count <= i)
        {
            Array.Resize(ref argSrings, argSrings.Length * 2);
        }
        cmd1 = Console.ReadLine();
        if (cmd1 != "/end" && cmd1 != null)
        {
            argSrings[i] = cmd1;
            Console.WriteLine("Что нибудь еще?");
        }
    }
    new Thread(() => Console.WriteLine("тут все готово, вот пруф: " + dummyRequestHandler.HandleRequest(cmd, argSrings))).Start();
}