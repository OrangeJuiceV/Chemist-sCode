using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
    public Light lightObject;
    public MeshRenderer meshRenderer;

    public Material onMaterial;
    public Material offMaterial;
    public int numMaterial;
    public bool isOn;

    private Material[] cachedMaterials;

    private void Awake()
    {
        // Cache originale dei materiali una sola volta
        cachedMaterials = meshRenderer.materials;
    }

    public void Interact()
    {
        isOn = !isOn;
        lightObject.enabled = isOn;

        if (cachedMaterials != null && numMaterial < cachedMaterials.Length)
        {
            cachedMaterials[numMaterial] = isOn ? onMaterial : offMaterial;
            meshRenderer.materials = cachedMaterials;
        }
        else
        {
            Debug.LogWarning("Indice materiale non valido o materiali non inizializzati.");
        }

        // Refresh dell'outline (non obbligatorio se i materiali Outline sono intatti)
        Outline outline = GetComponentInParent<Outline>();
        if (outline != null)
        {
            outline.enabled = false;
            outline.enabled = true;
        }

        Debug.Log(isOn ? "Light turned on" : "Light turned off");
    }
}
