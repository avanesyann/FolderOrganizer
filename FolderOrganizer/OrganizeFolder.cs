using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;

namespace FolderOrganizer
{
    public class OrganizeFolder
    {
        public DirectoryInfo UserDirectory { get; }

        public OrganizeFolder(string path)
        {
            if (Directory.Exists(path))
                UserDirectory = new DirectoryInfo(path);
            else
                throw new DirectoryNotFoundException("The directory does not exist.");
        }

        public void MoveFiles(string extension, string folder)
        {
            var files = UserDirectory.GetFiles();

            foreach (var file in files)
            {
                string directory = CreateDirectory(folder);
                string newDirectory = Path.Combine(directory, file.Name);

                if (!File.Exists(newDirectory) && file.Extension == extension)
                {
                    file.MoveTo(newDirectory);
                    Console.WriteLine($"File \"{file.Name}\" moved to the new directory.");
                }

            }
        }
        public void DeleteFiles(string extension)
        {
            var files = UserDirectory.GetFiles();

            foreach (var file in files)
            {
                if (file.Extension.Equals($".{extension}", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        file.Delete();
                        Console.WriteLine($"File \"{file.Name}\" was deleted.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to delete \"{file.Name}\": {ex.Message}");
                    }
                }
            }
        }
        public void CreateFiles(string name)
        {
            string newFile = Path.Combine(UserDirectory.FullName, name);

            if (!File.Exists(newFile))
            {
                try
                {
                    using (File.Create(newFile)) { }
                    Console.WriteLine($"File \"{name}\" created.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to create \"{name}\": {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"File \"{name}\" already exists.");
            }
        }

        public string CreateDirectory(string folder)
        {
            string newDirectory = Path.Combine(UserDirectory.FullName, folder);
            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);

                Console.WriteLine($"Directory \"{newDirectory}\" created.");
            }

            return newDirectory;
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
