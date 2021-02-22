using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PreparingForJamProject.Concretes.Observers
{
    public class AudioObserver : MonoBehaviour
    {
        private AudioSource _audioSource;

        private float _audioTimer = 0.3f;
        private float _currentAudioTime;
        private bool _isSoundPlaying = false;

        public float AudioTimer { get => _audioTimer; set => _audioTimer = value; }
        public float CurrentAudioTime { get => _currentAudioTime; set => _currentAudioTime = value; }
        public bool IsSoundPlaying { get => _isSoundPlaying; set => _isSoundPlaying = value; }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        private void Update()
        {
            CurrentAudioTime += Time.deltaTime;

            if (CurrentAudioTime > _audioTimer) CurrentAudioTime = _audioTimer;
        }
        public void PlayOneShot(params AudioClip[] audioClip)
        {
            if (_isSoundPlaying)
                foreach (var audio in audioClip)
                    _audioSource.PlayOneShot(audio);
        }
        public void MuteAllSounds()
        {
            _audioSource.mute = true;
        }
        public void ReMuteAllSounds()
        {
            _audioSource.mute = false;
        }
    }
}