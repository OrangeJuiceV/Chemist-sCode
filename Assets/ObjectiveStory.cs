using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ObjectiveStory : MonoBehaviour
{
    public DialogueManager dialogueManager; // Collegalo nell'Inspector
    public GameObject blackScreen; // Deve essere attiva nella scena all'inizio
    public GameObject ObjectiveWindow;
    public TextMeshProUGUI ObjectiveText;

    void Start()
    {
        StartCoroutine(StorySequence());
    }

    IEnumerator StorySequence()
    {
        yield return new WaitForSeconds(0.1f); // Mini pausa per sicurezza

        // Avvia primo dialogo
        dialogueManager.StartDialogue(new List<string>
        {
            "(Premi SPAZIO per proseguire i dialoghi...)",
            "……………………………………………",
            "Dove sono?... Chi... chi sono?"
        });

        yield return new WaitUntil(() => dialogueManager.IsDialogueFinished());

        blackScreen.SetActive(false);

        dialogueManager.StartDialogue(new List<string>
        {
            "Un laboratorio...? Perché mi sembra familiare?",
            "Un computer... forse posso trovare qualche informazione."
        });

        yield return new WaitUntil(() => dialogueManager.IsDialogueFinished());

        ObjectiveWindow.SetActive(true);
        ObjectiveText.color = new Color(1.0f, 0.0f, 0.0f); // Rosso
        yield return new WaitForSeconds(3.0f);
        ObjectiveText.color = new Color(0.0f, 0.0f, 0.0f); // Nero
    }

    public IEnumerator updateTo2nd()
    {
        ObjectiveText.text = "Esplora la stanza";
        ObjectiveText.color = new Color(1.0f, 0.0f, 0.0f); // Rosso
        yield return new WaitForSeconds(3.0f);
        ObjectiveText.color = new Color(0.0f, 0.0f, 0.0f); // Nero
    }

    public IEnumerator updateTo3rd()
    {
        ObjectiveText.text = "Trova un codice per aprire la porta";
        ObjectiveText.color = new Color(1.0f, 0.0f, 0.0f); // Rosso
        yield return new WaitForSeconds(3.0f);
        ObjectiveText.color = new Color(0.0f, 0.0f, 0.0f); // Nero
    }

    public IEnumerator updateTo4th()
    {
        ObjectiveText.text = "Esplora il laboratorio";
        ObjectiveText.color = new Color(1.0f, 0.0f, 0.0f); // Rosso
        yield return new WaitForSeconds(3.0f);
        ObjectiveText.color = new Color(0.0f, 0.0f, 0.0f); // Nero
    }

    public IEnumerator updateTo5th()
    {
        ObjectiveText.text = "Trova un modo per aprire il cassetto";
        ObjectiveText.color = new Color(1.0f, 0.0f, 0.0f); // Rosso
        yield return new WaitForSeconds(3.0f);
        ObjectiveText.color = new Color(0.0f, 0.0f, 0.0f); // Nero
    }

    public IEnumerator updateTo6th()
    {
        ObjectiveText.text = "Risolvi il puzzle";
        ObjectiveText.color = new Color(1.0f, 0.0f, 0.0f); // Rosso
        yield return new WaitForSeconds(3.0f);
        ObjectiveText.color = new Color(0.0f, 0.0f, 0.0f); // Nero
    }

}
