using UnityEngine;

public class playerItems : MonoBehaviour
{
    public GameObject periodicTable;
    public FirstPersonController fpc;

    public bool hasPTable = false;
    private bool isMapOpen = false;
    private bool wasBlocked = false;

    void Update()
    {
        if (!hasPTable) return;

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isMapOpen)
            {
                // Stai aprendo la mappa ora, salvi lo stato attuale
                wasBlocked = !fpc.playerCanMove;
                fpc.setIsWalking(false);
                fpc.playerCanMove = false;
                periodicTable.SetActive(true);
                isMapOpen = true;
            }
            else
            {
                // Stai chiudendo la mappa, ripristini il movimento solo se non era già bloccato
                if (!wasBlocked)
                {
                    fpc.playerCanMove = true;
                }
                periodicTable.SetActive(false);
                isMapOpen = false;
            }
        }
    }
}
