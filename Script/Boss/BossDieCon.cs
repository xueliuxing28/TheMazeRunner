using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDieCon : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy"||other.tag == "BlueEnemy" || other.tag == "GreenEnemy")
        {
            Destroy(this.gameObject);
        }
        if (other.tag == "weapon")
        {
            Destroy(this.gameObject);
        }
    }
}
