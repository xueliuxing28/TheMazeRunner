using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyDieCon : MonoBehaviour {
    public AudioSource source;
    public GameObject weapon;
    public GameObject model;
    public GameObject breakmodel;
    public GameObject[] smallobj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="weapon")
        {
            model.SetActive(false);
            breakmodel.SetActive(true);
            Die();
            Invoke("DisappearWeapon", 0.5f);
        }
    }
    void Die()
    {
        source.Play();
        Camera.main.DOShakePosition(0.5f);
        Destroy(this.gameObject,2f);
        for (int i = 0; i < smallobj.Length; i++)
        {
            Destroy(smallobj[i], 1f);
        }
    }
    void DisappearWeapon()
    {
        if (WeaponNum.weaponNum.num>0)
        {
            WeaponNum.weaponNum.num = WeaponNum.weaponNum.num - 1;
            if (PlayerPrefs.HasKey("weaponNum"))
            {
                int beforeShoeNum = PlayerPrefs.GetInt("weaponNum");
                PlayerPrefs.SetInt("weaponNum", beforeShoeNum - 1);
            }
        }

        weapon.SetActive(false);
    }
}
