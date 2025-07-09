using UnityEngine;
using System.Collections.Generic;

public class Indizio1 : MonoBehaviour, IInteractable
{
    public Canvas schermataIndizio;
    public FirstPersonController fpc; // Reference to the player controller

    private bool isOpen = false; // Track if the hint screen is open
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool hasDialogue; // Flag to indicate if the object has dialogue
    public int whichDialogue;
    public DialogueManager dialogueManager; // Reference to the DialogueManager
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitInteraction();
        }
    }

    public void Interact()
    {
        isOpen = true;

        fpc.setIsWalking(false);
        fpc.changeActive();
        fpc.cameraCanMove = false;

        schermataIndizio.gameObject.SetActive(true);
    }

    [System.Obsolete]
    public void ExitInteraction()
    {
        isOpen = false;
        fpc.setIsWalking(true);
        fpc.changeActive();
        fpc.cameraCanMove = true;
        schermataIndizio.gameObject.SetActive(false);

        GameObject.FindObjectOfType<PauseMenu>().SetEscapeCooldown();
        if (hasDialogue && dialogueManager != null)
        {
            if (whichDialogue == 1)
                dialogueManager.StartDialogue(new List<string> { "Colonne...? Mi dice qualcosa... dai, pensa... perché non riesco a ricordare?" });
            if (whichDialogue == 2)
                dialogueManager.StartDialogue(new List<string> { 
                    "Strano... una tavola periodica vuota, in alcune caselle ci sono… immagini?",
                    "Delle monete... un palloncino...non capisco, ma... forse posso usarla in qualche modo?"
                });
        }
        else if (dialogueManager == null)
        {
            Debug.LogWarning("DialogueManager non assegnato a Indizio1.");
        }
    }
}
