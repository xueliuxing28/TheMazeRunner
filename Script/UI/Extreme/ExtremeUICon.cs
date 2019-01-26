using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtremeUICon : MonoBehaviour {
    public GameObject ExitPanel;
    public TweenAlpha LoadingScene;
    public GameObject WinGamePanel;
    private int index = 0;
    public GameObject DiePanel;
    private AudioSource bgsource;
    private void Start()
    {
        bgsource = this.GetComponent<AudioSource>();
        bgsource.Play();
        WinGamePanel.SetActive(false);
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
        Invoke("ReturnStartScene", 0.5f);
    }
    public void OnDieContinueButttonClick()
    {
        DiePanel.SetActive(false);
        LoadingScene.PlayForward();
        Invoke("ReturnStartScene", 0.5f);
    }
    public void OnExitYesButtonClick()
    {
        LoadingScene.PlayForward();
        Invoke("ReturnStartScene", 0.5f);
    }
    public void OnExitNoButtonClick()
    {
        ExitPanel.SetActive(false);
    }
    void ChangeSenceToStart()
    {
        LoadingScene.PlayForward();
        Invoke("ReturnStartScene", 0.5f);
    }
   public  void ReturnStartScene()
    {
        SceneManager.LoadScene(0);
    }
}
