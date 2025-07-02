using UnityEngine;
using System.Collections.Generic;

public class PeriodicElement : MonoBehaviour, IInteractable
{
    public int elementID;

    public DialogueManager dialogueManager;
    public Door door3rdEnigma;
    public Light light3rdEnigma;

    public void Interact()
    {
        gameObject.SetActive(false); // Disattiva l'oggetto PeriodicElement  

        switch (elementID)
        {
            case 0: // Elio
                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(new List<string> {
                        "Ecco perché il palloncino volava, era pieno di Elio"
                    });
                }
                else
                {
                    Debug.LogWarning("DialogueManager non assegnato al PeriodicElement.");
                }
                break;

            case 1: // Terzo enigma
                if (door3rdEnigma != null)
                {
                    door3rdEnigma.isLocked = false;
                }
                else
                {
                    Debug.LogWarning("door3rdEnigma non assegnata.");
                }

                if (light3rdEnigma != null)
                {
                    light3rdEnigma.color = Color.green;
                }
                else
                {
                    Debug.LogWarning("light3rdEnigma non assegnata.");
                }
                break;
        }
    }
}
