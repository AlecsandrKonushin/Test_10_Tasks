namespace Tasks
{
    public static class FileManager
    {
        private const string PATH_FILE = "P:/Projects/Test_10_Tasks/Data/";

        public static string LoadFile(string nameFile)
        {
            string text = System.IO.File.ReadAllText(PATH_FILE + nameFile + ".txt");

            return text;
        }
    }
}