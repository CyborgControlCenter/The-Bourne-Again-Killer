using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;



public class Cass_Interpreter : MonoBehaviour
{
    List<string> response = new List<string>();
    private bool foundKillerFile;
    private bool isReadable;

    private void Awake()
    {
        foundKillerFile = false;
        isReadable = false;
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
        else if(args[0] == "ls")
        {
            if(args.Length == 1)
            {
                return ls();
            }
            else
            {
                return ls(args[1]);
            }
        }
        else if(args[0] == "cat")
        {
            return cat(args[1]);
        }
        else if(args[0] == "head")
        {
            return head(args[1]);
        }
        else if(args[0] == "tail")
        {
            return tail(args[1]);
        }
        else if(args[0] == "grep")
        {
            return grep(args[1], args[2]);
        }
        else if(args[0] == "chmod")
        {
            return chmod(args[1], args[2]);
        }
        else if(args[0] == "help")
        {
            response.Add("You can use the follwing commands:");
            response.Add("ls, cat, head, tail, grep, chmod");
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
        string[] desktopFolders = new string[] { "OOP_Projects", "Notes", "Funny_Memes", "Lecture_Recordings", "MyNextTrick.txt" };

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
                case "OOP Projects":
                    response.Add("ticTacToe.cpp");
                    response.Add("Shapes.h");
                    response.Add("Shapes.cpp");
                    response.Add("Rectangle.h");
                    response.Add("Rectangle.cpp");
                    break;
                case "Notes":
                    response.Add("Calculus_2_Series_Notes.txt");
                    response.Add("Fall 20XX Class Schedule.pdf");
                    response.Add("TheEndlessSearch.txt");
                    response.Add("Programming_Club_Project.doc");
                    break;
                case "Funny_Memes":
                    response.Add("Joe_Biren.jpeg");
                    response.Add("Spider_Cuh.jpeg");
                    response.Add("Pickle_Rick.jpeg");
                    response.Add("My_Mom.jpeg");
                    break;
                case "Lecuture Recordings":
                    response.Add("Data_Structures_Lecture06.mp4");
                    response.Add("Advanced_Programming_Lecture08.mov");
                    break;
            }
        }
        return response;
    }
    private List<string> cat(string file)
    {
        if (file == "Notes/Calculus_2_Series_Notes.txt")
        {
            response.Add("A series is the sum of some set of terms of a sequence. For example, the sequence 2, 4, 6, 8, ... has partial sums of 2, 6, 12, 20, ... ");
            response.Add("These partial sums are each a finite series. The nth partial sum of a sequence is usually called Sn.");
        }
        else if (file == "MyNextTrick.txt")
        {
            response.Add("For my next trick, detective, I make you actually work for once in your sad career.");
            response.Add("Here's a hint for the hint: The key to your answers is you, 'detective'.");
        }
        else if (file == "Notes/TheEndlessSearch.txt")
        {
            if (isReadable)
            {
                response.Add("You really just don't get it do you? This hint isn't going to be easy like the last two.");
                response.Add("Why don't you use your detective skills and search for the hint that's hidden somewhere in this file.");
                response.Add("PAGE 1 OF 250");
            }
            else
            {
                response.Add("Cannot access file! Enable read permissions!");
            }
        }
        else
        {
            response.Add("Error: Must supply valid file name");
        }
        return response;
    }
    private List<string> head(string file)
    {
        if (file == "Notes/Calculus_2_Series_Notes.txt")
        {
            response.Add("A series is the sum of some set of terms of a sequence. For example, the sequence 2, 4, 6, 8, ... has partial sums of 2, 6, 12, 20, ... ");
            response.Add("These partial sums are each a finite series. The nth partial sum of a sequence is usually called Sn.");
        }
        else if (file == "Notes/MyNextTrick.txt")
        {
            response.Add("For my next trick, detective, I make you actually work for once in your sad career.");
            response.Add("Here's a hint for the hint: The key to your answers is you, 'detective'.");
        }
        else if (file == "Notes/TheEndlessSearch.txt")
        {
            if (isReadable)
            {
                response.Add("You really just don't get it do you? This hint isn't going to be easy like the last two.");
                response.Add("Why don't you use your detective skills and search for the hint that's hidden somewhere in this file.");
                response.Add("PAGE 1 OF 250");
            }
            else
            {
                response.Add("Cannot access file! Enable read permissions!");
            }
        }
        else
        {
            response.Add("Error: Must supply valid file name");
        }
        return response;
    }
    private List<string> tail(string file)
    {
        if (file == "Notes/Calculus_2_Series_Notes.txt")
        {
            response.Add("A series is the sum of some set of terms of a sequence. For example, the sequence 2, 4, 6, 8, ... has partial sums of 2, 6, 12, 20, ... ");
            response.Add("These partial sums are each a finite series. The nth partial sum of a sequence is usually called Sn.");
        }
        else if (file == "Notes/MyNextTrick.txt")
        {
            response.Add("For my next trick, detective, I make you actually work for once in your sad career.");
            response.Add("Here's a hint for the hint: The key to your answers is you, 'detective'.");
        }
        else if (file == "Notes/TheEndlessSearch.txt")
        {
            if (isReadable)
            {
                response.Add("You really just don't get it do you? This hint isn't going to be easy like the last two.");
                response.Add("Why don't you use your detective skills and search for the hint that's hidden somewhere in this file.");
                response.Add("PAGE 1 OF 250");
            }
            else
            {
                response.Add("Cannot access file! Enable read permissions!");
            }
        }
        else
        {
            response.Add("Error: Must supply valid file name");
        }
        return response;
    }
    private List<string> grep(string pattern, string file)
    {
        if(pattern == "detective" & file == "Notes/TheEndlessSearch.txt")
        {
            response.Add("Finally you figured it out detective, but I've KILLED all of your chances to figure out this mystery.");
            response.Add("It's really sad since you've managed to PASS all of my tests, but I give you my WORD when I say this.");
            response.Add("I won't kill ever again. You'll just need to wait to find out if I'm telling the truth.");

            foundKillerFile = true;
        }
        return response;
    }
    private List<string> chmod(string options, string file)
    {
        if (file != "Notes/TheEndlessSearch.txt" & file != "")
        {
            response.Add("Cannot change file permissions!");
        }
        else if (file == "Notes/TheEndlessSearch.txt")
        {
            if (options[0] == '4' ^ options[0] == '5' ^ options[0] == '6' ^ options[0] == '7')
            {
                isReadable = true;
                response.Add("Enabled read permissions for user!");
            }
        }
        else
        {
            response.Add("Error: Must supply valid file");
        }

        return response;
    }
}
