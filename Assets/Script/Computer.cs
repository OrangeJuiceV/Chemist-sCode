using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    public Camera focusCamera;
    public GameObject schermo;
    public Transform monitorCenter;
    private bool imUsing = false;
    public bool isOn;

    public Canvas canvas;
    private Quaternion oldCamRot; // Store the camera's rotation

    private Vector3 posSchermo;
    // private float focusSpeed = 5.0f; // Lower speed for smooth camera transition

    public FirstPersonController fpc; // Reference to your first person controller

    void Start() 
    {
        posSchermo = schermo.transform.position;
        posSchermo.z += 0.5f; 
        Debug.Log($"Screen position: {posSchermo}");
    }

    void Update()
    {
        // Check for Escape key to exit interaction
        if (imUsing && Input.GetKeyDown(KeyCode.F))
        {
            ExitInteraction();
        }
    }

    private void setCamera()
    {
        if (monitorCenter == null || focusCamera == null)
        {
            Debug.LogWarning("Missing monitorCenter or focusCamera reference.");
            return;
        }

        // Posiziona la camera vicino allo schermo
        focusCamera.transform.position = posSchermo;

        // Imposta la rotazione iniziale per guardare il monitor
        focusCamera.transform.LookAt(monitorCenter);

        // Aggiungi una rotazione leggera verso l'alto (modifica l'angolo su X, in questo caso +5 gradi)
        // Esegui un offset sulla rotazione della camera
        float tiltAngle = -40f;  // L'angolo di rotazione in gradi (aggiusta il valore secondo necessità)
        focusCamera.transform.rotation = focusCamera.transform.rotation * Quaternion.Euler(tiltAngle, 0, 0);
    }


    public virtual void Interact()
    {
        Debug.Log("Interacting w/ computer");
        imUsing = true; 
        fpc.setIsWalking(false);
        // Disable player movement and control when interacting with the computer
        fpc.changeActive(); // Assuming this disables the player movement
        fpc.cameraCanMove = false;
        // Show and unlock the cursor
        Cursor.lockState = CursorLockMode.None;   // Unlock the cursor
        Cursor.visible = true;                    // Make the cursor visible
        oldCamRot = focusCamera.transform.rotation;

        canvas.enabled = true;
        setCamera();
    }

    public void ExitInteraction()
    {
        // Reset camera to its original position and rotation
        focusCamera.transform.localPosition = Vector3.zero;
        focusCamera.transform.rotation = oldCamRot;

        // Reactivate the player's movement and interaction (if needed)
        fpc.changeActive(); // Assuming this re-enables player controls
        fpc.cameraCanMove = true;
        // Hide and lock the cursor back to the center
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center
        Cursor.visible = false;                   // Make the cursor invisible
        canvas.enabled = false;

        imUsing = false; // Exit interaction mode
    }
}
