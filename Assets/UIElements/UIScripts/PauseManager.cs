using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // singleton instance
    public static PauseManager instance { get; private set; }

    // track pause state
    public bool isPaused { get; private set; }

    // other
    [SerializeField] private GameObject pauseScreen;

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
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f; // Resume time
        pauseScreen.SetActive(false); // Hide pause menu
        isPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f; // Pause time
        pauseScreen.SetActive(true); // Show pause menu
        isPaused = true;
    }

    public void ExitToMainMenu()
    {
        isPaused = false;
        pauseScreen.SetActive(false); // Hide pause menu
        // CHANGE LOADED SCENE TO MAIN MENU AFTER IT IS IMPLEMENTED
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}