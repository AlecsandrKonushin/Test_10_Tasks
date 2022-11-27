namespace Tasks
{
    public abstract class TaskBase
    {
        protected string nameFile;
        protected string dataFile;

        public TaskBase(string nameFile)
        {
            this.nameFile = nameFile;

            dataFile = FileManager.LoadFile(nameFile);
        }

        public abstract void CountData();
    }
}