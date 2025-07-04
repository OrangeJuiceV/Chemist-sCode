using UnityEngine;

public class Indizio1 : MonoBehaviour, IInteractable
{
    public Canvas schermataIndizio;
    public FirstPersonController fpc; // Reference to the player controller

    private bool isOpen = false; // Track if the hint screen is open
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitInteraction();
        }
    }

    public void Interact()
    {
        isOpen = true;

        fpc.setIsWalking(false);
        fpc.changeActive();
        fpc.cameraCanMove = false;

        schermataIndizio.gameObject.SetActive(true);
    }

    [System.Obsolete]
    public void ExitInteraction()
    {
        isOpen = false;
        fpc.setIsWalking(true);
        fpc.changeActive();
        fpc.cameraCanMove = true;
        schermataIndizio.gameObject.SetActive(false);

        GameObject.FindObjectOfType<PauseMenu>().SetEscapeCooldown();

    }
}
