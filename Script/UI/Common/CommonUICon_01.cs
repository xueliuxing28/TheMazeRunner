using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonUICon_01 : MonoBehaviour {
    public GameObject ExitPanel;
    public TweenAlpha LoadingScene;
    public GameObject DiePanel;
    public TweenAlpha BossEatFood;
    int index = 0;
    private  AudioSource bgsource;
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
        if (index<15)
        {
            LoadingScene.PlayForward();
            Invoke("ChangeSenceToNext", 0.5f);
        }
        else
        {
            LoadingScene.PlayForward();
            Invoke("ChangeSenceToStart", 0.5f);
        }

        
    }
   public  void OnExitYesButtonClick()
    {
        LoadingScene.PlayForward();
        Invoke("ChangeSenceToStart", 0.5f);
    }
     public void OnExitNoButtonClick()
    {
        ExitPanel.SetActive(false);
    }
    void ChangeSenceToNext()
    {
        SceneManager.LoadScene(++index);
    }
    void ChangeSenceToStart()
    {
        SceneManager.LoadScene(0);
    }
    public void OnDieContinueButttonClick()
    {
        DiePanel.SetActive(false);
        LoadingScene.PlayForward();
        Invoke("ChangeSenceToStart", 0.5f);
    }
    public void OnFinishBossEatFood()
    {
        BossEatFood.PlayReverse();
    }
    public void onRestartGame()
    {
        SceneManager.LoadScene(index);
    }
}
