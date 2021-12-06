using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class Killer_Interpreter : MonoBehaviour
{
    List<string> response = new List<string>();
    List<string> desktopFolders = new List<string>();

    private bool foundKillerFile;
    private void Awake()
    {
        desktopFolders = new List<string> { "Victims", "nextVictims.txt" };
        foundKillerFile = false;
    }
    private void Update()
    {
        if (foundKillerFile)
        {
            LoadNextScene();
        }
    }
    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(30);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
                    response.Add("List the directories and files within the current directory. e.x 'ls directory'");
                    response.Add("'ls' prints the files in the home directory by default.");
                    break;
                case "cat":
                    response.Add("Copy the contents of the file to the terminal output. e.x 'cat file'");
                    break;
                case "head":
                    response.Add("View the first 10 lines of the file. e.x 'head file'");
                    break;
                case "tail":
                    response.Add("View the last 10 lines of the file. e.x 'tail file'");
                    break;
                case "grep":
                    response.Add("Search the given file for the given pattern.");
                    break;
                case "chmod":
                    response.Add("Change the file's permissions. Use numbers 0-7 for permissions.");
                    response.Add("0 = no permissions");
                    response.Add("1 = execute only");
                    response.Add("2 = write only");
                    response.Add("3 = write and execute(1 + 2)");
                    response.Add("4 = read only");
                    response.Add("5 = read and execute(4 + 1)");
                    response.Add("6 = read and write(4 + 2)");
                    response.Add("7 = read and write and execute(4 + 2 + 1)");
                    response.Add("The first number is for user, second for group, third for others.");
                    response.Add(" e.x 'chmod 777 file'.");
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
        else if (args[0] == "ls")
        {
            if (args.Length == 1)
            {
                return ls();
            }
            else
            {
                return ls(args[1]);
            }
        }
        else if (args[0] == "cat")
        {
            return cat(args[1]);
        }
        else if (args[0] == "head")
        {
            return head(args[1]);
        }
        else if (args[0] == "tail")
        {
            return tail(args[1]);
        }
        else if (args[0] == "mkdir")
        {
            return mkdir(args[1]);
        }
        else if(args[0] == "cp")
        {
            return cp(args[1], args[2]);
        }
        else if (args[0] == "help")
        {
            response.Add("You can use the follwing commands:");
            response.Add("ls, cat, head, tail, mkdir, cp");
            response.Add("Use 'man' with one of the previous commands to get more detailed information on that command (E.x. 'man ls').");
            return response;
        }
        else
        {
            response.Add("Command not recognized. Type help for a list of available commands.");
            return response;
        }
    }
    public bool getKillerFileStatus()
    {
        return foundKillerFile;
    }
    private List<string> ls(string path = "")
    {

        if (path == "")
        {
            foreach (string folder in desktopFolders)
            {
                response.Add(folder);
            }
        }
        else
        {
            switch (path)
            {
                case "Victims":
                    response.Add("Troy.txt");
                    response.Add("Fabio.txt");
                    response.Add("Cass.txt");
                    break;
            }
        }
        return response;
    }
    private List<string> cat(string file)
    {
        if (file == "Victims/Troy.txt")
        {
            response.Add("Jesus this dude and his cat. He couldn't have made it easier to get his information. The only thing he had going for him was his muscles. Had no choice but to poision the man.");
        }
        else if (file == "Victims/Fabio.txt")
        {
            response.Add("This one has the weirdest love for dolphins. Also, sharing your password throughout the office? If it wasn't for Mr. Cat-Lover he'd get first place for being my dumbest victim.");
            response.Add("One boating 'accident' later and all of his stuff is mine.");
        }
        else if (file == "Victims/Cass.txt")
        {
            response.Add("She's a smart one. Keeps everything under lock and key. Too bad her hubris got the better of her. One liitle piece of spyware to go along with her Minecraft mods and boom, I'm in.");
            response.Add("It's a good thing that she totally didn't need her brakes on that busy highway");
        }
        else if (file == "nextVictims.txt")
        {
            response.Add("Rein Bazzoli");
            response.Add("Kimberly Rasmussen");
            response.Add("Ada Saunders");
            response.Add("Nick mckinley");
            response.Add("Eleonora Wyndham");
        }
        else
        {
            response.Add("Error: Must supply valid file name");
        }
        return response;
    }
    private List<string> head(string file)
    {
        if (file == "Victims/Troy.txt")
        {
            response.Add("Jesus this dude and his cat. He couldn't have made it easier to get his information. The only thing he had going for him was his muscles. Had no choice but to poision the man.");
        }
        else if (file == "Victims/Fabio.txt")
        {
            response.Add("This one has the weirdest love for dolphins. Also, sharing your password throughout the office? If it wasn't for Mr. Cat-Lover he'd get first place for being my dumbest victim.");
            response.Add("One boating 'accident' later and all of his stuff is mine.");
        }
        else if (file == "Victims/Cass.txt")
        {
            response.Add("She's a smart one. Keeps everything under lock and key. Too bad her hubris got the better of her. One liitle piece of spyware to go along with her Minecraft mods and boom, I'm in.");
            response.Add("It's a good thing that she totally didn't need her brakes on that busy highway");
        }
        else if (file == "nextVictims.txt")
        {
            response.Add("Rein Bazzoli");
            response.Add("Kimberly Rasmussen");
            response.Add("Ada Saunders");
            response.Add("Nick mckinley");
            response.Add("Eleonora Wyndham");
        }
        else
        {
            response.Add("Error: Must supply valid file name");
        }
        return response;
    }
    private List<string> tail(string file)
    {
        if (file == "Victims/Troy.txt")
        {
            response.Add("Jesus this dude and his cat. He couldn't have made it easier to get his information. The only thing he had going for him was his muscles. Had no choice but to poision the man.");
        }
        else if (file == "Victims/Fabio.txt")
        {
            response.Add("This one has the weirdest love for dolphins. Also, sharing your password throughout the office? If it wasn't for Mr. Cat-Lover he'd get first place for being my dumbest victim.");
            response.Add("One boating 'accident' later and all of his stuff is mine.");
        }
        else if (file == "Victims/Cass.txt")
        {
            response.Add("She's a smart one. Keeps everything under lock and key. Too bad her hubris got the better of her. One liitle piece of spyware to go along with her Minecraft mods and boom, I'm in.");
            response.Add("It's a good thing that she totally didn't need her brakes on that busy highway");
        }
        else if (file == "nextVictims.txt")
        {
            response.Add("Rein Bazzoli");
            response.Add("Kimberly Rasmussen");
            response.Add("Ada Saunders");
            response.Add("Nick mckinley");
            response.Add("Eleonora Wyndham");
        }
        else
        {
            response.Add("Error: Must supply valid file name");
        }
        return response;
    }
    private List<string> mkdir(string filename)
    {
        desktopFolders.Add(filename);
        response.Add("File Created!");
        return response;
    }
    private List<string> cp(string source, string target)
    {
        response.Add("File Contents Copied!");
        desktopFolders.Add(target);
        foundKillerFile = true;
        return response;
    }
}
