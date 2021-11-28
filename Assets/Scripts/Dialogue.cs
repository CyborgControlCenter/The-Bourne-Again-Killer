using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI nameDisplay;
    public GameObject dialogueFrame;
    public Dialogue nextCharacter;
     [TextArea(3,20)]
    public string[] sentences;
    public string CharacterName;
    private int index;
    public float typingSpeed;

    public Button nextButton;
    public Button previousButton;
    public Button skipButton;
    void Start()
    {
        nameDisplay.text = CharacterName;
        dialogueFrame.SetActive(true);
        StartCoroutine(Type());
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            nextButton.interactable = true;
            previousButton.interactable = true;
            skipButton.interactable = true;
        }
        else
        {
            nextButton.interactable = false;
            previousButton.interactable = false;
            skipButton.interactable = false;
        }
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    // IEnumerator LoadNextCharacterDialogue()
    // {
    // }
    // IEnumerator LoadNextScene()
    // {
    // }
    public void NextSentence()
    {

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = sentences[index];
            if(nextCharacter != null)
            {
                nextCharacter.dialogueFrame.SetActive(true);
                dialogueFrame.SetActive(false);
            }
            else if(nextCharacter == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
        }
    }
    public void PreviousSentence()
    {

        if(!(index == 0))
        {
            --index;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else if(index == 0)
        {
            textDisplay.text = sentences[0];
        }
    }
    public void SkipSentences()
    {
        if(index < sentences.Length - 1)
        {
            index = sentences.Length - 1;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = sentences[index];
            if(nextCharacter != null)
            {
                nextCharacter.dialogueFrame.SetActive(true);
                dialogueFrame.SetActive(false);
            }
            else if(nextCharacter == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
        }
    }
}
