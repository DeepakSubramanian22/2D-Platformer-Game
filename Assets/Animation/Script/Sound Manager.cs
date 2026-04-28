using System;
using UnityEngine;

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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(Sounds.Music);         // ✓ removed global::
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.loop = true;      // ✓ music should loop
            SoundMusic.Play();           // ✓ correct method for music
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
            SoundEffects.PlayOneShot(clip);   // ✓ correct for sound effects
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