using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _musicInMenu, _musicInGame;
    [SerializeField] private AudioSource[] _sounds;

    [SerializeField] private ChangeLanguage _language;
    [SerializeField] private TMP_Dropdown _dropDownLanguage;

    [SerializeField] private Sprite _soundOff, _soundOn, _musicOff, _musicOn;
    private bool _isSound, _isMusic;

    private void Start()
    {
        _isSound = true;
        _isMusic = true;
    }

    public void ChangeSound(Image soundImage)
    {
        if (_isSound)
        {
            _isSound = !_isSound;
            soundImage.sprite = _soundOff;
        }
        else
        {
            _isSound = !_isSound;
            soundImage.sprite = _soundOn;
        }

        for(int i = 0; i< _sounds.Length; i++)
        {
            _sounds[i].enabled = _isSound;
        }
    }

    public void ChangeMusic(Image musicImage)
    {
        if (_isMusic)
        {
            _isMusic = !_isMusic;
            musicImage.sprite = _musicOff;
        }
        else
        {
            _isMusic = !_isMusic;
            musicImage.sprite = _musicOn;
        }

        _musicInMenu.enabled = _isMusic;
        _musicInGame.enabled = _isMusic;
    }

    public void ChangeLanguage()
    {
        if(_dropDownLanguage.value == 0)
        {
            _language.ChangeRus();
        }
        else
        {
            _language.ChangeEng();
        }
    }
}