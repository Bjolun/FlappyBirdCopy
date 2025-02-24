using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusicClip;
    
    public static AudioManager instance;
    private AudioSource audioSource;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        audioSource.clip = backgroundMusicClip;
        audioSource.Play();
    }

    public void PlayCrashSFX(AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx);
    }
}
