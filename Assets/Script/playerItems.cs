using UnityEngine;

public class playerItems : MonoBehaviour
{
    public GameObject periodicTable;
    public FirstPersonController fpc;

	public bool hasPTable = false;
    private bool isMapOpen = false;
	

    void Update()
    {
		if (!hasPTable) return;
		
        if (Input.GetKeyDown(KeyCode.M))
        {
            fpc.setIsWalking(false);
            isMapOpen = !isMapOpen;
            periodicTable.SetActive(isMapOpen); 
            fpc.playerCanMove = !isMapOpen;
        }
    }
}
