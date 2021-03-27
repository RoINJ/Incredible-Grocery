using UnityEngine;

namespace GameControllerScripts
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource _audioSource;
    
        public static SoundManager Instanse { get; private set; }

        public bool IsSoundsEnabled { get; set; }

        private bool _isMusicEnabled;

        public bool IsMusicEnabled
        {
            get => _isMusicEnabled;
            set
            {
                _isMusicEnabled = value;
                _audioSource.mute = !value;
            }
        }

        public void PlaySound(AudioClip audioClip, Vector3 position)
        {
            if (IsSoundsEnabled)
            {
                var timeScale = Time.timeScale;
                Time.timeScale = 1;
            
                AudioSource.PlayClipAtPoint(audioClip, position);
            
                Time.timeScale = timeScale;
            }
        }

        private void Start()
        {
            Instanse = this;
        
            _audioSource = GameObject.FindWithTag("GameController")
                .GetComponent<AudioSource>();
        
            IsSoundsEnabled = SettingsManager.IsSoundsEnabled;
            IsMusicEnabled = SettingsManager.IsMusicEnabled;
        }

        private void OnDestroy()
        {
            SettingsManager.IsSoundsEnabled = IsSoundsEnabled;
            SettingsManager.IsMusicEnabled = IsMusicEnabled;
        }
    }
}
