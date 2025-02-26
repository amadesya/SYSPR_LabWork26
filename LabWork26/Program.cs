using System.IO.Pipes;
using System.Text;

NamedPipeServerStream server = new("myPipe");


server.WaitForConnection(); 
byte[] buffer = new byte[1024];

int bytesRead = server.Read(buffer, 0, buffer.Length);
string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
Console.WriteLine($"Message {message}");

string response = "Подключение к серверу произведено";
byte[] responseBytes = Encoding.UTF8.GetBytes(response);
server.Write(responseBytes, 0, responseBytes.Length);

int Factorial(int a)
{
    if (a == 1) return 1;

     return a * Factorial(a - 1);
}


try
{
    byte[] buffer1 = new byte[1024];

    int bytesRead1 = server.Read(buffer1, 0, buffer1.Length);
    string message1 = Encoding.UTF8.GetString(buffer1, 0, bytesRead1);
    Console.WriteLine(message1);

    if (int.TryParse(message1, out int a))
    {
        int result = Factorial(a);
        string resultStr = result.ToString();
        byte[] resultBytes = Encoding.UTF8.GetBytes(resultStr);
        server.Write(resultBytes, 0, resultBytes.Length);
        Console.WriteLine($"Факториал:{a}! = {resultStr}");
    }
}

catch (IOException e)
{
    Console.WriteLine("ERROR: {0}", e.Message);
}

server.Close();




