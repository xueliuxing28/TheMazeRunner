using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonEnterDoorCon : MonoBehaviour {
    public GameObject WinUI;
    private AudioSource source;
    public AudioSource  bgm;
    public AudioClip victory;
    int index = 0;
    private void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        source = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            WinUI.SetActive(true);
            bgm.Stop();
            source.PlayOneShot(victory);
            if (index == 8)
            {
                if (PlayerPrefs.HasKey("level"))
                {
                    int beforeLevel = PlayerPrefs.GetInt("level");
                    if (beforeLevel<index-6)
                    {
                        PlayerPrefs.SetInt("level", index - 6);
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("level", index - 6);
                }
                LevelManager.levelManager.LockLevel = PlayerPrefs.GetInt("level");
               // LevelManager.levelManager.Level2Lock.SetActive(false);
            }
            else  if (index == 9)
            {
                if (PlayerPrefs.HasKey("level"))
                {
                    int beforeLevel = PlayerPrefs.GetInt("level");
                    if (beforeLevel < index - 6)
                    {
                        PlayerPrefs.SetInt("level", index - 6);
                    }
                }
                LevelManager.levelManager.LockLevel = PlayerPrefs.GetInt("level");
                // LevelManager.levelManager.Level3Lock.SetActive(false);
            }
            else if (index == 10)
            {
                if (PlayerPrefs.HasKey("level"))
                {
                    int beforeLevel = PlayerPrefs.GetInt("level");
                    if (beforeLevel < index - 6)
                    {
                        PlayerPrefs.SetInt("level", index - 6);
                    }
                }
                LevelManager.levelManager.LockLevel = PlayerPrefs.GetInt("level");
                // LevelManager.levelManager.Level4Lock.SetActive(false);
            }
            else if (index == 11)
            {
                if (PlayerPrefs.HasKey("level"))
                {
                    int beforeLevel = PlayerPrefs.GetInt("level");
                    if (beforeLevel < index - 6)
                    {
                        PlayerPrefs.SetInt("level", index - 6);
                    }
                }
                LevelManager.levelManager.LockLevel = PlayerPrefs.GetInt("level");
                // LevelManager.levelManager.Level5Lock.SetActive(false);
            }
            else if (index == 12)
            {
                if (PlayerPrefs.HasKey("level"))
                {
                    int beforeLevel = PlayerPrefs.GetInt("level");
                    if (beforeLevel < index - 6)
                    {
                        PlayerPrefs.SetInt("level", index - 6);
                    }
                }
                LevelManager.levelManager.LockLevel = PlayerPrefs.GetInt("level");
                // LevelManager.levelManager.Level6Lock.SetActive(false);
            }
            else if (index == 13)
            {
                if (PlayerPrefs.HasKey("level"))
                {
                    int beforeLevel = PlayerPrefs.GetInt("level");
                    if (beforeLevel < index - 6)
                    {
                        PlayerPrefs.SetInt("level", index - 6);
                    }
                }
                LevelManager.levelManager.LockLevel = PlayerPrefs.GetInt("level");
                // LevelManager.levelManager.Level7Lock.SetActive(false);
            }
            else if (index == 14)
            {
                if (PlayerPrefs.HasKey("level"))
                {
                    int beforeLevel = PlayerPrefs.GetInt("level");
                    if (beforeLevel < index - 6)
                    {
                        PlayerPrefs.SetInt("level", index - 6);
                    }
                }
                LevelManager.levelManager.LockLevel = PlayerPrefs.GetInt("level");
                // LevelManager.levelManager.Level8Lock.SetActive(false);
            }
        }
    }
}
