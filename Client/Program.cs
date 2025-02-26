using System.IO.Pipes;
using System.Text;

NamedPipeClientStream client = new(".", "myPipe", PipeDirection.InOut);
client.Connect();

string message = "Подключение клиента прошло успешно";
byte[] messageBytes = Encoding.UTF8.GetBytes(message);
client.Write(messageBytes, 0, messageBytes.Length);

byte[] buffer = new byte[1024];
int bytesRead = client.Read(buffer, 0, buffer.Length);
string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
Console.WriteLine(response);

Console.WriteLine("Введите число для факториала");
string message1 = Console.ReadLine();
byte[] messageBytes1 = Encoding.UTF8.GetBytes(message1);
client.Write(messageBytes1, 0, messageBytes1.Length);

byte[] buffer1 = new byte[1024];
int bytesRead1 = client.Read(buffer1, 0, buffer1.Length);
string response1 = Encoding.UTF8.GetString(buffer1, 0, bytesRead1);
Console.WriteLine($"Факториал: {message1}! = {response1}");


client.Close();