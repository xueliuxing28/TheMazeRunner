using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEnterDoor : MonoBehaviour {
    public GameObject WinUI1;
    public GameObject WinUI2;
    private AudioSource source;
    public AudioSource bgm;
    public AudioClip victory;
    private void Start()
    {
        source = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player1")
        {
            WinUI1.SetActive(true);
            bgm.Stop();
            source.PlayOneShot(victory);
        }
        if (other.tag == "Player2")
        {
            WinUI2.SetActive(true);
            bgm.Stop();
            source.PlayOneShot(victory);
        }
    }
}
