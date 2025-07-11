using UnityEngine;
using System.Collections.Generic;

public class Last1LevelDoor : MonoBehaviour, IInteractable
{
    public DialogueManager dialogueManager;
    public GameObject container; // Ha 1 figlio con i 5 elementi
    public bool isLocked = true;
    public GameObject LeftDoor;
    public GameObject RightDoor;

    private const float LEFT_CLOSED = 0.0f;
    private const float LEFT_OPEN = 1.928f;
    private bool isOpening = false;
    private bool isMoving = false; // Per gestire lo stato di movimento delle porte
    private bool isOpen = false;   // Stato attuale della porta (aperta o chiusa)
    private float openingSpeed = 2.0f; // Velocità di apertura per porte scorrevoli

    public ObjectiveStory objectiveStory; // Riferimento all'ObjectiveStory script

    public void Update()
    {
        if (!isMoving) return;

        if (isOpening)
        {
            // Apertura porte scorrevoli
            if (LeftDoor.transform.localPosition.z < LEFT_OPEN)
            {
                LeftDoor.transform.localPosition += new Vector3(0, 0, openingSpeed * Time.deltaTime);
                RightDoor.transform.localPosition -= new Vector3(0, 0, openingSpeed * Time.deltaTime);
            }
            else
            {
                // Apertura completata
                isMoving = false;
                isOpen = true;
                isOpening = false;
            }
        }
        else
        {
            // Chiusura porte scorrevoli
            if (LeftDoor.transform.localPosition.z > LEFT_CLOSED)
            {
                LeftDoor.transform.localPosition -= new Vector3(0, 0, openingSpeed * Time.deltaTime);
                RightDoor.transform.localPosition += new Vector3(0, 0, openingSpeed * Time.deltaTime);
            }
            else
            {
                // Chiusura completata
                isMoving = false;
                isOpen = false;
                isOpening = false;
            }
        }
    }

    public void Interact()
    {
        // Attiva temporaneamente il container per accedere ai figli
        container.SetActive(true);

        // Controllo base: container deve avere almeno un figlio
        if (container.transform.childCount == 0)
        {
            Debug.LogWarning("Il container non ha figli!");
            container.SetActive(false);
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
                objectiveStory.StartCoroutine(objectiveStory.updateTo7th());
                isOpening = true;
                isMoving = true;
            }
            else
            {
                // Toggle apertura/chiusura
                isOpening = !isOpen;
                isMoving = true;
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
