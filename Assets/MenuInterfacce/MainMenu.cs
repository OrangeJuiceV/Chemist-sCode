using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI; // Reference to the main menu UI GameObject
    public GameObject creditsUI; // Reference to the credits UI GameObject
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    { 
        Application.Quit(); // Quit the application
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
