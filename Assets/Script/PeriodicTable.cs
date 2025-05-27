using UnityEngine;

public class PeriodicTable : MonoBehaviour, IInteractable
{
    public playerItems it;

    public virtual void Interact()
    {
        it.hasPTable = true;
        Destroy(this.gameObject);
    } 
}
