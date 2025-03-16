namespace FolderOrganizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Change this to your folder's path
            string path = @"D:\Tutorials\Udemy - The Complete SQL Bootcamp\1 - Course Introduction";

            OrganizeFolder udemy = new OrganizeFolder(path);

            // Moves .vtt files to a new folder
            udemy.MoveFiles(".vtt", "Subtitles");
        }
    }
}
