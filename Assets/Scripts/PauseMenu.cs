using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameISPaused = false;
    [SerializeField] GameObject pauseMenuUI;

    private void Awake()
    {
        pauseMenuUI.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameISPaused)
            {
                Restart();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        pauseMenuUI.SetActive(false);
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameISPaused = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameISPaused = false;
    }
    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitToDesktop()
    {
        print("Exit");
        Application.Quit();
    }
}