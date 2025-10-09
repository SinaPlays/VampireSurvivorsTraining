using System;
using System.Collections.Generic;
using UnityEngine;
public enum ESoundFX
{
    PlayerLevelUp,
    WhipAttack,
    GarlicAttack,
    EnemyDeath,
    EnemyAttack,
}

[Serializable]
public struct SoundInstance
{
    public ESoundFX effect;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource source;

    public void PlaySound()
    {
        source.clip = clip;
        source.Play();
    }
}
public class AudioManager : MonoBehaviour
{


    public static AudioManager instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private List<SoundInstance> soundInstances = new();


    [Header("Music")]
    public AudioClip mainMenuMusic;
    public AudioClip gameMusic;
    public AudioClip gameOverMusic;
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
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip && musicSource.isPlaying)
            return;

        musicSource.clip = clip;
        musicSource.Play();
    }
    public void PlaySFX(ESoundFX eSound)
    {
        foreach (SoundInstance instance in soundInstances)
        {
            if (instance.effect == eSound)
            {
                instance.PlaySound();
                return;
            }
        }

        throw new Exception("Sound FX Not Found");
    }
    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}