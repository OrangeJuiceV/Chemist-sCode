using UnityEngine;

public class ElectronOrbit : MonoBehaviour
{
    public float orbitSpeed = 50f; // Velocità di rotazione

    void Update()
    {
        transform.Rotate(Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
