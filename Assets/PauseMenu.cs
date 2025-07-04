using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public FirstPersonController fpc; // Reference to the FirstPersonController script
    public GameObject WholeMenu; // Reference to the whole menu GameObject
    public GameObject PauseMenuUI; // Reference to the UI GameObject for the pause menu
    public GameObject HelpUI; // Reference to the help UI GameObject
    public GameObject QuitUI; // Reference to the quit confirmation UI GameObject

    public bool isGamePaused = false; // Track if the game is paused

    // Update is called once per frame
    void Update()
    {

        if (isGamePaused && Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenuUI.activeSelf)
            {
                riprendi(); // Call the method to resume the game
            }
            return;
        }


        if (fpc.playerCanMove && Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = true; // Set the game as paused
            // blocks the player from moving
            fpc.setIsWalking(false);
            fpc.changeActive();
            fpc.cameraCanMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // Show the pause menu UI
            WholeMenu.SetActive(true);
            PauseMenuUI.SetActive(true);
        }



    }




    public void riprendi()
    { 
        isGamePaused = false; // Set the game as not paused
        WholeMenu.SetActive(false);
        // Unlock the player movement
        fpc.setIsWalking(true);
        fpc.changeActive();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fpc.cameraCanMove = true;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void backToMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        HelpUI.SetActive(false);
        QuitUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }

    public void openHelp()
    {
        EventSystem.current.SetSelectedGameObject(null);
        PauseMenuUI.SetActive(false);
        HelpUI.SetActive(true);
    }

    public void sureToQuit()
    {
        EventSystem.current.SetSelectedGameObject(null);
        PauseMenuUI.SetActive(false);
        QuitUI.SetActive(true);
    }
}
