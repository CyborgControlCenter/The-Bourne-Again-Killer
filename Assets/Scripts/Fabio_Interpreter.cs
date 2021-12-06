using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class Fabio_Interpreter : MonoBehaviour
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
        else if(args[0] == "head")
        {
            return head(args[1]);
        }
        else if(args[0] == "tail")
        {
            return tail(args[1]);
        }
        else if(args[0] == "help")
        {
            response.Add("You can use the follwing commands:");
            response.Add("ls, cat, head, tail");
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
        string[] desktopFolders = new string[] {"Dolphin_Research", "Data", "Images", "Footage", "TotallyNormal.txt"};

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
                case "Dolphin_Research":
                    response.Add("Report_Draft.doc");
                    response.Add("Research_Notes_Part1.txt");
                    response.Add("Research_Notes_Part2.txt");
                    response.Add("Research_Notes_Part3.txt");
                    response.Add("Research_Notes_Part4.txt");
                    break;
                case "Data":
                    response.Add("Dolphin_Behaviours.xlsx");
                    break;
                case "Images":
                    response.Add("Dolphin_Feeding.jpeg");
                    response.Add("Dolphin_Resting.jpeg");
                    response.Add("Dolphin_Jumping.jpeg");
                    response.Add("Dolphin_Pod.jpeg");
                    break;
                case "Footage":
                    response.Add("Live_Hunt.mp4");
                    response.Add("Dolphin_vs_Shark.mov");
                    break;
            }
        }
        return response;
    }
    private List<string> cat(string file)
    {
        if(file == "Dolphin_Research/Report_Draft.doc")
        {
            response.Add("Error: File too large");
        }
        else if(file == "TotallyNormal.txt")
        {
            foundKillerFile = true;
            
            response.Add("Seriously? Did you really think that the second hint would be this easy.");
            response.Add("Go check Fabio's research, there might be something interesting there.");
            response.Add("You might be reading for a while if you don't know what you're doing though.");
        }
        else if(file == "Dolphin_Research/Research_Notes_Part1.txt")
        {
            response.Add("First day on the water, witnessed a pod of dolphins feeding.");
            response.Add("The ocean is truely a sight to behold.");
        }
        else if (file == "Dolphin_Research/Research_Notes_Part2.txt")
        {
            response.Add("Just found a resting dolphin. It looks like it's having very sweet dreams.");
            response.Add("Rest well my graceful friend.");
        }
        else if (file == "Dolphin_Research/Research_Notes_Part3.txt")
        {
            response.Add("Ahhhh, the dolphins have begun breaching the waters surface.");
            response.Add("The sheen of their bodies is truely at its best when it is struck by the sun's light.");
        }
        else if (file == "Dolphin_Research/Research_Notes_Part4.txt")
        {
            response.Add("Being at the sea keeps me at ease. Much like the pod of dolphins that I am tracking.");
            response.Add("I cannot wait to return to land and write about my research.");
        }
        else
        {
            response.Add("Error: Must supply valid file name");
        }
        return response;
    }
    private List<string> head(string file)
    {
        if (file == "Dolphin_Research/Report_Draft.doc")
        {
            response.Add("          DOLPHINS: AN INDEPTH STUDY          ");
            response.Add("  Dolphin is the common name of aquatic mammals within the infraorder Cetacea.");
            response.Add("The term dolphin usually refers to the extant families Delphinidae (the oceanic dolphins), ");
            response.Add("Platanistidae (the Indian river dolphins), Iniidae (the New World river dolphins), Pontoporiidae (the brackish dolphins), ");
            response.Add("and the extinct Lipotidae (baiji or Chinese river dolphin). There are 40 extant species named as dolphins.");
            response.Add("Dolphins range in size from the relatively small 1.7 - metre - long(5 ft 7 in) long and 50 - kilogram(110 - pound) bodied Maui's dolphin ");
            response.Add("to the 9.5 m (31 ft 2 in) and 10-tonne (11-short-ton) killer whale. Dolphins can sometimes leap about 30 feet (9.1 m). ");
            response.Add("Several species of dolphins exhibit sexual dimorphism, in that the males are larger than females. They have streamlined bodies and two limbs that are modified into flippers.");
            response.Add("Though not quite as flexible as seals, some dolphins can travel at speeds 29 kilometres (18 mi) per hour for short distances.[1]");
            response.Add("Dolphins use their conical shaped teeth to capture fast-moving prey.");
        }
        else if (file == "TotallyNormal.txt")
        {
            response.Add("Seriously? Did you really think that the second hint would be this easy.");
            response.Add("Go check Fabio's research, there might be something interesting there.");
            response.Add("You might be reading for a while if you don't know what you're doing though.");
        }
        else if (file == "Dolphin_Research/Research_Notes_Part1.txt")
        {
            response.Add("First day on the water, witnessed a pod of dolphins feeding.");
            response.Add("The ocean is truely a sight to behold.");
        }
        else if (file == "Dolphin_Research/Research_Notes_Part2.txt")
        {
            response.Add("Just found a resting dolphin. It looks like it's having very sweet dreams.");
            response.Add("Rest well my graceful friend.");
        }
        else if (file == "Dolphin_Research/Research_Notes_Part3.txt")
        {
            response.Add("Ahhhh, the dolphins have begun breaching the waters surface.");
            response.Add("The sheen of their bodies is truely at its best when it is struck by the sun's light.");
        }
        else if (file == "Dolphin_Research/Research_Notes_Part4.txt")
        {
            response.Add("Being at the sea keeps me at ease. Much like the pod of dolphins that I am tracking.");
            response.Add("I cannot wait to return to land and write about my research.");
        }
        else
        {
            response.Add("Error: Must supply valid file name");
        }
        
        return response;
    }
    private List<string> tail(string file)
    {
        if (file == "Dolphin_Research/Report_Draft.doc")
        {
            response.Add("Dolphins have long played a role in human culture. Dolphins are sometimes used as symbols, for instance in heraldry.");
            response.Add("In Greek myths, dolphins were seen invariably as helpers of humankind. ");
            response.Add("Dolphins also seem to have been important to the Minoans, judging by artistic evidence from the ruined palace at Knossos.");
            response.Add("Head on over to the park to find something interesting detective.");
            response.Add("During the 2009 excavations of a major Mycenaean city at Iklaina, a striking fragment of a wall - paintings came to light, depicting a ship with three human figures and dolphins.");
            response.Add("Dolphins are common in Greek mythology, and many coins from ancient Greece have been found which feature a man, a boy or a deity riding on the back of a dolphin.[160] ");

            foundKillerFile = true;
        }
        else if (file == "TotallyNormal.txt")
        {
            response.Add("Seriously? Did you really think that the second hint would be this easy.");
            response.Add("Go check Fabio's research, there might be something interesting there.");
            response.Add("You might be reading for a while if you don't know what you're doing though.");
        }
        else if (file == "Dolphin_Research/Research_Notes_Part1.txt")
        {
            response.Add("First day on the water, witnessed a pod of dolphins feeding.");
            response.Add("The ocean is truely a sight to behold.");
        }
        else if (file == "Dolphin_Research/Research_Notes_Part2.txt")
        {
            response.Add("Just found a resting dolphin. It looks like it's having very sweet dreams.");
            response.Add("Rest well my graceful friend.");
        }
        else if (file == "Dolphin_Research/Research_Notes_Part3.txt")
        {
            response.Add("Ahhhh, the dolphins have begun breaching the waters surface.");
            response.Add("The sheen of their bodies is truely at its best when it is struck by the sun's light.");
        }
        else if (file == "Dolphin_Research/Research_Notes_Part4.txt")
        {
            response.Add("Being at the sea keeps me at ease. Much like the pod of dolphins that I am tracking.");
            response.Add("I cannot wait to return to land and write about my research.");
        }
        else
        {
            response.Add("Error: Must supply valid file name");
        }

        return response;
    }
}
