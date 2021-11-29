using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Interpreter : MonoBehaviour
{
    List<string> response = new List<string>();
    public string victimDirectoryPath;
    private void Start()
    {
        SimpleWebRequest();
    }

    IEnumerator SimpleWebRequest()
    {
        string path = "StreamingAssets/Victim Directories"; //This works because index.html is in the same folder as StreamingAssets ?
        UnityWebRequest uwr = UnityWebRequest.Get(path);
        yield return uwr.SendWebRequest();
    }
    public List<string> Interpret(string userInput)
    {
        response.Clear();


        string[] args = userInput.Split();

        if(args[0] == "man")
        {
            //Return some info
            switch(args[1])
            {
                case "ls":
                    response.Add("List the directories and files within the current directory.");
                    response.Add("Use '-a' to show hidden files and '-l' for long listing.");
                    break;
                case "cat":
                    response.Add("Copy the contents of the file to the terminal output.");
                    break;
                case "grep":
                    response.Add("Search the given file for the keyword(s).");
                    break;
                case "head":
                    response.Add("Show the first 10 lines of the file.");
                    response.Add("Add a number to the command to change how many lines are shown.");
                    break;
                case "tail":
                    response.Add("Show the last 10 lines of the file.");
                    response.Add("Add a number to the command to change how many lines are shown.");
                    break;
                case "exit":
                    response.Add("Log out of the current session.");
                    break;
                case "":
                    response.Add("Must supply a command to do a 'man' search!");
                    break;
                default:
                    response.Add("Command not found!");
                    break;
            }
            return response;
        }
        else if(args[0] == "ls")
        {
            if(args.Length == 1)
            {
                return ls(victimDirectoryPath);
            }
            else
            {
                return ls(victimDirectoryPath + "/" + args[1]);
            }
        }
        else if(args[0] == "cat")
        {
            return cat(args[1]);
        }
        else if(args[0] == "help")
        {
            response.Add("You can use the follwing commands:");
            response.Add("ls, cd, chmod, cat, grep, head, tail, pwd");
            response.Add("Use 'man' with one of the previous commands to get more detailed information on that command (E.x. 'man ls').");
            return response;
        }
        else if(args[0] == "exit")
        {
            response.Add("Logging off...");
            return response;
        }
        else
        {
            response.Add("Command not recognized. Type help for a list of available commands.");
            return response;
        }
    }
    private List<string> ls(string path)
    {
        //  Loop through all the immediate subdirectories of the victim directory.
        foreach (string entry in Directory.GetDirectories(path))
        {
            DirectoryInfo directory = new DirectoryInfo(entry);
            response.Add(directory.Name);
        }
        //  Loop through all the files in the victim directory.
        foreach (string entry in Directory.GetFiles(path))
        {
            FileInfo file = new FileInfo(entry);
            if(file.Extension != ".meta")
                response.Add(file.Name);
        }
        return response;
     }
    // void chmod(string path, string perms)
    // {
    //     // Change the permissions of the given file

    // }
    private List<string> cat(string path)
    {
        path = victimDirectoryPath + path;
        FileInfo fsi = new FileInfo(victimDirectoryPath + path);
        
        // // Check if file exists
        // if (File.Exists(path) == false)
        // {
        //     Debug.Log(path);
        //     response.Add("Error: File does not exist!");
        //     return response;
        // }

        // if((fsi.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
        // {
        //     response.Add("Error: " + path + " is not a file");
        //     return response;
        // }
        // Open the file to read from.
        using (StreamReader sr = File.OpenText(path))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                response.Add(s);
            }
        }
        return response;
    }
    // void pwd()
    // {
    //     // Print the current working directory
    //     response.Add(Directory.GetCurrentDirectory());
    // }
    // void head(string path, string lines)
    // {
    //     // Print the first 10 lines in the file or the amount of lines given

    // }
    // void tail(string path, string lines)
    // {
    //     // Print the last 10 lines in the file or the amount of lines given

    // }
}
