using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtEnterDoorControl : MonoBehaviour {
    public TweenAlpha LoadingScene;
    public GameObject WinGamePanel;
    int index = 0;
    private void Start()
    {
        WinGamePanel.SetActive(false);
        index = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (index < 7)
            {
                LoadingScene.PlayForward();
                Invoke("ChangeSenceToNext", 0.5f);
            }
            else
                ChangeSenceToNext();

        }
    }
    void ChangeSenceToNext()
    {
        if (index <= 6)
        {
            SceneManager.LoadScene(++index);
        }
        else if (index==7)
        {
            WinGamePanel.SetActive(true);
        }
    }
}
