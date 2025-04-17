using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text stateText;
    public TMP_Text speedText;
    public TMP_Text rotateText;

    public void UpdateStateUI(ObjectRotator.Lever currentState)
    {
        if (stateText != null)
        {
            stateText.text = $"{currentState}";
        }
    }

    public void UpdateSpeedUI(ObjectRotator.RotationSpeed currentSpeed)
    {
        if (speedText != null)
        {
            speedText.text = $"{currentSpeed}";
        }
    }

     public void UpdaterotateUI(float rotateSpeed)
    {
        if (rotateText != null)
        {
            rotateText.text = $"{rotateSpeed}";
        }
    }
}