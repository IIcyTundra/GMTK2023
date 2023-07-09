using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScreenController : MonoBehaviour
{
    private bool readyToPlay = false;
    [SerializeField] private TMP_Text pressAnyText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        pressAnyText.gameObject.SetActive(true);
        playButton.SetActive(false);
        MusicManager.Instance.PlayTrack(MusicManager.Track.MainMenuTrack);
    }

    // Update is called once per frame
    void Update()
    {
        if (!readyToPlay)
        {
            if (Input.anyKeyDown)
            {
                readyToPlay = true;
            }
        } else
        {
            pressAnyText.gameObject.SetActive(false);
            playButton.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }
}
