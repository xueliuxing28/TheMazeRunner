using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveCon : MonoBehaviour {
    private Vector3 startDir;
    public Transform startPoint;
    private int speed = 1;
    private Animator theAnim;
	// Use this for initialization
	void Start () {
        startDir = Vector3.Normalize(this.transform.position);
        theAnim = GetComponent<Animator>();
        if (theAnim!=null)
        {
            Destroy(theAnim, 4f);
        }
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftControl)||Input.GetKey(KeyCode.RightControl))
        {
            if (Vector3.Distance(startPoint.position,transform.position)<6)
            {
                transform.Translate(startDir*Time.deltaTime*speed);
            }
        }
        else
        {
            transform.position = startPoint.position;
        }
	}
}
