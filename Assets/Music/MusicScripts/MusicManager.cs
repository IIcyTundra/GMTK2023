using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Singleton instance
    public static MusicManager Instance { get; private set; }

    // AudioSource component
    private AudioSource audioSource;

    // Array to hold music tracks
    public AudioClip[] musicTracks;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }

    public enum Track
    {
        MainMenuTrack,
        NonCombatTrack,
        CombatTrack,
        GameOverTrack
    }

    public void PlayTrack(Track track)
    {
        int trackIndex = (int)track;

        if (trackIndex < 0 || trackIndex >= musicTracks.Length)
        {
            Debug.LogError("Track index out of range");
            return;
        }

        audioSource.clip = musicTracks[trackIndex];
        audioSource.Play();
    }
}
