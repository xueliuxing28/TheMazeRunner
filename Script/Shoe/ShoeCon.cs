using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeCon : MonoBehaviour {
    public GameObject showAddfood;
    private AudioSource audioSource;
    public AudioClip getShoe;
    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ShoeNum.shoeNum.num++;
            if (PlayerPrefs.HasKey("shoeNum"))
            {
                int beforeShoeNum = PlayerPrefs.GetInt("shoeNum");
                PlayerPrefs.SetInt("shoeNum", beforeShoeNum + 1);
            }
            else
            {
                PlayerPrefs.SetInt("shoeNum", ShoeNum.shoeNum.num);
            }
            Destroy(this.gameObject,0.5f);
            if (showAddfood != null)
            {
                showAddfood.SetActive(true);
            }
            audioSource.PlayOneShot(getShoe);
        }
        if (other.tag == "Boss")
        {
            audioSource.PlayOneShot(getShoe);
            Destroy(this.gameObject);
        }
    }
}
