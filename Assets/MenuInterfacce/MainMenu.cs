using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI; // Reference to the main menu UI GameObject
    public GameObject creditsUI; // Reference to the credits UI GameObject
    public GameObject quitUI; // Reference to the quit confirmation UI GameObject

    void Start()
    {
        AudioManager.PlayMainMenuMusic(); // Play the main menu music
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    { 
        Application.Quit(); // Quit the application
    }

    public void QuitScreen()
    { 
        mainMenuUI.SetActive(false); // Hide the main menu UI
        quitUI.SetActive(true); // Show the quit confirmation UI
    }
    public void BackToMainMenu()
    {
        quitUI.SetActive(false); // Hide the quit confirmation UI
        mainMenuUI.SetActive(true); // Show the main menu UI
        creditsUI.SetActive(false); // Hide the credits UI
    }
    public void ShowCredits()
    {
        mainMenuUI.SetActive(false); // Hide the main menu UI
        creditsUI.SetActive(true); // Show the credits UI
    }
    public void StartGame()
    {
        AudioManager.StopMainMenuMusic(); // Stop the main menu music
        SceneManager.LoadScene("Game");
    }
}
