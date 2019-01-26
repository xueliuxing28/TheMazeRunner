using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComFoodCon_01 : MonoBehaviour {
    public GameObject showAddfood;
    private AudioSource audioSource;
    public AudioClip getFood;
    public PlayerMove1 player;
    private void Start()
    {
        showAddfood.SetActive(false);
        audioSource = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (showAddfood!=null)
            {
                showAddfood.SetActive(true);
            }
            audioSource.PlayOneShot(getFood);
            player.foodNum +=5;
            Destroy(this.gameObject,0.5f);
        }
        if (other.tag == "Boss")
        {
            Destroy(this.gameObject);
        }
    }
}
