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
                "Forse c'è qualcosa da fare prima?"
            });
            return;
        }

        switch (typeOfCrystal)
        {
            case 0: // Cristallo brama
                dialogueManager.StartDialogue(new List<string> { "Alcuni elementi attirano gli elettroni più di altri. Più si sale a destra nella tavola… più diventano affamati." }
                    );
                break;

            case 1: // Cristallo forma
                dialogueManager.StartDialogue(new List<string> {
                    "Più un atomo scende nel suo gruppo, più si espande. Ogni nuovo livello lo allontana dal nucleo… e la sua veste si fa sempre più ampia."
                });
                break;

            case 2: // Cristallo resistenza
                dialogueManager.StartDialogue(new List<string> {
                    "Nella tavola, chi è a destra tiene stretti i suoi elettroni. Chi è in basso… li lascia andare più facilmente. Guarda la posizione, e capirai chi resiste di più."
                });
                break;

        }
    }
}
