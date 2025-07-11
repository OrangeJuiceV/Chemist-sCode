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
    public GameObject Argento;
    public GameObject Uranio;
    public GameObject Ferro;
    public GameObject Arsenico;

    public bool litioAviable = false; // Variabile per gestire la disponibilità del Litio per evitare problemi di collision
    public ObjectiveStory objectiveStory; // Riferimento all'ObjectiveStory script

    private const int Elio_ID = 0;
    private const int Litio_ID = 1;
    private const int Calcio_ID = 2;
    private const int Oro_ID = 3;
    private const int Mercurio_ID = 4;
    private const int Argento_ID = 5; 
    private const int Uranio_ID = 6;
    private const int Ferro_ID = 7;
    private const int Arsenico_ID = 8; 
    public void Interact()
    {

        switch (elementID)
        {
            case Elio_ID:
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

            case Litio_ID: 
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

            case Calcio_ID: 
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

            case Oro_ID:
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
            case Mercurio_ID:
                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(new List<string> {
                        "Un termometro… certo! Questo mi ricorda il mercurio. È un metallo liquido… usato proprio nei vecchi termometri.",
                        "Un altro pezzo del puzzle."
                    });
                    Mercurio.SetActive(true);
                    objectiveStory.StartCoroutine(objectiveStory.updateTo6th());
                }
                else
                {
                    Debug.LogWarning("DialogueManager non assegnato al PeriodicElement.");
                }
                break;
            case Argento_ID:
                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(new List<string> {
                        "Argento… Ag.",
                        "Ricordo questo simbolo… appartiene a uno degli elementi. Strano come certi dettagli tornino alla mente."
                    });
                    Argento.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("DialogueManager non assegnato al PeriodicElement.");
                }
                break;
            case Uranio_ID:
                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(new List<string> {
                        "Quel simbolo… radiazioni? Aspetta… U… Uranio!",
                        "Un elemento pericoloso… ma importante. Un altro elemento mancante."
                    });
                    Uranio.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("DialogueManager non assegnato al PeriodicElement.");
                }
                break;
            case Ferro_ID:
                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(new List<string> {
                        "Una calamita… Ricordo che il ferro rispondeva a questo richiamo.",
                        "Fe… un altro frammento della mia memoria che si ricompone."
                    });
                    Ferro.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("DialogueManager non assegnato al PeriodicElement.");
                }
                break;
            case Arsenico_ID:
                if (dialogueManager != null)
                {
                    dialogueManager.StartDialogue(new List<string> {
                        "Arsenico… simbolo As.",
                        "È uno degli elementi, certo! I ricordi stanno tornando…"
                    });
                    Arsenico.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("DialogueManager non assegnato al PeriodicElement.");
                }
                break;
        }
    }
}
