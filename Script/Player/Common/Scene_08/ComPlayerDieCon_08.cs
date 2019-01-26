using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComPlayerDieCon_08 : MonoBehaviour {
    public PlayerMove3_08 player;
    public GameObject DiePanel;
    private AudioSource source;
    public AudioSource bgm;
    public AudioClip fail;
    private void Start()
    {
        DiePanel.SetActive(false);
        source = this.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (player.foodNum < 0)
        {
            DiePanel.SetActive(true);
            player.die = true;
            bgm.Stop();
            source.PlayOneShot(fail);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Boss" || other.tag == "BlueEnemy" || other.tag == "GreenEnemy" || other.tag == "Boss")
        {
            DiePanel.SetActive(true);
            player.die = true;
            bgm.Stop();
            source.PlayOneShot(fail);
        }
    }
}
