using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodCon : MonoBehaviour {
    public GameObject showAddfood;
    private AudioSource audioSource;
    public AudioClip getFood;
    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Destroy(this.gameObject, 0.5f);
            if (showAddfood != null)
            {
                showAddfood.SetActive(true);
            }
            audioSource.PlayOneShot(getFood);
            FoodNum.foodNum.food += 10;
        }
        if (other.tag == "Boss")
        {
            audioSource.PlayOneShot(getFood);
            Destroy(this.gameObject);
        }
    }
}
