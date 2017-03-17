using UnityEngine;
using System.Collections;

public class ClickBehavior : MonoBehaviour
{

	public Camera cam;
	public Camera cam2;

	private Color color = new Color(0.1f, 0.2f, 0.3f, 1.0f);

	void Start()
	{
		cam.clearFlags = CameraClearFlags.SolidColor;
		cam2.clearFlags = CameraClearFlags.SolidColor;

		cam.backgroundColor = color;
		cam2.backgroundColor = color;
	}

	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			color.a = Random.Range(0f, 0.5f);
			color.g = Random.Range(0f, 0.5f);
			color.b = Random.Range(0f, 0.5f);

			cam.backgroundColor = color;
			cam2.backgroundColor = color;
		}
	}
}
