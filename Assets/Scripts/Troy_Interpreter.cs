using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class Troy_Interpreter : MonoBehaviour
{
    List<string> response = new List<string>();
    private bool foundKillerFile;

    private void Awake()
    {
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
                    response.Add("List the directories and files within the current directory.");
                    response.Add("Use '-a' to show hidden files and '-l' for long listing.");
                    break;
                case "cat":
                    response.Add("Copy the contents of the file to the terminal output.");
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
        else if(args[0] == "help")
        {
            response.Add("You can use the follwing commands:");
            response.Add("ls, cat");
            response.Add("Use 'man' with one of the previous commands to get more detailed information on that command (E.x. 'man ls').");
            return response;
        }
        else
        {
            response.Add("Command not recognized. Type help for a list of available commands.");
            return response;
        }
    }
    private List<string> ls(string path = "")
    {
        string[] desktopFolders = new string[] {"Cat_Pictures", "Homework", "Notes", "Game_Footage", "Passwords.txt"};

        if(path == "")
        {
            foreach(string folder in desktopFolders)
            {
                response.Add(folder);
            }
        }
        else
        {
            switch(path)
            {
                case "Cat_Pictures":
                    response.Add("More_Ollie_Pictures");
                    response.Add("ollie_sitting.jpeg");
                    response.Add("ollie_jumping.jpeg");
                    response.Add("ollie_sleeping.jpeg");
                    response.Add("ollie_and_me.jpeg");
                    break;
                case "Homework":
                    response.Add("Philosophy_2000_Essay.doc");
                    response.Add("Native_American_Studies_QA.doc");
                    break;
                case "Notes":
                    response.Add("This folder is empty.");
                    break;
                case "Game_Footage":
                    response.Add("LeBron_Top_10_Dunks.mp4");
                    response.Add("Live_XGames_20XX_Footage.mov");
                    response.Add("Summer_Olympics_20XX_Javelin_Throw.mp4");
                    break;
                case "Cat_Pictures/More_Ollie_Pictures":
                    response.Add("ollie.txt");
                    break;
            }
        }
        return response;
    }
    private List<string> cat(string path)
    {
        if(path == "Passwords.txt")
        {
            response.Add("ollie");
            response.Add("ollie123");
            response.Add("ollie0617");
            response.Add("Ollie17");
            response.Add("0ll13");
            response.Add("Ollie246810");
        }
        else if(path == "Cat_Pictures/More_Ollie_Pictures/ollie.txt")
        {
            foundKillerFile = true;
            
            response.Add("Congratulations! You found my not so hidden file.");
            response.Add("I specifically put this one here because of how much this guy loved his cat.");
            response.Add("He has more pictures of his cat than he does of any homework or notes.");
            response.Add("Anyways, since you found this file I assume that you are looking for me.");
            response.Add("How sweet, as a reward I'll give you a hint about who I am.");
            response.Add("I live right here in Mint City, y'know the skyline here is so beautiful.");
            response.Add("Did you really think I was going to give you an actual hint. Pathetic.");
            response.Add("Good luck on your search, you're going to need it!");
        }
        else if(path == "Homework/Philosophy_2000_Essay.doc")
        {
            response.Add("Don't be rude to others. Treat other how you want to be treated.");
            response.Add("I don't know who came up with that but they must have been a philosopher.");
        }
        else if(path == "Homework/Native_American_Studies_QA.doc")
        {
            response.Add("Question 1: Where were the Cherokee originate?");
            response.Add("They were from India.");
        }
        else
        {
            response.Add("Error: Must supply valid file name");
        }
        return response;
    }
}
