using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComFoodCon_06 : MonoBehaviour {
    public TweenAlpha BossEatFood;
    public PlayerMove3 player;
    public GameObject showAddfood;
    private AudioSource audioSource;
    public AudioClip getFood;
    private void Start()
    {
        showAddfood.SetActive(false);
        audioSource = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (showAddfood != null)
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
            BossEatFood.PlayForward();
        }
    }
}
