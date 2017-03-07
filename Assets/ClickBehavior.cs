using UnityEngine;
using System.Collections;

public class ClickBehavior : MonoBehaviour
{

	private Camera cam;

	void Start()
	{
		cam = GetComponent<Camera>();

		cam.clearFlags = CameraClearFlags.SolidColor;

		cam.backgroundColor = new Color(0.1f, 0.2f, 0.3f, 1.0f);
	}

	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			cam.backgroundColor = new Color(
				Random.Range(0f, 0.5f), Random.Range(0f, 0.5f), Random.Range(0f, 0.5f)
				);
		}
	}
}
