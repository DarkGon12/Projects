using Scripts.Doodle;
using UnityEngine;

public class ButtonMoveInit : MonoBehaviour
{
    [SerializeField] private GameObject _buttonLeft, _buttonRight;
    [SerializeField] private DoodleMove _doodleMove;

    private void Start()
    {
        if (PlayerPrefs.GetInt("move") == 1)
        {
            _buttonLeft.SetActive(true);
            _buttonRight.SetActive(true);
            _doodleMove.IsButtonMove = true;
        }
        else
        {
            _buttonLeft.SetActive(false);
            _buttonRight.SetActive(false);
            _doodleMove.IsButtonMove = false;
        }
    }
}
