using UnityEngine;
using System.Collections.Generic;

public class ThirdEnigma : MonoBehaviour
{
    public int EnigmaID;
    public bool isActive;
    public GameObject sphere1;
    public GameObject sphere2;
    public GameObject sphere3;

    public GameObject confirmButton;

    private int scaleSizeSphere1 = 2;
    private int scaleSizeSphere2 = 2;
    private int scaleSizeSphere3 = 2;

    public DialogueManager dialogueManager;

    public ThirdEnigma secondPart;
    public ThirdEnigma thirdPart;
    public GameObject secondCrystalLight;
    public GameObject thirdCrystalLight;

    public CrystalDialogue secondCrystal;
    public CrystalDialogue thirdCrystal;

    private readonly Vector3[] scaleStates = new Vector3[]
    {
        new (1f, 1f, 1f),
        new (1.5f, 1.5f, 1.5f),
        new (2f, 2f, 2f)
    };

    private readonly List<int[]> solutions = new()
    {
        new int[] { 0, 2, 1}, // soluzione brama
        new int[] { 1 , 2, 0}, // soluzione forma
        new int[] {2 , 0, 1} // soluzione resistenza
    };

    public void EnlargeSphere1()
    {
        if (isActive) 
        {
            scaleSizeSphere1 = (scaleSizeSphere1 + 1) % 3;
            sphere1.transform.localScale = scaleStates[scaleSizeSphere1];
        }
        else
        {
            dialogueManager.StartDialogue(new List<string> {
                "Il pulsante non è attivo"
            });
        }
    }

    public void EnlargeSphere2()
    {
        if (isActive)
        {
            scaleSizeSphere2 = (scaleSizeSphere2 + 1) % 3;
            sphere2.transform.localScale = scaleStates[scaleSizeSphere2];
        }
        else 
        {
            dialogueManager.StartDialogue(new List<string> {
                "Il pulsante non è attivo"
            });
        }
    }

    public void EnlargeSphere3()
    {
        if (isActive)
        {
            scaleSizeSphere3 = (scaleSizeSphere3 + 1) % 3;
            sphere3.transform.localScale = scaleStates[scaleSizeSphere3];
        }
        else
        {
            dialogueManager.StartDialogue(new List<string> {
                "Il pulsante non è attivo"
            });
        }
    }

    public void CheckAnswer()
    {
        if (!isActive)
            return;

        int[] correctSolution = solutions[EnigmaID];

        if (correctSolution[0] == scaleSizeSphere1 &&
            correctSolution[1] == scaleSizeSphere2 &&
            correctSolution[2] == scaleSizeSphere3)
        {
            Debug.Log("Soluzione corretta!");

            // Se vuoi avviare un dialogo (opzionale)
            if (dialogueManager != null)
            {
                dialogueManager.StartDialogue(new List<string> {
                    "Soluzione corretta :D"
                });
            }

            isActive = false; // stoppa

            switch (EnigmaID)
            {
                case 0:
                    secondPart.isActive = true;
                    secondCrystalLight.GetComponent<Light>().enabled = true;
                    secondCrystal.isActive = true;
                    break;

                case 1:
                    thirdPart.isActive = true;
                    thirdCrystalLight.GetComponent<Light>().enabled = true;
                    thirdCrystal.isActive = true;
                    break;

                 case 2:
                    // sblocca cassa
                    break;

                    // Altre azioni di successo qui...
            }
        }
        else
        {
            Debug.Log("Soluzione sbagliata.");

            if (dialogueManager != null)
            {
                dialogueManager.StartDialogue(new List<string> {
                    "Soluzione sbagliata"
                });
            }
        }
    }
}
