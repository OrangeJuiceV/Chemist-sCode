using UnityEngine;
using UnityEngine.SceneManagement;

public class Finale : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0); // Carica la scena con build index 0
    }
}
