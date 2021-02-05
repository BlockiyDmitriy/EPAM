using System;
using System.Threading.Tasks;
using Task4.BLL.Abstraction;
using Task4.BLL.CSVParsing;
using Task4.BLL.DataSourceProvider;
using Task4.BLL.Transaction;
using Task4.DAL.Context;

namespace Task4.BLL.Managers
{
    public class ParseFileServiceTaskManager : BaseBackUpFileManager, IControlProcess
    {
        
        private TaskFactory TaskFactory { get; set; }
        private TaskManager TaskManager { get; set; }
        public ParseFileServiceTaskManager(string file, string destFolder) : base(file, destFolder)
        {
            TaskFactory = new TaskFactory();
            TaskManager = new TaskManager();
        }

        readonly Action<object> ParsingAction = (temp) =>
        {
            var tempDTO = temp as TempSourceFileDTO;
            using (var DTOSource = new StringToDTOParser(tempDTO.FileName, tempDTO.DestFolder))
            {
                foreach (var item in DTOSource)
                {
                    var context = new FileDataModelContainer();
                    var task = new TransactDataTask(context);
                    task.TransactStartTask();
                }
            }
        };

        public void RunTask(object tempDTO)
        {
            ParsingAction(tempDTO);
            Task temp = null;
            try
            {
                TaskManager.TryAddTask(temp = TaskFactory.StartNew(ParsingAction, tempDTO,  TaskFactory.CancellationToken));
                temp.ContinueWith(x =>
                {
                    base.BackUp();
                });
            }
            catch
            {
                throw new Exception("runTask");
            }
        }
        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
