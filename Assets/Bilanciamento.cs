using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Bilanciamento : MonoBehaviour, IInteractable
{
    public Canvas schermata;
    public FirstPersonController fpc; // Reference to the player controller
    public GameObject inputFields; // Reference to the input fields for the balancing puzzle
    private bool isOpen = false; // Track if the hint screen is open

    private int[] solution = new int[] { 4, 3, 2, 2, 1, 2, 1, 5, 3, 4 }; // Solution
    public FifthDoor door; // Reference to the door to unlock
    void Start()
    {

    }
    public void CheckSolution()
    {
        TMP_InputField[] fields = inputFields.GetComponentsInChildren<TMP_InputField>();

        if (fields.Length != solution.Length)
        {
            Debug.LogWarning("Il numero di campi input non corrisponde alla soluzione.");
            return;
        }

        for (int i = 0; i < solution.Length; i++)
        {
            string inputText = fields[i].text.Trim();
            int userValue = 1;

            if (!string.IsNullOrEmpty(inputText))
            {
                if (!int.TryParse(inputText, out userValue))
                {
                    Debug.LogWarning($"Valore non numerico nel campo {i + 1}: \"{inputText}\"");
                    return;
                }
            }

            if (userValue != solution[i])
            {
                Debug.Log("Soluzione sbagliata!");
                return;
            }
        }

        Debug.Log("Soluzione corretta!");
        door.isLocked = false; // Sblocca la porta
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        schermata.gameObject.SetActive(true);
    }

    public void ExitInteraction()
    {
        isOpen = false;
        fpc.setIsWalking(true);
        fpc.changeActive();
        fpc.cameraCanMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        schermata.gameObject.SetActive(false);

        GameObject.FindFirstObjectByType<PauseMenu>().SetEscapeCooldown();
    }
}
