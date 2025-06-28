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

    public FirstPersonController fpc; // Reference to your first person controller

    private bool wereStuck = false;

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

        if (fpc.cameraCanMove)
        {
            fpc.setIsWalking(false);
            fpc.changeActive();
            fpc.cameraCanMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else 
        {
            wereStuck = true;
        }
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
        if (!wereStuck) 
        {
            fpc.changeActive();
            fpc.cameraCanMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        dialogueBox.SetActive(false);
        isDialogueActive = false;
    }
}
