using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class CrystalDialogue : MonoBehaviour, IInteractable
{

    public DialogueManager dialogueManager; // Reference to the DialogueManager script
    public int typeOfCrystal; // Type of crystal to determine the dialogue
    public void Interact()
    {
        switch (typeOfCrystal)
        {
            case 0: // Cristallo brama
                dialogueManager.StartDialogue(new List<string> { "L’elettronegatività misura quanto un atomo attira a sé gli elettroni in un legame. " +
                    "Più è in alto e a destra nella tavola, più è “avido”. Il fluoro, ad esempio, è il più attrattivo di tutti." }
                    );
                break;
        
        
        }
    }
}
