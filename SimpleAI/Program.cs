using SimpleAI.Core;

namespace SimpleAI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var thread = new CoreEngine(new CoreConfig());
            var filePath = "log.txt";
            while (true)
            {
                Console.WriteLine("type a request");
                var s = Console.ReadLine();
                try
                {
                    var response = thread.Process(s);
                    Console.WriteLine(response);
                    Console.WriteLine("select best answer");
                    int num = Convert.ToInt32(Console.ReadLine());
                    thread.Map.Improve(num);
                }
                catch (Exception e)
                {
                    using var fileStream = File.Create(filePath);
                    using var fileWriter = new StreamWriter(fileStream);
                    fileWriter.WriteLine(e);
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }
    }
}