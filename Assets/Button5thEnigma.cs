using UnityEngine;

public class Button5thEnigma : MonoBehaviour, IInteractable
{
    public GameObject atom; // Reference to the atom GameObject
    public Pcs5thEnigma pcs5thEnigma; // Reference to the Pcs5thEnigma script
    public bool isAdding; // Flag to check if the button is for adding or removing electrons

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (isAdding)
        { 
            pcs5thEnigma.AddElectron(atom);
        }
        else
        {
            pcs5thEnigma.RemoveElectron(atom);
        }
    }
}
