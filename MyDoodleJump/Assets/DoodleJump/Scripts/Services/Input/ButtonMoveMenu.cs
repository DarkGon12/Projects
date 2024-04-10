using UnityEngine;

public class ButtonMoveMenu : MonoBehaviour
{
    public void SetButtonMove(int value)
    {
        PlayerPrefs.SetInt("move", value);
    }
}