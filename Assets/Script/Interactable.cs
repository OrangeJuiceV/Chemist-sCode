using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float rotationAngle = -90f;              // Gradi totali da ruotare
    public float rotationSpeed = 180f;              // Gradi al secondo
    public Vector3 rotationAxis = -Vector3.up;      // Asse di rotazione (Y)

    private bool isMoving = false;                 // Sta ruotando
    private bool isOpen = false;                   // È aperta?
    private float rotated = 0f;                    // Tracciamento rotazione
    private float initialRotation;                 // Salvataggio rotazione iniziale

    void Start()
    {
        // Salviamo la rotazione iniziale quando il gioco inizia
        initialRotation = transform.eulerAngles.y;
    }

    void Update()
    {
        if (isMoving)
        {
            float deltaRotation = - rotationSpeed * Time.deltaTime;

            if (!isOpen)
            {
                // Apertura
                if (rotated + deltaRotation > rotationAngle)
                    deltaRotation = rotationAngle - rotated;

                transform.Rotate(rotationAxis, deltaRotation);
                rotated -= deltaRotation;

                if (rotated >= rotationAngle)
                {
                    isMoving = false;
                    isOpen = true;
                    Debug.Log(rotated);
                    Debug.Log(deltaRotation);
                }
            }
            else
            {
                // Chiusura
                if (rotated - deltaRotation < 0)
                    deltaRotation = rotated;  // Fai in modo che non vada sotto lo zero.

                transform.Rotate(rotationAxis, -deltaRotation);
                rotated += deltaRotation;

                if (rotated <= 0)  // Quando la porta è chiusa, fermati
                {
                    isMoving = false;
                    isOpen = false;
                    rotated = 0; // Assicurati che 'rotated' sia esattamente 0
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, initialRotation, transform.eulerAngles.z); // Riporta la porta alla rotazione iniziale
                }
            }
        }
    }

    public virtual void Interact()
    {
        if (!isMoving)
        {
            isMoving = true;
            Debug.Log((isOpen ? "Closing: " : "Opening: ") + gameObject.name);
        }
    }
}
