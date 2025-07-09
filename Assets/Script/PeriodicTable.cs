using UnityEngine;
using System.Collections.Generic;
public class PeriodicTable : MonoBehaviour, IInteractable
{
    public playerItems it;
    public DialogueManager dm;
    public virtual void Interact()
    {
        it.hasPTable = true;
        dm.StartDialogue(new List<string> { "Premi M per aprire e chiudere la tavola." });
        Destroy(this.gameObject);
    } 
}
