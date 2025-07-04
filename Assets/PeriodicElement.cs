using UnityEngine;
using System.Collections.Generic;

public class PeriodicElement : MonoBehaviour, IInteractable
{
    public int elementID;

    public DialogueManager dialogueManager;
    public Door door3rdEnigma;
    public Light light3rdEnigma;

    public GameObject Calcio;
    public GameObject Elio;
    public GameObject Mercurio;
    public GameObject Litio;
    public GameObject Oro;

    public bool litioAviable = false; // Variabile per gestire la disponibilit� del Litio
    public void Interact()
    {

        switch (elementID)
        {
            case 0: // Elio
                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(new List<string> {
                        "L�Elio � un gas nobile molto leggero e non infiammabile. Viene usato nei palloncini perch� � pi� leggero dell�aria e li fa volare!",
                        "L'Elio � stato aggiunto alla tua tavola periodica!"
                    });
                    Elio.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("DialogueManager non assegnato al PeriodicElement.");
                }
                break;

            case 1: // 2 enigma Litio
                if (!litioAviable)
                {
                    break;
                }
                if (door3rdEnigma != null)
                {
                    door3rdEnigma.isLocked = false;
                }
                else
                {
                    Debug.LogWarning("door3rdEnigma non assegnata.");
                }

                if (light3rdEnigma != null)
                {
                    light3rdEnigma.color = Color.green;
                }
                else
                {
                    Debug.LogWarning("light3rdEnigma non assegnata.");
                }
                Litio.SetActive(true); // Attiva il Litio

                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(new List<string> {
                        "Il Litio � un metallo leggero e molto reattivo, ed � utilizzato principalmente nelle batterie ricaricabili grazie alla sua alta densit� di energia.",
                        "Il Litio � stato aggiunto alla tua tavola periodica!",
                        "Una porta nella stanza principale si � sbloccata, ora puoi proseguire."
                });
                }
                else
                {
                    Debug.LogWarning("DialogueManager non assegnato al PeriodicElement.");
                }
                break;

            case 2: // Calcio per il latte
                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(new List<string> {
                        "Il Calcio � un elemento essenziale per la salute delle ossa e dei denti, e viene spesso aggiunto ai prodotti lattiero-caseari.",
                        "Il calcio � stato aggiunto alla tua tavola periodica!"
                    });
                    Calcio.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("DialogueManager non assegnato al PeriodicElement.");
                }
                break;

            case 3: // Oro monete
                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(new List<string> {
                        "L'Oro � un metallo prezioso noto per la sua bellezza e resistenza alla corrosione. Viene spesso usato in gioielleria e come investimento.",
                        "L'Oro � stato aggiunto alla tua tavola periodica!"
                    });
                    Oro.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("DialogueManager non assegnato al PeriodicElement.");
                }
                break;
            case 4:
                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(new List<string> {
                        "Il Mercurio � l'unico metallo liquido a temperatura ambiente. � stato usato nei termometri per misurare la temperatura, ma oggi � spesso sostituito perch� tossico.",
                        "Il Mercurio � stato aggiunto alla tua tavola periodica!"
                    });
                    Mercurio.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("DialogueManager non assegnato al PeriodicElement.");
                }
                break;

        }
    }
}
