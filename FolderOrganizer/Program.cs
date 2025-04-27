namespace FolderOrganizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a full directory path (or type 'exit' to quit):");
            string defaultFolderName = "Subtitles";
            string defaultExtension = ".vtt";

            while (true)
            {
                Console.Write("\nPath: ");
                string inputPath = Console.ReadLine();

                if (string.Equals(inputPath, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting program.");
                    break;
                }

                try
                {
                    OrganizeFolder organizer = new OrganizeFolder(inputPath);

                    Console.WriteLine("Enter the extension to move (e.g., .vtt):");
                    Console.Write("Extension: ");
                    string extension = Console.ReadLine();
                    extension = string.IsNullOrWhiteSpace(extension) ? defaultExtension : extension;

                    Console.WriteLine("Enter the name of the folder to move files into:");
                    Console.Write("Folder name: ");
                    string folderName = Console.ReadLine();
                    folderName = string.IsNullOrWhiteSpace(folderName) ? defaultFolderName : folderName;


                    organizer.MoveFiles(extension, folderName);
                    organizer.DisplayFiles();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
