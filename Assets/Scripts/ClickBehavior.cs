using UnityEngine;
using System.Collections;

public class ClickBehavior : MonoBehaviour
{
	public Camera[] cameras;

	private Color color = new Color(0.1f, 0.2f, 0.3f, 1.0f);

	void Start()
	{

	}

	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			color.a = Random.Range(0f, 0.5f);
			color.g = Random.Range(0f, 0.5f);
			color.b = Random.Range(0f, 0.5f);

			foreach (Camera cam in cameras)
			{
				cam.backgroundColor = color;
			}
		}

#if UNITY_HAS_GOOGLEVR && (UNITY_ANDROID || UNITY_EDITOR)

#endif
	}
}
