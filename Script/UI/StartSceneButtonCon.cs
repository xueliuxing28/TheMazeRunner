using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneButtonCon : MonoBehaviour {
    public TweenAlpha StartPannl;
    public TweenAlpha ModelPannl;
    public GameObject SelectPannl;
    public TweenAlpha HelpPannl;
    public TweenAlpha TitlePianl;
    public TweenAlpha LoadingPanel;
    public GameObject Level2Lock;
    public GameObject Level3Lock;
    public GameObject Level4Lock;
    public GameObject Level5Lock;
    public GameObject Level6Lock;
    public GameObject Level7Lock;
    public GameObject Level8Lock;

    private void Start()
    {
        SelectPannl.SetActive(false);
        if (LevelManager.levelManager.LockLevel >= 2)
        {
            Level2Lock.SetActive(false);
        }
        if (LevelManager.levelManager.LockLevel >= 3)
        {
            Level3Lock.SetActive(false);
        }
        if (LevelManager.levelManager.LockLevel >= 4)
        {
            Level4Lock.SetActive(false);
        }
        if (LevelManager.levelManager.LockLevel >= 5)
        {
            Level5Lock.SetActive(false);
        }
        if (LevelManager.levelManager.LockLevel >= 6)
        {
            Level6Lock.SetActive(false);
        }
        if (LevelManager.levelManager.LockLevel >= 7)
        {
            Level7Lock.SetActive(false);
        }
       if (LevelManager.levelManager.LockLevel >= 8)
        {
            Level8Lock.SetActive(false);
        }
    }
    private void Update()
    {
        OnESCButtonClick();
    }
    public void OnESCButtonClick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartPannl.PlayReverse();
            ModelPannl.PlayReverse();
            SelectPannl.SetActive(false);
            HelpPannl.PlayReverse();
            TitlePianl.PlayReverse();
        }   
    }
    public void OnFirstStartButtonClick()
    {
        StartPannl.PlayForward();
        ModelPannl.PlayForward();
    }
    public void OnCommonModelButtonClick()
    {
        TitlePianl.PlayForward();
        SelectPannl.SetActive(true);
        ModelPannl.PlayReverse();
    }
    public void OnExtremeModelButtonClick()
    {
        LoadingPanel.PlayForward();
      Invoke("ChangeSenceToExtreme", 0.5f);
    }
    public void OnFightModelButtonClick()
    {
        LoadingPanel.PlayForward();
        Invoke("ChangeSenceToFight", 0.5f);
    }
    public void OnHelpButtonClick()
    {
        StartPannl.PlayForward();
        TitlePianl.PlayForward();
        HelpPannl.PlayForward();
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    void ChangeSenceToExtreme()
    {
      SceneManager.LoadScene(1);    
    }
  void ChangeSenceToFight()
    {
        SceneManager.LoadScene(16);
    }
    void ChangeSenceToCom01()
    {
        SceneManager.LoadScene("ComScene01");
    }
    void ChangeSenceToCom02()
    {
        SceneManager.LoadScene("ComScene02");
    }
    void ChangeSenceToCom03()
    {
        SceneManager.LoadScene("ComScene03");
    }
    void ChangeSenceToCom04()
    {
        SceneManager.LoadScene("ComScene04");
    }
    void ChangeSenceToCom05()
    {
        SceneManager.LoadScene("ComScene05");
    }
    void ChangeSenceToCom06()
    {
        SceneManager.LoadScene("ComScene06");
    }
    void ChangeSenceToCom07()
    {
        SceneManager.LoadScene("ComScene07");
    }
    void ChangeSenceToCom08()
    {
        SceneManager.LoadScene("ComScene08");
    }
    void ChangeSenceToCom09()
    {
        SceneManager.LoadScene("ComScene09");
    }
    public void OnLevel_01Click()
    {
        LoadingPanel.PlayForward();
        Invoke("ChangeSenceToCom01", 0.5f);
    }
    public void OnLevel_02Click()
    {
        if (!Level2Lock.activeSelf)
        {
            LoadingPanel.PlayForward();
            Invoke("ChangeSenceToCom02", 0.5f);
        }
    }
    public void OnLevel_03Click()
    {
        if (!Level3Lock.activeSelf)
        {
            LoadingPanel.PlayForward();
            Invoke("ChangeSenceToCom03", 0.5f);
        }

    }
    public void OnLevel_04Click()
    {
        if (!Level4Lock.activeSelf)
        {
            LoadingPanel.PlayForward();
            Invoke("ChangeSenceToCom04", 0.5f);
        }        
    }
    public void OnLevel_05Click()
    {
        if (!Level5Lock.activeSelf)
        {
            LoadingPanel.PlayForward();
            Invoke("ChangeSenceToCom05", 0.5f);
        }
    }
    public void OnLevel_06Click()
    {
        if (!Level6Lock.activeSelf)
        {
            LoadingPanel.PlayForward();
            Invoke("ChangeSenceToCom06", 0.5f);
        }
    }
    public void OnLevel_07Click()
    {
        if (!Level7Lock.activeSelf)
        {
            LoadingPanel.PlayForward();
            Invoke("ChangeSenceToCom07", 0.5f);
        }
    }
    public void OnLevel_08Click()
    {
        if (!Level8Lock.activeSelf)
        {
            LoadingPanel.PlayForward();
            Invoke("ChangeSenceToCom08", 0.5f);
        }
    }
    public void OnLevel_09Click()
    {
        Debug.Log(111111);
    }
}
