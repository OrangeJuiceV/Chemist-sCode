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

    public bool litioAviable = false; // Variabile per gestire la disponibilità del Litio
    public ObjectiveStory objectiveStory; // Riferimento all'ObjectiveStory script
    public void Interact()
    {

        switch (elementID)
        {
            case 0: // Elio
                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(new List<string> {
                        "Un palloncino... leggero... riempito d’aria? No...",
                        "Aspetta... Elio! Sì, l’Elio è un gas... lo usano per far volare i palloncini.",
                        "Elio... uno degli elementi mancanti della tavola!"
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
                        "Delle batterie...Aspetta… certo, il Litio!",
                        "È usato proprio per questo. È leggero, reattivo… perfetto per immagazzinare energia",
                        "Un altro elemento... un altro ricordo che riaffiora.",
                        "Una porta si è aperta"
                });
                }
                else
                {
                    Debug.LogWarning("DialogueManager non assegnato al PeriodicElement.");
                }

                objectiveStory.StartCoroutine(objectiveStory.updateTo4th());
                break;

            case 2: // Calcio per il latte
                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(new List<string> {
                        "Latte... contiene calcio, giusto? Sì, il Calcio è un elemento... Ca... Ca!",
                        "Anche questo mancava nella tavola."
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
                        "Monete d’oro... sì, l’Oro! Un altro elemento! Simbolo... Au!",
                        "Un altro tassello del puzzle. Pian piano sto ricordando"
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
                        "Il Mercurio è l'unico metallo liquido a temperatura ambiente. È stato usato nei termometri per misurare la temperatura, ma oggi è spesso sostituito perché tossico.",
                        "Il Mercurio è stato aggiunto alla tua tavola periodica!"
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
