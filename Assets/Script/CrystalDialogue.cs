using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class CrystalDialogue : MonoBehaviour, IInteractable
{

    public DialogueManager dialogueManager; // Reference to the DialogueManager script
    public int typeOfCrystal; // Type of crystal to determine the dialogue
    public bool isActive;
    public void Interact()
    {
        if (!isActive)
        {
            dialogueManager.StartDialogue(new List<string> {
                "Sembra che questo cristallo non sia attivo al momento...",
                "Forse c'� qualcosa da fare prima?"
            });
            return;
        }

        switch (typeOfCrystal)
        {
            case 0: // Cristallo brama
                dialogueManager.StartDialogue(new List<string> { "L�elettronegativit� misura quanto un atomo attira a s� gli elettroni in un legame. " +
                    "Pi� � in alto e a destra nella tavola, pi� � �avido�. Il fluoro, ad esempio, � il pi� attrattivo di tutti." }
                    );
                break;

            case 1: // Cristallo forma
                dialogueManager.StartDialogue(new List<string> {
                    "Pi� un atomo scende nel suo gruppo, pi� si allarga nella sua veste. La sua forma cresce con i livelli che lo separano dal nucleo."
                });
                break;

            case 2: // Cristallo resistenza
                dialogueManager.StartDialogue(new List<string> {
                    "Alcuni elementi cedono facilmente ci� che possiedono� altri resistono con forza. Trova chi stringe i suoi pochi elettroni come un tesoro."
                });
                break;

        }
    }
}
