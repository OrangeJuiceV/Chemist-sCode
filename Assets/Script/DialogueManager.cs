using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public List<string> dialogueLines;

    public FirstPersonController fpc; // Riferimento al controller del personaggio

    private int currentLineIndex = 0;
    private bool isDialogueActive = false;

    private bool wasCameraMoving = true; // Salva lo stato originale

    void Start()
    {
        dialogueBox.SetActive(false); // Nasconde la finestra di dialogo all'avvio
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
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

        // Salva lo stato attuale del movimento della camera
        wasCameraMoving = fpc.cameraCanMove;

        // Disattiva movimento e blocca visuale solo se era attiva
        if (wasCameraMoving)
        {
            fpc.setIsWalking(false);
            fpc.changeActive();
            fpc.cameraCanMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
        // Ripristina il controllo solo se era attivo prima del dialogo
        if (wasCameraMoving)
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
