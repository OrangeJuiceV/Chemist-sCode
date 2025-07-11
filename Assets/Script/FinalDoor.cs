using UnityEngine;
using System.Collections.Generic;

public class FinalDoor : MonoBehaviour, IInteractable
{
    public DialogueManager dialogueManager;
    public GameObject container; // Ha 1 figlio con i 5 elementi
    public bool isLocked = true;
    public GameObject LeftDoor;
    public GameObject RightDoor;

    private const float LEFT_CLOSED = 0.0f;
    private const float LEFT_OPEN = 1.928f;
    private bool isOpening = false;
    private bool isMoving = false;
    private bool isOpen = false;
    private float openingSpeed = 2.0f;

    public void Update()
    {
        if (!isMoving) return;

        if (isOpening)
        {
            if (LeftDoor.transform.localPosition.z < LEFT_OPEN)
            {
                LeftDoor.transform.localPosition += new Vector3(0, 0, openingSpeed * Time.deltaTime);
                RightDoor.transform.localPosition -= new Vector3(0, 0, openingSpeed * Time.deltaTime);
            }
            else
            {
                isMoving = false;
                isOpen = true;
                isOpening = false;
            }
        }
        else
        {
            if (LeftDoor.transform.localPosition.z > LEFT_CLOSED)
            {
                LeftDoor.transform.localPosition -= new Vector3(0, 0, openingSpeed * Time.deltaTime);
                RightDoor.transform.localPosition += new Vector3(0, 0, openingSpeed * Time.deltaTime);
            }
            else
            {
                isMoving = false;
                isOpen = false;
                isOpening = false;
            }
        }
    }

    public void Interact()
    {
        container.SetActive(true);

        if (container.transform.childCount == 0)
        {
            Debug.LogWarning("Il container non ha figli!");
            container.SetActive(false);
            return;
        }

        Transform elementiParent = container.transform.GetChild(0);
        bool allElementsActive = true;

        for (int i = 0; i < elementiParent.childCount; i++)
        {
            Transform child = elementiParent.GetChild(i);
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
                    "Okay… proviamo con il tablet.",
                    "…",
                    "Sta succedendo qualcosa… si sta aprendo!",
                    "Ora ricordo… tutto. Gli elementi, i legami, le reazioni… Non era solo chimica. Era parte di me"
                });
                container.SetActive(false);
                return;
            }
            else
            {
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

        container.SetActive(false);
    }
}
