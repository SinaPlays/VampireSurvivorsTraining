using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Music Clips")]
    [SerializeField] public AudioClip mainMenuMusic;
    [SerializeField] public AudioClip gameMusic;
    [SerializeField] public AudioClip gameOverMusic;

    [Header("Sound Effects")]
    [SerializeField] public AudioClip enemyAttack;
    [SerializeField] public AudioClip enemyDying;
    [SerializeField] public AudioClip garlic;
    [SerializeField] public AudioClip whip;
    [SerializeField] public AudioClip levelUp;

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

    public void PlaySoundEffect(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}