using JetBrains.Annotations;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audiosource;         // Per click e porte
    private AudioSource objectiveSource;     // Solo per suoni obiettivo
    private AudioSource footstepsSource;

    public AudioClip mouseClickClip;
    public AudioClip normalDoorClip;
    public AudioClip newObjectiveClip;
    public AudioClip scifiDoorClip;
    public AudioClip wrongAnswer;
    public AudioClip button;
    public AudioClip MainMenuMusic;
    public AudioClip Footsteps;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            // Primo AudioSource per suoni generali
            audiosource = GetComponent<AudioSource>();
            if (audiosource == null)
                audiosource = gameObject.AddComponent<AudioSource>();

            // Secondo AudioSource per obiettivi
            objectiveSource = gameObject.AddComponent<AudioSource>();
            footstepsSource = gameObject.AddComponent<AudioSource>();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void PlayMouseClickSound()
    {
        if (Instance != null && Instance.audiosource != null && Instance.mouseClickClip != null)
        {
            Instance.audiosource.clip = Instance.mouseClickClip;
            Instance.audiosource.Play();
        }
        else
        {
            Debug.LogWarning("AudioManager instance or audio clip is missing.");
        }
    }

    public static void PlayNormalDoor()
    {
        if (Instance != null && Instance.audiosource != null && Instance.normalDoorClip != null)
        {
            Instance.audiosource.clip = Instance.normalDoorClip;
            Instance.audiosource.Play();
        }
        else
        {
            Debug.LogWarning("AudioManager instance or audio clip is missing.");
        }
    }

    public static void PlayNewObjective()
    {
        if (Instance != null && Instance.objectiveSource != null && Instance.newObjectiveClip != null)
        {
            Instance.objectiveSource.clip = Instance.newObjectiveClip;
            Instance.objectiveSource.volume = 0.2f; 
            Instance.objectiveSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioManager instance or objective audio clip is missing.");
        }
    }

    public static void PlaySciFiDoor()
    {
        if (Instance != null && Instance.audiosource != null && Instance.scifiDoorClip != null)
        {
            Instance.audiosource.clip = Instance.scifiDoorClip;
            Instance.audiosource.volume = 0.3f;
            Instance.audiosource.Play();
        }
        else
        {
            Debug.LogWarning("AudioManager instance or sci-fi door audio clip is missing.");
        }
    }
    public static void PlayWrongAnswer()
    {
        if (Instance != null && Instance.audiosource != null && Instance.wrongAnswer != null)
        {
            Instance.audiosource.clip = Instance.wrongAnswer;
            Instance.audiosource.volume = 0.3f; // Set volume to a lower level for wrong answer sound
            Instance.audiosource.Play();
        }
        else
        {
            Debug.LogWarning("AudioManager instance or wrong answer audio clip is missing.");
        }
    }
    public static void PlayButtonSound()
    {
        if (Instance != null && Instance.audiosource != null && Instance.button != null)
        {
            Instance.audiosource.clip = Instance.button;
            Instance.audiosource.Play();
        }
        else
        {
            Debug.LogWarning("AudioManager instance or button audio clip is missing.");
        }
    }

    public static void PlayMainMenuMusic()
    {
        if (Instance != null && Instance.objectiveSource != null && Instance.MainMenuMusic != null)
        {
            Instance.objectiveSource.clip = Instance.MainMenuMusic;
            Instance.objectiveSource.volume = 0.08f; // Set volume to a lower level for background music
            Instance.objectiveSource.loop = true; // Loop the main menu music
            Instance.objectiveSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioManager instance or main menu music audio clip is missing.");
        }
    }

    public static void StopMainMenuMusic()
    {
        Instance.objectiveSource.loop = false; // Stop looping the main menu music
        if (Instance != null && Instance.objectiveSource != null)
        {
            Instance.objectiveSource.Stop();
        }
        else
        {
            Debug.LogWarning("AudioManager instance or objective audio source is missing.");
        }
    }

    public static void PlaySteps(FirstPersonController fpc)
    {
        if (Instance == null || Instance.footstepsSource == null || Instance.Footsteps == null)
        {
            Debug.LogWarning("AudioManager instance or footsteps audio clip/source is missing.");
            return;
        }

        if (!fpc.isPlayerWalking())
        {
            StopSteps();
            return;
        }

        if (!Instance.footstepsSource.isPlaying)
        {
            Instance.footstepsSource.clip = Instance.Footsteps;
            Instance.footstepsSource.volume = 0.6f; // Volume passi
            Instance.footstepsSource.loop = true;
            Instance.footstepsSource.Play();
        }
    }


    public static void StopSteps()
    {
        if (Instance != null && Instance.footstepsSource != null)
        {
            Instance.footstepsSource.Stop();
        }
        else
        {
            Debug.LogWarning("AudioManager instance or footsteps audio source is missing.");
        }
    }
}
