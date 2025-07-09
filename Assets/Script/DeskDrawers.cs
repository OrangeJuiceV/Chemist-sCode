using UnityEngine;
using System.Collections.Generic;

public class DeskDrawers : MonoBehaviour, IInteractable
{
    private bool isMoving = false;
    private bool isOpen = false;
    public bool isLocked;
    private const float CLOSED_X = -0.156f;
    private const float OPEN_X = 0.328f;
    private float speed = 1f; // velocità movimento in unità al secondo

    public DialogueManager dialogueManager;
    public ObjectiveStory objectiveStory; // Riferimento all'ObjectiveStory script
    private bool firstUse = true; // Flag per tracciare il primo utilizzo
    void Update()
    {
        if (isMoving)
        {
            Vector3 currentPos = transform.localPosition;
            float targetX;

            if (isOpen)
            {
                // Se il cassetto è aperto, target è la posizione chiusa
                targetX = CLOSED_X;
            }
            else
            {
                // Se il cassetto è chiuso, target è la posizione aperta
                targetX = OPEN_X;
            }

            // Muovi il cassetto verso il target
            float newX = Mathf.MoveTowards(currentPos.x, targetX, speed * Time.deltaTime);
            transform.localPosition = new Vector3(newX, currentPos.y, currentPos.z);

            // Quando raggiunge il target, ferma il movimento e cambia stato
            if (Mathf.Approximately(newX, targetX))
            {
                isMoving = false;
                isOpen = !isOpen; // Inverte lo stato: aperto <-> chiuso
            }
        }
    }

    public void Interact()
    {
        if (firstUse)
        {
            objectiveStory.StartCoroutine(objectiveStory.updateTo5th());
            firstUse = false; // Imposta il flag per evitare che venga eseguito di nuovo
        }
        if (!isMoving && !isLocked)
        {
            isMoving = true; // Inizia il movimento
        }
        else
        {
            if (dialogueManager != null)
            {
                dialogueManager.StartDialogue(new List<string>{
                "Il cassetto è chiuso devo trovare un modo per aprirlo"
            });
            }
            else
            {
                Debug.LogWarning("DialogueManager non assegnato nel DeskDrawers!");
            }
        }
    }

}
