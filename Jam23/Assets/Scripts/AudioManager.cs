using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        [Serializable]
        public class Sound
        {
            public string Name;
            public AudioClip Clip;
        }

        public static AudioManager Instance;

        public AudioSource Source;

        public AudioClip[] BGSounds;
        public Sound[] Sounds;

        private int _currentClip;

        void Awake()
        {
            Instance = this;

            Source = GetComponent<AudioSource>();
            if (Source == null)
                Source = gameObject.AddComponent<AudioSource>();

            PlayMainTheme();
            DontDestroyOnLoad(this);
        }

        public void Play(AudioClip clip)
        {
            Stop();
            Source.clip = clip;
            Invoke("PlayMainTheme", Source.clip.length);

            Source.Play();
        }

        public void PlayOneShot(string name)
        {
            Pause();
            Source.PlayOneShot(Sounds.First(x => x.Name.Equals(name)).Clip);
            Continue();
        }

        public void Pause() =>
            Source.Pause();

        public void Continue() =>
            Source.UnPause();

        public void Stop()
        {
            Source.Stop();
            Source.clip = null;
        }

        public void PlayMainTheme()
        {
            _currentClip = _currentClip + 1 < BGSounds.Length ? _currentClip + 1 : 0;
            AudioManager.Instance.Play(BGSounds[_currentClip]);
        }
    }
}