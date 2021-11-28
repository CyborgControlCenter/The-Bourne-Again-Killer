using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class TerminalManager : MonoBehaviour
{
    public GameObject directoryLine;
    public GameObject responseLine;
    public InputField terminalInput;
    public GameObject userInputLine;
    public ScrollRect scrollRect;
    public GameObject msgList;
    Interpreter interpreter;
    private void Start()
    {
        interpreter = GetComponent<Interpreter>();
    }
    private void OnGUI()
    {        
        if(terminalInput.isFocused && terminalInput.text != "" && Input.GetKeyDown(KeyCode.Return))
        {
            // Store what the user typed
            string userInput = terminalInput.text;
            
            // Clear the input field
            ClearInputField();

            // Instantiate a gameobject with a directory prefix
            AddDirectoryLine(userInput);

            // Add the interpretation lines
            int lines = AddInterpreterLines(interpreter.Interpret(userInput));

            // Scroll to bottom of scrollrect
            ScrollToBottom(lines);

            // Move user input line to the end.
            userInputLine.transform.SetAsLastSibling();

            // Refocus the input field
            terminalInput.ActivateInputField();
            terminalInput.Select();
        }
    }

    void ClearInputField()
    {
        terminalInput.text = "";
    }

    void AddDirectoryLine(string userInput)
    {
        // Resizing the command line container, so the scrollRect doesn't throw a fit.
        Vector2 msgListSize = msgList.GetComponent<RectTransform>().sizeDelta;
        msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 35.0f);

        // Instantiate the directory line.
        GameObject msg = Instantiate(directoryLine, msgList.transform);

        // Set its child index.
        msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);

        // Set the text of this new gameobject.
        msg.GetComponentsInChildren<Text>()[1].text = userInput;
    }

    int AddInterpreterLines(List<string> interpretation)
    {
        foreach(string line in interpretation)
        {
            // Instantiate the response line.
            GameObject res = Instantiate(responseLine, msgList.transform);

            // Set it to the end of all the messages
            res.transform.SetAsLastSibling();

            // Get the size of the message list, and resize
            Vector2 listSize = msgList.GetComponent<RectTransform>().sizeDelta;
            msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(listSize.x, listSize.y + 35.0f);

            // Set the text of this reponse line to be whatever the interpretor string is.
            res.GetComponentInChildren<Text>().text = line;
        }

        return interpretation.Count;  
    }

    void ScrollToBottom(int lines)
    {
        if(lines > 4)
        {
            scrollRect.velocity = new Vector2(0,450);
        }
        else
        {
            scrollRect.verticalNormalizedPosition = 0;
        }
    }
}
