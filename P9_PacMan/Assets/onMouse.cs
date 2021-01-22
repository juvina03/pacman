using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouse : MonoBehaviour
{
	static public GameObject target; // the target that the camera should look at

	void Start()
	{
		//face();
	}

	// Update is called once per frame
	/*void face()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

		Vector2 direction = new Vector2(
				mousePosition.x - transform.position.x,
				mousePosition.y - transform.position.y
			);

		transform.up = direction;
	}*/
}
