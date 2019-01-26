using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNum : MonoBehaviour {
    public static WeaponNum weaponNum;
    public int num;
    void Start()
    {
        if (PlayerPrefs.HasKey("weaponNum"))
        {
            if (PlayerPrefs.GetInt("weaponNum")<0)
            {
                PlayerPrefs.SetInt("weaponNum", 0);
            }
            num = PlayerPrefs.GetInt("weaponNum");
        }
        else
        {
            PlayerPrefs.SetInt("weaponNum", 0);
            num = PlayerPrefs.GetInt("weaponNum");
        }
        if (weaponNum != null)
        {
            Destroy(this);
            return;
        }
        weaponNum = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
