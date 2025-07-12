using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class ThirdComputer : MonoBehaviour, IInteractable
{
    public FirstPersonController fpc; // Reference to the FirstPersonController script

    public GameObject Frame1; // Reference to the first canvas
    public GameObject Frame2; // Reference to the second canvas
    public GameObject Frame3; // Reference to the third canvas
    public GameObject Frame4; // Reference to the fourth canvas
    public GameObject Frame5; // Reference to the fifth canvas
    public GameObject Frame6; // Reference to the sixth canvas
    public GameObject Frame7; // Reference to the seventh canvas
    public GameObject Frame8; // Reference to the eighth canvas

    private int lastFrameShown = 0; // Variable to track the last frame shown

    public Toggle Fplus; // Toggle for F+
    public Toggle Fminus; // Toggle for F-
    public Toggle Bplus; // Toggle for B+
    public Toggle Bminus; // Toggle for B-
    public Toggle Splus; // Toggle for S+
    public Toggle Sminus; // Toggle for S-
    public Toggle Foplus; // Toggle for Fop+
    public Toggle Fominus; // Toggle for Fom-

    private bool[] userTry = new bool[4]; // Array to track the state of each toggle
    private bool[] solution = new bool[4] { true, false, false, true }; // Correct toggle states

    private bool imUsing = false; // Flag to check if the computer is being used    
    public Door doorToUnlock; // Reference to the door to unlock
    public DialogueManager dialogueManager; // Reference to the DialogueManager

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < userTry.Length; i++)
        {
            userTry[i] = false; // Initialize all toggles to false
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && imUsing)
        {
            imUsing = false; // Reset the flag when exiting
            ExitInteraction(); // Exit interaction if Escape is pressed
        }
    }

    public void Interact()
    {
        imUsing = true; // Set the flag to indicate the computer is being used
        if (lastFrameShown == 0)
        {
            ShowFrame1(); // Fa il reset corretto degli altri frame
        }
        else
        {
            switch (lastFrameShown)
            {
                case 1:
                    ShowFrame1();
                    break;
                case 2:
                    ShowFrame2();
                    break;
                case 3:
                    ShowFrame3();
                    break;
                case 4:
                    ShowFrame4();
                    break;
                case 5:
                    ShowFrame5();
                    break;
                case 6:
                    ShowFrame6();
                    break;
                case 7:
                    ShowFrame7();
                    break;
                case 8:
                    ShowFrame8();
                    break;
            }
        }

        fpc.setIsWalking(false);
        fpc.changeActive();
        fpc.cameraCanMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void checkAnswer()
    {         // Check if the user's toggles match the solution
        bool isCorrect = true;
        for (int i = 0; i < userTry.Length; i++)
        {
            if (userTry[i] != solution[i])
            {
                isCorrect = false;
                break;
            }
        }
        if (isCorrect)
        {
            Debug.Log("Correct answer!");
            doorToUnlock.isLocked = false; // Unlock the door if the answer is correct
            imUsing = false; // Reset the flag
            ExitInteraction();
            dialogueManager.StartDialogue(new List<string> { "Accesso concesso. Una porta si è aperta" });
            // Handle correct answer logic here, e.g., unlock something or show a message
        }
        else
        {
            Debug.Log("Incorrect answer. Try again.");
            AudioManager.PlayWrongAnswer(); // Play wrong answer sound
            // Handle incorrect answer logic here, e.g., show an error message
        }
    }
    public void ShowFrame1()
    {
        lastFrameShown = 1; // Update the last frame shown
        DisableAllFrames(); // Disable all other frames
        Frame1.SetActive(true);
    }

    public void ShowFrame2()
    {
        lastFrameShown = 2; // Update the last frame shown
        DisableAllFrames(); // Disable all other frames
        Frame2.SetActive(true);
    }

    public void ShowFrame3()
    {
        lastFrameShown = 3; // Update the last frame shown
        DisableAllFrames(); // Disable all other frames
        Frame3.SetActive(true);
    }

    public void ShowFrame4()
    {
        lastFrameShown = 4; // Update the last frame shown
        DisableAllFrames(); // Disable all other frames
        Frame4.SetActive(true);
    }

    public void ShowFrame5()
    {
        lastFrameShown = 5; // Update the last frame shown
        DisableAllFrames(); // Disable all other frames
        Frame5.SetActive(true);
    }

    public void ShowFrame6()
    {
        lastFrameShown = 6; // Update the last frame shown
        DisableAllFrames(); // Disable all other frames
        Frame6.SetActive(true);
    }

    public void ShowFrame7()
    {
        lastFrameShown = 7; // Update the last frame shown
        DisableAllFrames(); // Disable all other frames
        Frame7.SetActive(true);
    }

    public void ShowFrame8()
    {
        lastFrameShown = 8; // Update the last frame shown
        DisableAllFrames(); // Disable all other frames
        Frame8.SetActive(true);
    }

    public void ExitInteraction()
    {
        fpc.setIsWalking(true);
        fpc.changeActive();
        fpc.cameraCanMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // Disable all frames when exiting interaction
        DisableAllFrames();
        GameObject.FindFirstObjectByType<PauseMenu>().SetEscapeCooldown();
    }

    private void DisableAllFrames()
    {
        Frame1.SetActive(false);
        Frame2.SetActive(false);
        Frame3.SetActive(false);
        Frame4.SetActive(false);
        Frame5.SetActive(false);
        Frame6.SetActive(false);
        Frame7.SetActive(false);
        Frame8.SetActive(false);
    }

    public void ToggleFplus()
    {
        userTry[0] = true;
        Fminus.SetIsOnWithoutNotify(false); // Ensure F- is off when F+ is on
    }
    public void ToggleFminus()
    {
        userTry[0] = false;
        Fplus.SetIsOnWithoutNotify(false); // Ensure F+ is off when F- is on
    }
    public void ToggleBplus()
    {
        userTry[1] = true;
        Bminus.SetIsOnWithoutNotify(false); // Ensure B- is off when B+ is on
    }
    public void ToggleBminus()
    {
        userTry[1] = false;
        Bplus.SetIsOnWithoutNotify(false); // Ensure B+ is off when B- is on
    }
    public void ToggleSplus()
    {
        userTry[2] = true;
        Sminus.SetIsOnWithoutNotify(false); // Ensure S- is off when S+ is on
    }
    public void ToggleSminus()
    {
        userTry[2] = false;
        Splus.SetIsOnWithoutNotify(false); // Ensure S+ is off when S- is on
    }
    public void ToggleFoplus()
    {
        userTry[3] = true;
        Fominus.SetIsOnWithoutNotify(false); // Ensure Fom- is off when Fop+ is on
    }
    public void ToggleFominus()
    {
        userTry[3] = false;
        Foplus.SetIsOnWithoutNotify(false); // Ensure Fop+ is off when Fom- is on
    }
}
