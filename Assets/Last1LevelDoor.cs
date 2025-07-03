using UnityEngine;
using System.Collections.Generic;

public class Last1LevelDoor : MonoBehaviour, IInteractable
{

    public DialogueManager dialogueManager; // Reference to the DialogueManager
    public bool isLocked = true; // Track if the door is locked

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    { 
        if (isLocked)
        {
            dialogueManager.StartDialogue(new List<string> {
                "La porta è bloccata!",
                "Trova tutti gli elementi della tavola mancanti per sbloccarla."
            }); // Start the dialogue for locked door
        }
    
    }
}
