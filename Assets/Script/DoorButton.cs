using UnityEngine;

public class DoorButton : MonoBehaviour, IInteractable
{
    public Door door; // Reference to the door this button controls
    
    public void Interact()
    {
        door.Interact();
    }
}
