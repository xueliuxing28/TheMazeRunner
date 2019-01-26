using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWeapon : MonoBehaviour {
    public UILabel Weapon;
	
	// Update is called once per frame
	void Update () {
        Weapon.text = "武器*" + WeaponNum.weaponNum.num;
        Debug.Log(WeaponNum.weaponNum.num);
	}
}
