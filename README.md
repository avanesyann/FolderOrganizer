#  :file_folder: Folder Organizer 
A simple C# console application to organize files by moving subtitle files or any specific file type into a separate folder.

## :star: Features
- Display folders and files in a clean console layout
- Move specific file types to a new folder
- Sort folders numerically for better readability

## :wrench: Changelog

### :arrows_counterclockwise: Version 0.1 (Initial Release)
- Added initial project files
- Added `DisplayFolders()` and `DisplayFiles()` to list directory contents with sorted order
- Implemented `ExtractNumbers()` for proper numerical sorting of folders

### :arrows_counterclockwise: Version 0.2
- Implemented `MoveFiles()` to move files of a given extension into a subfolder
- Created `CreateDirectory()` to ensure a subfolder exists before moving files

### :arrows_counterclockwise: Version 0.3
- Implemented `CreateFiles()` to create a file of a given name.
- Implemented `DeleteFiles()` to delete files of a given extension.

### :new: Version 0.4
- Made the program more interactive.
- Now the user can directly specify the full directory, extension and the folder name to move the files to.

### :new: Version 0.4.1
- Assign default values to extension and folder names if not mentioned by the user.


## :bulb: Future Plans
- Affect subdirectories as well.
- Implement a Console UI.
- Introduce a GUI version using WinForms

## :book: How to Use
1. Run the program and specify the target folder path
2. Choose whether to display files/folders
3. Create a FolderOrganizer class instance
4. Use FolderOrganizer's methods to maniuplate the directory