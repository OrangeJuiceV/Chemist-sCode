using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pc2ndEnigma : MonoBehaviour, IInteractable
{
    public GameObject schermata;
    private bool imUsing = false;
    public FirstPersonController fpc;

    public Sprite NoKnight;
    public Sprite OneKnight;
    public Sprite TwoKnight;
    private bool initialized;
    private List<Image> buttonImages = new List<Image>();
    private List<int> buttonStates = new List<int>();

    public Button confirmButton; // Bottone di conferma

    // soluzioni

    private List<int[]> solutions = new List<int[]>
    {
        new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 0, 0, 0, 0, 
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // soluzione potassio, numero atomico 19
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} // soluzione ossigeno
    };

    private int currentSolution;

    void Start()
    {
        initialized = false;
        currentSolution = 0;
        confirmButton.onClick.AddListener(CheckSolution);
    }

    void Update()
    {
        if (imUsing && Input.GetKeyDown(KeyCode.F))
        {
            ExitInteraction();
        }
    }

    public virtual void Interact()
    {
        schermata.SetActive(true);

        Transform pcContent = transform.GetChild(1);
        pcContent.gameObject.SetActive(true); // ATTIVA il contenitore prima di inizializzare i bottoni

        if (!initialized)
        {
            InitButtons();
            initialized = true;
        }

        fpc.setIsWalking(false);
        fpc.changeActive();
        fpc.cameraCanMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        imUsing = true;
    }


    public void ExitInteraction()
    {
        fpc.changeActive();
        fpc.cameraCanMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        schermata.SetActive(false);
        imUsing = false;
    }

    private void InitButtons()
    {
        buttonImages.Clear();
        buttonStates.Clear();
        Debug.Log($"Numero bottoni raccolti: {buttonStates.Count}");
        Debug.Log($"Dimensione soluzione attuale: {solutions[currentSolution].Length}");


        Transform pcContent = transform.GetChild(1); // 0 = PC, 1 = pcContent
        Button[] buttons = pcContent.GetComponentsInChildren<Button>();

        foreach (Button btn in buttons)
        {
            if (btn.name == "ConfirmButton") continue; //  SALTA il bottone di conferma

            Image img = btn.GetComponent<Image>();
            if (img != null)
            {
                buttonImages.Add(img);
                buttonStates.Add(0);
                img.sprite = NoKnight;

                int index = buttonImages.Count - 1;
                btn.onClick.AddListener(() => OnButtonClick(index));
            }
        }

        Debug.Log($"Trovati {buttonImages.Count} bottoni con Image.");
    }


    private void OnButtonClick(int index)
    {
        buttonStates[index] = (buttonStates[index] + 1) % 3;
        Debug.Log($"Bottone {index} stato: {buttonStates[index]}");

        switch (buttonStates[index])
        {
            case 0:
                buttonImages[index].sprite = NoKnight;
                break;
            case 1:
                buttonImages[index].sprite = OneKnight;
                break;
            case 2:
                buttonImages[index].sprite = TwoKnight;
                break;
        }
    }

    private void CheckSolution()
    {
        int[] currentState = buttonStates.ToArray();
        int[] expected = solutions[currentSolution];

        if (AreArraysEqual(currentState, expected))
        {
            Debug.Log("Soluzione corretta!");

            // Se vuoi passare alla prossima soluzione (opzionale):
            if (currentSolution < solutions.Count - 1)
            {
                currentSolution++;
                Debug.Log("Avanzato alla prossima soluzione.");
            }
        }
        else
        {
            Debug.Log("Soluzione errata.");
        }
    }

    private bool AreArraysEqual(int[] a, int[] b)
    {
        if (a.Length != b.Length) return false;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i]) return false;
        }
        return true;
    }

}
