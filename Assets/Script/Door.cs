using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public float rotationAngle = -90f;               // Gradi totali da ruotare
    public float rotationSpeed = 180f;               // Gradi al secondo
    public Vector3 rotationAxis = Vector3.up;        // Asse di rotazione (usa negativo se vuoi direzione opposta)

    private bool isMoving = false;
    private bool isOpen = false;
    private float rotated = 0f;
    private float initialRotation;
    private Collider doorCollider;
    public bool isLocked;
    public bool isSliding; // Aggiunto per gestire porte scorrevoli

    private const float SLIDING_OPEN = - 1.21f;
    private const float SLIDING_CLOSED = 0.0f;
    private float slidingOpeningSpeed = 2.0f; // Velocità di apertura per porte scorrevoli

    public DialogueManager dialogueManager; // Aggiunto per gestire il dialogo quando  la porta è bloccata
    public ObjectiveStory objectiveStory; // Riferimento all'ObjectiveStory script
    private bool firstUse = true; // Flag per tracciare il primo utilizzo
    public bool hasToUpdateObjective;
    public int objectiveToUpdate; // Obiettivo da aggiornare al primo utilizzo


    void Start()
    {
        initialRotation = transform.eulerAngles.y;
        doorCollider = GetComponent<Collider>(); // oppure BoxCollider, se vuoi specificare
    }

    void Update()
    {
        if (!isMoving)
        {
            if (doorCollider != null)
                doorCollider.enabled = true;
            return;
        }
        else
        {
            if (doorCollider != null)
                doorCollider.enabled = false;
        }

        float deltaRotation = rotationSpeed * Time.deltaTime;

        if (!isSliding)
        {
            if (!isOpen)
            {
                // Apertura
                if (rotated + deltaRotation > Mathf.Abs(rotationAngle))
                    deltaRotation = Mathf.Abs(rotationAngle) - rotated;

                transform.Rotate(rotationAxis, Mathf.Sign(rotationAngle) * deltaRotation);
                rotated += deltaRotation;

                if (rotated >= Mathf.Abs(rotationAngle))
                {
                    isMoving = false;
                    isOpen = true;
                }
            }
            else
            {
                // Chiusura
                if (rotated - deltaRotation < 0)
                    deltaRotation = rotated;

                transform.Rotate(rotationAxis, -Mathf.Sign(rotationAngle) * deltaRotation);
                rotated -= deltaRotation;

                if (rotated <= 0)
                {
                    isMoving = false;
                    isOpen = false;
                    rotated = 0;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, initialRotation, transform.eulerAngles.z);
                }
            }
        }
        else
        {
            if (!isOpen)
            {
                if (gameObject.transform.localPosition.z > SLIDING_OPEN)
                {
                    gameObject.transform.localPosition += new Vector3(0, 0, -Mathf.Sign(slidingOpeningSpeed) * Time.deltaTime);
                }
                else
                {
                    isMoving = false;
                    isOpen = true;
                }
            }
            else
            {
                if (gameObject.transform.localPosition.z < SLIDING_CLOSED)
                {
                    gameObject.transform.localPosition += new Vector3(0, 0, slidingOpeningSpeed * Time.deltaTime);
                }
                else
                {
                    isMoving = false;
                    isOpen = false;
                    gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, SLIDING_CLOSED);
                }
            }
        }
    }

    public virtual void Interact()
    {
        if (isLocked)
        {
            dialogueManager.StartDialogue(new List<string>
            {
                "E' bloccata! Trova un modo per aprirla"
            });
            objectiveStory.StartCoroutine(objectiveStory.updateTo8th());
            return;
        }
        if (firstUse && hasToUpdateObjective)
        {
            switch (objectiveToUpdate)
            {
                case 0:
                    objectiveStory.StartCoroutine(objectiveStory.updateTo5th());
                    firstUse = false; // Imposta il flag per evitare che venga eseguito di nuovo
                    break;
                case 1:
                    objectiveStory.StartCoroutine(objectiveStory.updateTo9th());
                    firstUse = false; // Imposta il flag per evitare che venga eseguito di nuovo
                    break;
                case 2:
                    objectiveStory.StartCoroutine(objectiveStory.updateTo11th());
                    firstUse = false; // Imposta il flag per evitare che venga eseguito di nuovo
                    break;
            }
        }
        if (!isMoving)
        {
            if (isSliding)
                AudioManager.PlaySciFiDoor(); // Riproduce il suono della porta
            else
                AudioManager.PlayNormalDoor(); // Riproduce il suono della porta
            isMoving = true;
            Debug.Log((isOpen ? "Closing: " : "Opening: ") + gameObject.name);
        }
    }
}
