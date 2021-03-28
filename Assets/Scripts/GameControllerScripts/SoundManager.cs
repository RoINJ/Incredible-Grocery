using UnityEngine;

namespace GameControllerScripts
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource _audioSource;
    
        public static SoundManager Instanse { get; private set; }

        private bool _isSoundsEnabled;

        public bool IsSoundsEnabled
        {
            get => _isSoundsEnabled;
            set
            {
                _isSoundsEnabled = value;
                SettingsManager.IsSoundsEnabled = value;
            }
        }

        private bool _isMusicEnabled;
        public bool IsMusicEnabled
        {
            get => _isMusicEnabled;
            set
            {
                _isMusicEnabled = value;
                _audioSource.mute = !value;
                SettingsManager.IsMusicEnabled = value;
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
        
            _audioSource = GameObject.FindWithTag(Constants.Tags.GameController)
                .GetComponent<AudioSource>();
        
            IsSoundsEnabled = SettingsManager.IsSoundsEnabled || !SettingsManager.HasBeenLaunchedBefore;
            IsMusicEnabled = SettingsManager.IsMusicEnabled || !SettingsManager.HasBeenLaunchedBefore;
        }
    }
}
