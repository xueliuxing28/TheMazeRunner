using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightUICon : MonoBehaviour {

    public GameObject ExitPanel;
    public TweenAlpha LoadingScene;
    int index = 0;
    private AudioSource bgsource;
    private void Start()
    {
        bgsource = this.GetComponent<AudioSource>();
        bgsource.Play();
        index = SceneManager.GetActiveScene().buildIndex;
        ExitPanel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ExitPanel.SetActive(true);
        }
    }
    public void OnWinContinueButttonClick()
    {
            LoadingScene.PlayForward();
            Invoke("ChangeSenceToStart", 0.5f);
    }
    public void OnExitYesButtonClick()
    {
        LoadingScene.PlayForward();
        Invoke("ChangeSenceToStart", 0.5f);
    }
    public void OnExitNoButtonClick()
    {
        ExitPanel.SetActive(false);
    }
    void ChangeSenceToStart()
    {
        SceneManager.LoadScene(0);
    }
    public void onRestartGame()
    {
        SceneManager.LoadScene(index);
    }
}
