using UnityEngine;

public class Balloon : MonoBehaviour, IInteractable
{

    public GameObject periodicTableItem;
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
        Destroy(gameObject);
        periodicTableItem.SetActive(true);
    }
}
