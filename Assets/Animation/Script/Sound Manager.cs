using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get { return instance; }
    }

    public AudioSource SoundEffects;
    public AudioSource SoundMusic;
    public SoundType[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // listen for scene changes
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // runs every time any scene loads
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // stop all effects first
        SoundEffects.Stop();

        // always restart background music fresh
        PlayMusic(Sounds.Music);
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            // only restart if not already playing this clip
            if (SoundMusic.clip == clip && SoundMusic.isPlaying)
                return;

            SoundMusic.Stop();
            SoundMusic.clip = clip;
            SoundMusic.loop = true;
            SoundMusic.Play();
        }
        else
        {
            Debug.LogError("Clip Not Found: " + sound);
        }
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundEffects.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip Not Found: " + sound);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(sounds, i => i.soundType == sound);
        if (item != null)
            return item.soundClip;
        return null;
    }

    private void OnDestroy()
    {
        // clean up listener when destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    [System.Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip soundClip;
    }

    public enum Sounds
    {
        ButtonClick,
        PlayerMove,
        Music,
        PlayerDeath,
        EnemyDeath,
    }
}