using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public List<string> dialogueLines;

    private int currentLineIndex = 0;
    private bool isDialogueActive = false;

    void Start()
    {
        dialogueBox.SetActive(false); // nasconde all'avvio
    }

    void Update()
    {
        if (isDialogueActive && Input.GetMouseButtonDown(0))
        {
            ShowNextLine();
        }
    }

    public void StartDialogue(List<string> lines)
    {
        dialogueLines = lines;
        currentLineIndex = 0;
        dialogueBox.SetActive(true);
        isDialogueActive = true;
        ShowLine();
    }

    void ShowLine()
    {
        if (currentLineIndex < dialogueLines.Count)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
        }
    }

    void ShowNextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Count)
        {
            ShowLine();
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        isDialogueActive = false;
    }
}
