/*
8. Folders [Serialization] [XML] 

Implement a function FolderNames, which accepts a string containing an XML file that specifies folder structure and returns all folder names that start with startingLetter. The XML format is given in the example below.

For example, for the letter 'u' and XML file:

<?xml version="1.0" encoding="UTF-8"?>
<folder name="c">
    <folder name="program files">
        <folder name="uninstall information" />
    </folder>
    <folder name="users" />
</folder>

the function should return "uninstall information" and "users" (in any order).

https://www.testdome.com/d/c-sharp-interview-questions/18

using System;
using System.Collections.Generic;

public class Folders
{
    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        throw new NotImplementedException("Waiting to be implemented.");
    }

    public static void Main(string[] args)
    {
        string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";

        foreach (string name in Folders.FolderNames(xml, 'u'))
            Console.WriteLine(name);
    }
}
*/ 
// =============================================================== solution (passes 4/4 tests)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class Folders
{
	class Folder
    {
        public string Name { get; set; }
    }

    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        List<string> result = new List<string>();
        XDocument xDoc = XDocument.Parse(xml);
        var folders = from rec in xDoc.Descendants("folder")
            select new Folder()
            {
                Name = (string) rec.Attribute("name")
            };
        foreach (Folder folder in folders)
        {
            if (folder.Name[0] == startingLetter)
                result.Add(folder.Name);
        }
        return result;
    }

    public static void Main(string[] args)
    {
        string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";

        foreach (string name in Folders.FolderNames(xml, 'u'))
            Console.WriteLine(name);
    }
}