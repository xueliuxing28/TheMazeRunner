using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneTouch : MonoBehaviour {

	public Transform target;
	public Transform targetPoint;
	Animator Textanim;

	void OnTriggerEnter(Collider collision)
	{
		if (collision.transform.tag == "Player") {

			StartCoroutine ("MoveDown");
		}
	}

	void OnTriggerExit(Collider collision)
	{
		if (collision.transform.tag == "Player") {

			StartCoroutine ("MoveUp");

		}
	}

	IEnumerator MoveDown()
	{
		float _time = 0;
		while (_time < 0.2f) {
			_time += Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, targetPoint.position, 1.0f);
			yield return null;
		}

	}

	IEnumerator MoveUp()
	{
		float _time = 0;
		while (_time < 0.2f) {
			_time += Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, 1.0f);
			yield return null;
		}

	}


}
