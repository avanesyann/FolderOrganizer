namespace FolderOrganizer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Users\narek.avanesyan.s\Desktop\Querying Microsoft SQL Server";

            OrganizeFolder udemy = new OrganizeFolder(path);

            udemy.DisplayFolders();
            udemy.DisplayFiles();
        }
    }
}
