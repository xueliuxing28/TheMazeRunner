using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayer1DieCon : MonoBehaviour {
    public GameObject Player2WinPanel;
    public GameObject Player1WinPanel;
    private AudioSource source;
    public AudioSource bgm;
    public AudioClip win;
    public FightPlayer1Move player;
    private void Start()
    {
        source = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="weapon")
        {
            Player1WinPanel.SetActive(true);
            player.die = true;
            bgm.Stop();
            source.PlayOneShot(win);
        }
      else  if (other.tag == "Enemy" || other.tag == "Boss" || other.tag == "BlueEnemy" || other.tag == "GreenEnemy" )
        {
            Player2WinPanel.SetActive(true);
            player.die = true;
            bgm.Stop();
            source.PlayOneShot(win);
        }

       else  if (other.tag == "Player2" && player.isMove)
        {
            Player2WinPanel.SetActive(true);
            player.die = true;
            bgm.Stop();
            source.PlayOneShot(win);
        }

    }
}
