using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static LevelManager levelManager;
    public int LockLevel;
    int index = 0;
    private void Awake()
    {
        if (levelManager != null)
        {
            Destroy(this);
            return;
        }
        levelManager = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            LockLevel = PlayerPrefs.GetInt("level");
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
            LockLevel = PlayerPrefs.GetInt("level");
        }
    }
}
