using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // Singleton instance

    public AudioClip collectSoundClip; // Sound for collecting food prefabs
    public AudioClip potionCollectSoundClip; // Sound for collecting potion objects
    public AudioClip burgerPrepareSoundClip; // Sound for preparing a burger
    public AudioClip chefHitSoundClip; // Sound for a chef being hit by a burger
    public AudioClip stoveDestroySoundClip; // Sound for a stove being destroyed
    public AudioClip gameOverSoundClip; // Sound for game over

    // Reference to the AudioSource components
    private AudioSource collectSoundSource;
    private AudioSource potionCollectSoundSource;
    private AudioSource burgerPrepareSoundSource;
    private AudioSource chefHitSoundSource;
    private AudioSource stoveDestroySoundSource;
    private AudioSource gameOverSoundSource;

    void Awake()
    {
        // Initialize singleton instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize AudioSource components and assign audio clips
        collectSoundSource = gameObject.AddComponent<AudioSource>();
        collectSoundSource.clip = collectSoundClip;

        potionCollectSoundSource = gameObject.AddComponent<AudioSource>();
        potionCollectSoundSource.clip = potionCollectSoundClip;

        burgerPrepareSoundSource = gameObject.AddComponent<AudioSource>();
        burgerPrepareSoundSource.clip = burgerPrepareSoundClip;

        chefHitSoundSource = gameObject.AddComponent<AudioSource>();
        chefHitSoundSource.clip = chefHitSoundClip;

        stoveDestroySoundSource = gameObject.AddComponent<AudioSource>();
        stoveDestroySoundSource.clip = stoveDestroySoundClip;

        gameOverSoundSource = gameObject.AddComponent<AudioSource>();
        gameOverSoundSource.clip = gameOverSoundClip;
    }

    // Play sound for collecting food prefabs
    public void PlayCollectSound()
    {
        if (collectSoundSource != null)
        {
            collectSoundSource.Play();
        }
    }

    // Play sound for collecting potion objects
    public void PlayPotionSound()
    {
        if (potionCollectSoundSource != null)
        {
            potionCollectSoundSource.Play();
        }
    }

    // Play sound for preparing a burger
    public void PlayBurgerPrepareSound()
    {
        if (burgerPrepareSoundSource != null)
        {
            burgerPrepareSoundSource.Play();
        }
    }

    // Play sound for a chef being hit by a burger
    public void PlayChefHitSound()
    {
        if (chefHitSoundSource != null)
        {
            chefHitSoundSource.Play();
        }
    }

    // Play sound for a stove being destroyed
    public void PlayStoveDestroySound()
    {
        if (stoveDestroySoundSource != null)
        {
            stoveDestroySoundSource.Play();
        }
    }

    // Play sound for game over
    public void PlayGameOverSound()
    {
        if (gameOverSoundSource != null)
        {
            gameOverSoundSource.Play();
        }
    }
}
