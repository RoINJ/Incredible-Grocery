using GameControllerScripts;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelManager : MonoBehaviour
{
    [SerializeField] private Sprite buttonOn;
    [SerializeField] private Sprite buttonOff;

    private Button _soundButton;
    private Button _musicButton;
    
    private bool _isMusicEnabled;
    private bool IsMusicEnabled
    {
        get => _isMusicEnabled;
        set
        {
            _isMusicEnabled = value;
            SetButtonState(_musicButton, value);
        }
    }

    private bool _isSoundsEnabled;
    private bool IsSoundsEnabled
    {
        get => _isSoundsEnabled;
        set
        {
            _isSoundsEnabled = value;
            SetButtonState(_soundButton, value);
        }
    }

    public void Save()
    {
        SoundManager.Instanse.IsMusicEnabled = _isMusicEnabled;
        SoundManager.Instanse.IsSoundsEnabled = _isSoundsEnabled;
        
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (_soundButton == null || _musicButton == null)
        {
            var buttons = GetComponentsInChildren<Button>();
        
            _soundButton = buttons[0];
            _musicButton = buttons[1];
        
            _soundButton.onClick.AddListener(()=> IsSoundsEnabled = !IsSoundsEnabled);
            _musicButton.onClick.AddListener(()=> IsMusicEnabled = !IsMusicEnabled);
        }
        
        Time.timeScale = 0;

        IsMusicEnabled = SoundManager.Instanse.IsMusicEnabled;
        IsSoundsEnabled = SoundManager.Instanse.IsSoundsEnabled;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    private void SetButtonState(Button button, bool state)
    {
        button.image.sprite = state
            ? buttonOn
            : buttonOff;

        button.GetComponentInChildren<Text>().text = state
            ? "ON"
            : "OFF";
    }
}
