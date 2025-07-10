using System.Collections.Generic;
using UnityEngine;

public class Pcs5thEnigma : MonoBehaviour
{
    public GameObject Cloro;
    public GameObject Magnesio;
    public GameObject Ossigeno;
    public GameObject Sodio;

    public DialogueManager dialogueManager;

    public Texture2D unstable;
    public Texture2D stable;

    private const int OTTETTO = 8;
    private static int currentElectrons = 0; // inizializzazione globale
    private bool isSolved = false;
    private bool firstStableCheck = true; // Per evitare il primo controllo di stabilità
    void Start() { }

    void Update() { }

    private void CheckIfStable(GameObject atom)
    {
        GameObject pivotAtom = atom.transform.GetChild(0).gameObject;
        int electronCount = GetActiveChildsElectrons(pivotAtom);

        Renderer renderer = atom.GetComponent<Renderer>();
        Material updatedMaterial = new Material(renderer.material); // Copia

        if (electronCount == OTTETTO || electronCount == 0)
        {
            updatedMaterial.mainTexture = stable;
            if (firstStableCheck)
            {
                dialogueManager.StartDialogue(new List<string> { "Quindi quando i nuclei si stabilizzano diventano gialli, meglio tenerli d’occhio" });
                firstStableCheck = false; // Disabilita il primo controllo di stabilità
            }
            
        }
        else
        {
            updatedMaterial.mainTexture = unstable;
        }

        renderer.material = updatedMaterial;
        CheckSolution();
    }

    private void CheckSolution()
    {
        if (!isSolved && IsStable(Cloro) && IsStable(Ossigeno) && IsStable(Sodio) && IsStable(Magnesio))
        {
            isSolved = true;
            dialogueManager.StartDialogue(new List<string> { "Ho stabilizzato tutti gli atomi, ora posso finalmente proseguire" });
        }
    }


    private bool IsStable(GameObject atom)
    {
        return atom.GetComponent<Renderer>().material.mainTexture == stable;
    }

    public void AddElectron(GameObject atom)
    {
        if (isSolved)
        {
            dialogueManager.StartDialogue(new List<string> { "Ho già stabilizzato gli atomi, meglio non toccare" });
            return;
        }

        GameObject pivotAtom = atom.transform.GetChild(0).gameObject;

        if (GetActiveChildsElectrons(pivotAtom) == OTTETTO)
        {
            dialogueManager.StartDialogue(new List<string>
        {
            "L'ultimo livello di energia dell'atomo è pieno",
            "non ha senso aggiungere un elettrone, creerebbe un altro livello e sarebbe instabile"
        });
            return; // niente CheckIfStable qui
        }

        if (currentElectrons <= 0)
        {
            dialogueManager.StartDialogue(new List<string>
        {
            "Non ho un elettrone da aggiungere, dovrei prenderlo da un altro elemento"
        });
            return; // niente CheckIfStable qui
        }

        for (int i = 0; i < pivotAtom.transform.childCount; i++)
        {
            if (!pivotAtom.transform.GetChild(i).gameObject.activeSelf)
            {
                pivotAtom.transform.GetChild(i).gameObject.SetActive(true);
                currentElectrons = Mathf.Max(0, currentElectrons - 1);
                Debug.Log("Elettroni disponibili: " + currentElectrons);
                CheckIfStable(atom); // solo dopo che l'elettrone è stato davvero aggiunto
                return;
            }
        }
    }


    public void RemoveElectron(GameObject atom)
    {
        if (isSolved)
        {
            dialogueManager.StartDialogue(new List<string> { "Ho già stabilizzato gli atomi, meglio non toccare" });
            return;
        }

        if (currentElectrons > 0) {
            dialogueManager.StartDialogue(new List<string> { "Non posso spostare più di un elettrone per volta" });
            return;
        }

        GameObject pivotAtom = atom.transform.GetChild(0).gameObject;

        // Cerca se esiste almeno un elettrone attivo
        bool foundActive = false;
        for (int i = pivotAtom.transform.childCount - 1; i >= 0; i--)
        {
            Transform child = pivotAtom.transform.GetChild(i);
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false); // Disattiva effettivamente l'elettrone
                currentElectrons++;
                foundActive = true;

                Debug.Log("Elettroni disponibili: " + currentElectrons);
                break;
            }
        }

        if (!foundActive)
        {
            dialogueManager.StartDialogue(new List<string>
        {
            "L'ultimo livello di energia dell'atomo è vuoto",
            "non ha senso rimuovere un elettrone, toglierebbe un elettrone dal livello inferiore e diventerebbe instabile"
        });
        }

        // In ogni caso, verifica la stabilità (dopo la rimozione vera o fittizia)
        CheckIfStable(atom);
    }


    public int GetActiveChildsElectrons(GameObject atom)
    {
        int activeCount = 0;
        for (int i = 0; i < atom.transform.childCount; i++)
        {
            if (atom.transform.GetChild(i).gameObject.activeSelf)
            {
                activeCount++;
            }
        }
        return activeCount;
    }
}
