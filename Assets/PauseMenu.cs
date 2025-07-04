using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public FirstPersonController fpc; // Reference to the FirstPersonController script
    public GameObject WholeMenu; // Reference to the whole menu GameObject
    public GameObject PauseMenuUI; // Reference to the UI GameObject for the pause menu
    public GameObject HelpUI; // Reference to the help UI GameObject
    public GameObject QuitUI; // Reference to the quit confirmation UI GameObject

    public bool isGamePaused = false; // Track if the game is paused
    private float escapeCooldown = 0f; // Cooldown to prevent double Escape input

    void Update()
    {
        // Cooldown to prevent handling Escape input immediately after exiting interaction
        if (escapeCooldown > 0f)
        {
            escapeCooldown -= Time.unscaledDeltaTime;
            return;
        }

        // If the game is paused and Escape is pressed again, resume
        if (isGamePaused && Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenuUI.activeSelf)
            {
                riprendi();
            }
            return;
        }

        // If the game is not paused and Escape is pressed, open the pause menu
        if (fpc.playerCanMove && Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = true;
            fpc.setIsWalking(false);
            fpc.changeActive();
            fpc.cameraCanMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            WholeMenu.SetActive(true);
            PauseMenuUI.SetActive(true);
        }
    }

    public void riprendi()
    {
        isGamePaused = false;
        WholeMenu.SetActive(false);
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

    public void quitGame()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    // Called from external script (e.g., Computer) after exiting interaction
    public void SetEscapeCooldown()
    {
        escapeCooldown = 0.2f; // 200 ms
    }
}
