using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayer2DieCon : MonoBehaviour {
    public FightPlayer2Move player;
    public GameObject Player1WinPanel;
    public GameObject Player2WinPanel;
    private AudioSource source;
    public AudioSource bgm;
    public AudioClip win;
    private void Start()
    {
        source = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon")
        {
            Player1WinPanel.SetActive(true);
            player.die = true;
            bgm.Stop();
            source.PlayOneShot(win);
        }
       else if (other.tag == "Enemy" || other.tag == "Boss" || other.tag == "BlueEnemy" || other.tag == "GreenEnemy")
        {
            Player1WinPanel.SetActive(true);
            player.die = true;
            bgm.Stop();
            source.PlayOneShot(win);
        }
       else   if (player.isMove&&other.tag=="Player1")
        {
            Player1WinPanel.SetActive(true);
            player.die = true;
            bgm.Stop();
            source.PlayOneShot(win);
        }

    }
}
