using UnityEngine;
using TMPro;

public class Workbench : MonoBehaviour
{
    private GameObject player;

    // Public Collider to assign in Inspector
    public Collider workbenchCollider;
    
    public TextMeshPro messageText;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        // Make sure the collider is assigned
        if (workbenchCollider == null)
        {
            Debug.LogWarning("Workbench Collider is not assigned!");
        }

        if (messageText == null)
        {
            Debug.LogError("messageText is not assigned!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        // Check if the player has entered the trigger
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected in trigger.");
            messageText.gameObject.SetActive(true); // Show text
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited by: " + other.name);

        // Check if the player has exited the trigger
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left the workbench trigger.");
            messageText.gameObject.SetActive(false); // Hide text
        }
    }
}
