using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;
    public KeyCode interactKey = KeyCode.E;

    private Outline currentOutline;

    public FirstPersonController fpc;

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            Outline outline = hit.collider.GetComponentInParent<Outline>();
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();

            // Se l'oggetto osservato è cambiato
            if (outline != null && outline != currentOutline)
            {
                if (currentOutline != null) currentOutline.OutlineWidth = 0f;

                outline.OutlineWidth = 8f;
                currentOutline = outline;
            }

            // Interazione
            if (Input.GetKeyDown(interactKey) && fpc.playerCanMove)
            {
                interactable?.Interact();
            }
        }
        else
        {
            // Nessun oggetto colpito dal raycast
            if (currentOutline != null)
            {
                currentOutline.OutlineWidth = 0f;
                currentOutline = null;
            }
        }
    }
}
