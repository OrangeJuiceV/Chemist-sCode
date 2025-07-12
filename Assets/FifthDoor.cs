using UnityEngine;
using System.Collections.Generic;

public class FifthDoor : MonoBehaviour, IInteractable
{
    public DialogueManager dialogueManager;
    public bool isLocked = true;
    public GameObject LeftDoor;
    public GameObject RightDoor;

    private const float LEFT_CLOSED = 0.0f;
    private const float LEFT_OPEN = 1.928f;
    private bool isOpening = false;
    private bool isMoving = false; // Per gestire lo stato di movimento delle porte
    private bool isOpen = false;   // Stato attuale della porta (aperta o chiusa)
    private float openingSpeed = 2.0f; // Velocità di apertura per porte scorrevoli
        
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

        if (isLocked)
        {
            // Mostra il dialogo di sblocco
            dialogueManager.StartDialogue(new List<string> { "La porta è bloccata. Devo trovare il modo per aprirla." });
        }
        else if (!isMoving)
        {
            AudioManager.PlaySciFiDoor(); // Riproduce il suono della porta
            // Inizia l'apertura o la chiusura della porta
            isOpening = !isOpen; // Inverti lo stato di apertura
            isMoving = true; // Imposta lo stato di movimento
        }


    }
}
