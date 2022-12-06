using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickEvents: MonoBehaviour
{
    public GameObject gamePausedPanel;
    public GameObject buttonsPanel;
    public GameObject aboutPanel;
    public GameObject gameOverPanel;
    public GameObject startMenuPanel;
    public GameObject leaderBoardPanel;
    public GameObject changeNamePanel;
    public GameObject aboutUsPanel;
    //private AudioSource gameAudio;
    //public AudioClip gameOverSound;

    public static bool isGamePaused = false;
    // Start is called before the first frame update
    private void Start()
    {
      //  gameAudio = GetComponent<AudioSource>();
    }
    public void Pause()
    {
        gamePausedPanel.SetActive(true);
        buttonsPanel.SetActive(false);
        changeNamePanel.SetActive(false);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    // Update is called once per frame
   public void Resume()
    {
        gamePausedPanel.SetActive(false);
        aboutPanel.SetActive(false);
        aboutUsPanel.SetActive(false);
        buttonsPanel.SetActive(true);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void Quit()
    {
        Debug.Log("Game Ended");
        Application.Quit();
    }

    public void About()
    {
        aboutPanel.SetActive(true);
        gamePausedPanel.SetActive(false);
        startMenuPanel.SetActive(false);
        buttonsPanel.SetActive(false);
    }

    public void Play()
    {
        aboutPanel.SetActive(false);
        buttonsPanel.SetActive(true);
        startMenuPanel.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        buttonsPanel.SetActive(false);
    }

    public void LeaderBoard()
    {
        leaderBoardPanel.SetActive(true);
        gameObject.SetActive(false);
        gamePausedPanel.SetActive(false);
        buttonsPanel.SetActive(false);
    }

    public void Close()
    {
        leaderBoardPanel.SetActive(false );
        buttonsPanel.SetActive(true);
    }

    public void ChangeName()
    {
        changeNamePanel.SetActive(true);
        gamePausedPanel.SetActive(false);
        buttonsPanel.SetActive(false);
    }

    public void AboutUs()
    {
        aboutUsPanel.SetActive(true);
        buttonsPanel.SetActive(false);
        buttonsPanel.SetActive(false);
    }

}
