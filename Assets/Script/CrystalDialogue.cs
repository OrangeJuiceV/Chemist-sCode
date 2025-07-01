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
                dialogueManager.StartDialogue(new List<string> { "L�elettronegativit� misura quanto un atomo attira a s� gli elettroni in un legame. " +
                    "Pi� � in alto e a destra nella tavola, pi� � �avido�. Il fluoro, ad esempio, � il pi� attrattivo di tutti." }
                    );
                break;
        
        
        }
    }
}
