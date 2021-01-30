using Task4.BLL.Managers;

namespace Task4.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "FileName";
            ParseFileServiceTaskManager parseFileServiceTaskManager = new ParseFileServiceTaskManager();
            parseFileServiceTaskManager.RunTask(fileName);
        }
    }
}
