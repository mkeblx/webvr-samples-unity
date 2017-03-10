using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMeshUVs : MonoBehaviour {

	void Awake() {
		Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
		Vector3[] vertices = mesh.vertices;
		Vector2[] uvs = mesh.uv;

		Debug.Log(vertices.Length);

		uvs[7] = new Vector2(0,0);
		uvs[6] = new Vector2(1, 0);
		uvs[11] = new Vector2(0, 1);
		uvs[10] = new Vector2(1, 1);

		mesh.uv = uvs;
	}

}