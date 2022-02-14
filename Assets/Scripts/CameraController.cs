using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	public float panSpeed = 2f;
	public float panBorderThickness = 2f;
	public Vector2 panLimit;
	public float zoom = 20;

	public float scrollSpeed = 2f;
	public float minY = 20f;
	public float maxY = 20f;

	
	// Update is called once per frame
	void Update ()
	{
		Vector3 pos = transform.position;

		if (Input.GetKey ("w"))
		{
			pos.y += panSpeed * Time.deltaTime;
		}
		if (Input.GetKey ("s"))
		{
			pos.y -= panSpeed * Time.deltaTime;
		}
		if (Input.GetKey ("d"))
		{
			pos.x += panSpeed * Time.deltaTime;
		}
		if (Input.GetKey ("a"))
		{
			pos.x -= panSpeed * Time.deltaTime;
		}
		if (Input.GetKey ("Mouse ScrollWheel") > 0)
		{
			zoom -= 1;
		}
		if (Input.GetKey ("Mouse ScrollWheel") < 0)
		{
			zoom += 1;
		}
		GetComponent<Camera> ().orthagraphicSize = zoom;

		pos.x = Mathf.Clamp (pos.x, -panLimit.x, panLimit.x);
		pos.y = Mathf.Clamp (pos.y, -panLimit.y, panLimit.y);
		transform.position = pos;
	}
}
