using UnityEngine;

public class ButtonThirdEnigma : MonoBehaviour, IInteractable
{
    public ThirdEnigma enigmaScript; // Riferimento allo script ThirdEnigma
    public int sphereNumber = 1; // 1, 2 o 3 a seconda del bottone se 4 chiama funzione di checkAnswer (bruttissimo ma okay)

    public void Interact()
    {
        AudioManager.PlayButtonSound(); // Riproduce il suono del click del bottone
        if (enigmaScript != null)
        {
            switch (sphereNumber)
            {
                case 1:
                    enigmaScript.EnlargeSphere1();
                    break;
                case 2:
                    enigmaScript.EnlargeSphere2();
                    break;
                case 3:
                    enigmaScript.EnlargeSphere3();
                    break;
                case 4:
                    enigmaScript.CheckAnswer();
                    break;
            }
        }
        else
        {
            Debug.LogWarning("ThirdEnigma non assegnato!");
        }
    }
}
