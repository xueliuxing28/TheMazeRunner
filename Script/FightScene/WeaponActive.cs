using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActive : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
