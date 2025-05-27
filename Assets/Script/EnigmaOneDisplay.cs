using UnityEngine;
using UnityEngine.UI;

public class EnigmaOneDisplay : MonoBehaviour, IInteractable
{
    public GameObject buttonObject;
    private Canvas canvasComponent;
    private RectTransform rectTransform;
    private bool imUsingIt = false;
    public GameObject doneButton;
    // Salvataggio dei valori originali
    private Vector3 originalPosition;
    private Vector3 originalScale;
    private Quaternion originalRotation;
    private GameObject[] childrenButtons;
    public FirstPersonController fpc;
    private bool[] solution = {true,true,false,false,false,false,true,false,true};

    // This Enigma unlocks a door
    public Door doorClass;
    void Start()
    {
        Transform child = this.transform.GetChild(0);
        canvasComponent = child.GetComponent<Canvas>();
        rectTransform = child.GetComponent<RectTransform>();
	    // get buttons array
        Transform buttons = buttonObject.transform;
        int childcount = buttons.childCount;
        childrenButtons = new GameObject[childcount];
        for (int i = 0; i < childcount; i++)
        {
            childrenButtons[i] = buttons.GetChild(i).gameObject;
        }


        if (canvasComponent == null)
        {
            Debug.LogError("Canvas component not found in child object.");
            return;
        }

        // Salva i valori iniziali del RectTransform
        originalPosition = rectTransform.localPosition;
        originalScale = rectTransform.localScale;
        originalRotation = rectTransform.localRotation;
    }

    void Update()
    {
        if (!imUsingIt) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Quit();
        }
    }
    
    public void submitAnswer() 
    {
        bool enigmaCompleted = true;
        for (int i = 0; i < 9; i++)
        {
            Toggle toggle = childrenButtons[i].GetComponent<Toggle>();
            if (toggle == null || solution[i] != toggle.isOn)
            {
                enigmaCompleted = false;
                break; // esci al primo errore
            }
        }

        if (enigmaCompleted)
        {
            Debug.Log("Enigma risolto!");
            // Esegui azioni per completamento enigma (suoni, animazioni, ecc.)
            doorClass.isLocked = false;
            Quit();
        }
        else
        {
            Debug.Log("Risposta errata.");
        }
    }

    public virtual void Interact()
    {
        imUsingIt = true;
        // settings on player
        fpc.setIsWalking(false);
        fpc.changeActive();
        // Disable player movement and control when interacting with the computer
        fpc.cameraCanMove = false;
        // Show and unlock the cursor
        Cursor.lockState = CursorLockMode.None;   // Unlock the cursor
        Cursor.visible = true;                    // Make the cursor visible

        // Passa a ScreenSpaceOverlay
        canvasComponent.renderMode = RenderMode.ScreenSpaceOverlay;

        // (opzionale) Puoi cambiare posizione e scala se vuoi centrato nello schermo
    }

    private void Quit()
    {
        imUsingIt = false;

        // Torna a WorldSpace
        canvasComponent.renderMode = RenderMode.WorldSpace;

        // Ripristina i valori originali
        rectTransform.localPosition = originalPosition;
        rectTransform.localScale = originalScale;
        rectTransform.localRotation = originalRotation;

        // Reactivate the player's movement and interaction (if needed)
        //fpc.isWalking = true;
        fpc.changeActive(); // Assuming this re-enables player controls
        fpc.cameraCanMove = true;
        // Hide and lock the cursor back to the center
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center
        Cursor.visible = false;                   // Make the cursor invisible
    }
}
