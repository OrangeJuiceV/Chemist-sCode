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

    private List<Image> buttonImages = new List<Image>();
    private List<int> buttonStates = new List<int>();

    void Start()
    {
        InitButtons();
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

        Transform pcContent = transform.GetChild(1); // 0 = PC, 1 = pcContent
        Button[] buttons = pcContent.GetComponentsInChildren<Button>();

        foreach (Button btn in buttons)
        {
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
}
