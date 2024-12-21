using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource soundEffects;

    public float musicVolume = 0.5f;

    private bool isMute = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateVolume();
    }

    // Play a specific background music track
    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (backgroundMusic.clip != clip)
        {
            backgroundMusic.clip = clip;
        }
        backgroundMusic.Play();
    }

    // Pause the background music
    public void PauseBackgroundMusic()
    {
        backgroundMusic.Pause();
    }

    // Resume the background music
    public void ResumeBackgroundMusic()
    {
        backgroundMusic.UnPause();
    }

    // Stop the background music
    public void StopBackgroundMusic()
    {
        backgroundMusic.Stop();
    }

    // Play a sound effect
    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffects.PlayOneShot(clip, musicVolume);
    }

    public void changeVolumn()
    {
        if (!isMute)
        {
            soundEffects.volume = 0;
            backgroundMusic.volume = 0;
            PauseBackgroundMusic();
            isMute = true;
        }
        else
        {
            soundEffects.volume = 1;
            backgroundMusic.volume = 0.5f;
            ResumeBackgroundMusic();
            isMute = false;
        }
    }

    public void UpdateVolume()
    {
        backgroundMusic.volume = musicVolume;
        soundEffects.volume = musicVolume;
    }

    public bool IsMute()
    {
        return isMute;
    }
}