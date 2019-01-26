using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCon : MonoBehaviour {
    public GameObject showAddfood;
    private AudioSource audioSource;
    public AudioClip getWeapon;
    private void Start()
    {
        showAddfood.SetActive(false);
        audioSource = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            WeaponNum.weaponNum.num++;
            if (PlayerPrefs.HasKey("weaponNum"))
            {
                int beforeWeaponNum = PlayerPrefs.GetInt("weaponNum");
                PlayerPrefs.SetInt("weaponNum", beforeWeaponNum + 1);
            }
            else
            {
                PlayerPrefs.SetInt("weaponNum", WeaponNum.weaponNum.num);
            }
            Destroy(this.gameObject,0.5f);
            if (showAddfood != null)
            {
                showAddfood.SetActive(true);
            }
            audioSource.PlayOneShot(getWeapon);
        }
        if (other.tag == "Boss")
        {
            Destroy(this.gameObject);
        }
    }
}
