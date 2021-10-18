using System.IO; // types for managing the filesystem using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using static System.Console;

public class Programm
{
  public static void Main()
  {
    OutputFileSystemInfo();
  }

  static void OutputFileSystemInfo()
  {
    WriteLine("{0,-33} {1}", "Path.PathSeparator", PathSeparator);
    WriteLine("{0,-33} {1}", "Path.DirectorySeparatorChar",
      DirectorySeparatorChar);
    WriteLine("{0,-33} {1}", "Directory.GetCurrentDirectory()",
      GetCurrentDirectory());
    WriteLine("{0,-33} {1}", "Environment.CurrentDirectory",
      CurrentDirectory);
    WriteLine("{0,-33} {1}", "Environment.SystemDirectory",
      SystemDirectory);
    WriteLine("{0,-33} {1}", "Path.GetTempPath()", GetTempPath());
    WriteLine("GetFolderPath(SpecialFolder");
    WriteLine("{0,-33} {1}", " .System)",
      GetFolderPath(SpecialFolder.System));
    WriteLine("{0,-33} {1}", " .ApplicationData)",
      GetFolderPath(SpecialFolder.ApplicationData));
    WriteLine("{0,-33} {1}", " .MyDocuments)",
      GetFolderPath(SpecialFolder.MyDocuments));
    WriteLine("{0,-33} {1}", " .Personal)",
      GetFolderPath(SpecialFolder.Personal));
  }
}
