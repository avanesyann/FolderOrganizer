using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FolderOrganizer
{
    public class OrganizeFolder
    {
        public DirectoryInfo UserDirectory { get; }

        public OrganizeFolder(string path)
        {
            UserDirectory = new DirectoryInfo(path);
        }

        public void DisplayFolders()
        {
            var directories = UserDirectory.GetDirectories().OrderBy(d => ExtractNumbers(d.Name)).ToArray();

            DisplayCenteredTitle("Folders");

            foreach (var folder in directories)
                Console.WriteLine("> " + folder.Name);

            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine();
        }
        public void DisplayFiles()
        {
            var files = UserDirectory.GetFiles();

            DisplayCenteredTitle("Files");

            foreach (var file in files)
                Console.WriteLine("> " + file.Name);

            Console.WriteLine(new string('-', Console.WindowWidth));

            Console.WriteLine();
        }




        private int ExtractNumbers(string folderName)
        {
            var match = Regex.Match(folderName, @"\d+");
            return match.Success ? int.Parse(match.Value) : int.MaxValue;
        }
        private void DisplayCenteredTitle(string title)
        {
            int consoleWidth = Console.WindowWidth;

            int dashesNeeded = consoleWidth - title.Length - 2;

            int leftDashes = dashesNeeded / 2;
            int rightDashes = dashesNeeded - leftDashes;

            string centeredTitle = new string('-', leftDashes) + " " + title + " " + new string('-', rightDashes);

            Console.WriteLine(centeredTitle);
        }
    }
}
