using UnityEngine;
using System.Collections.Generic;

public class Last1LevelDoor : MonoBehaviour, IInteractable
{
    public DialogueManager dialogueManager;
    public GameObject container; // Ha 1 figlio con i 5 elementi
    public bool isLocked = true;
    public void Interact()
    {
        // Attiva temporaneamente il container per accedere ai figli
        container.SetActive(true);

        // Controllo base: container deve avere almeno un figlio
        if (container.transform.childCount == 0)
        {
            Debug.LogWarning("Il container non ha figli!");
            container.SetActive(false); // Disattiva alla fine comunque
            return;
        }

        Transform elementiParent = container.transform.GetChild(0);
        bool allElementsActive = true;

        foreach (Transform child in elementiParent)
        {
            if (!child.gameObject.activeSelf)
            {
                allElementsActive = false;
                break;
            }
        }

        if (allElementsActive)
        {
            if (isLocked)
            {
                isLocked = false;
                dialogueManager.StartDialogue(new List<string> {
                    "È chiusa… aspetta un attimo…C’è uno spazio qui… sembra fatto apposta per il tablet. Interessante. Fammi provare…",
                    "Funziona! La tavola... era la chiave. Finalmente"
                });

                // Esempio: GetComponent<Animator>().SetTrigger("Open");
            }
            else
            {
                dialogueManager.StartDialogue(new List<string> {
                    "La porta è già aperta."
                });
            }
        }
        else
        {
            dialogueManager.StartDialogue(new List<string> {
                "È chiusa… aspetta un attimo…C’è uno spazio qui… sembra fatto apposta per il tablet. Interessante. Fammi provare…",
                "Non succede nulla, manca qualcosa"
            });
        }

        // Disattiva nuovamente il container dopo il check
        container.SetActive(false);
    }
}
