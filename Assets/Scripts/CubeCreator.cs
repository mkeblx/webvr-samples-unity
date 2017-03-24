using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class CubeCreator : MonoBehaviour {

	[SerializeField] private float m_RenderScale = 1f;

	public GameObject cube;

	public GameObject cubes;
	public GameObject combined;

	public GameObject rotatingCubes;
	private readonly float RotationSpeed = 30f;

	private bool merge = true;

	void Awake() {
		VRSettings.renderScale = m_RenderScale;
	}

	void Start() {
		int gridSize = 10;
		for (int x = 0; x < gridSize; ++x)
		{
			for (int y = 0; y < gridSize; ++y)
			{
				for (int z = 0; z < gridSize; ++z)
				{
					Vector3 position = new Vector3(x - gridSize / 2, y - gridSize / 2, (z - gridSize / 2) * -1);
					if (position.x == 0 && position.y == 0 && position.z == 0)
						continue;
					GameObject cb = Instantiate(cube, position, Quaternion.Euler(0, 180f, 0), cubes.transform) as GameObject;
					cb.name = "Cube"+x+y+z;
					cb.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
				}
			}
		}

		if (merge)
		{
			MeshFilter[] meshFilters = cubes.GetComponentsInChildren<MeshFilter>();
			Debug.Log(meshFilters.Length);
			CombineInstance[] combine = new CombineInstance[meshFilters.Length];
			int i = 0;
			while (i < meshFilters.Length)
			{
				combine[i].mesh = meshFilters[i].sharedMesh;
				combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
				meshFilters[i].gameObject.SetActive(false);
				i++;
			}
			combined.GetComponent<MeshFilter>().mesh = new Mesh();
			combined.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
			combined.gameObject.SetActive(true);

			combined.GetComponent<Renderer>().material = cube.GetComponent<Renderer>().sharedMaterial;
		}


		// rotating cubes
		// = [ [0, 0.25, -0.8], [0.8, 0.25, 0], [0, 0.25, 0.8], [-0.8, 0.25, 0] ];
		GameObject _cube;
		float _scale = 0.05f * 2f;
		float h = 0.25f;
		Vector3 scale = new Vector3(_scale, _scale, _scale);
		_cube = Instantiate(cube, new Vector3(0, h, 0.8f), Quaternion.Euler(0, 180f, 0), rotatingCubes.transform) as GameObject;
		_cube.transform.localScale = scale;
		_cube = Instantiate(cube, new Vector3(0, h, -0.8f), Quaternion.identity, rotatingCubes.transform) as GameObject;
		_cube.transform.localScale = scale;
		_cube = Instantiate(cube, new Vector3(0.8f, h, 0), Quaternion.identity, rotatingCubes.transform) as GameObject;
		_cube.transform.localScale = scale;
		_cube = Instantiate(cube, new Vector3(-0.8f, h, 0), Quaternion.identity, rotatingCubes.transform) as GameObject;
		_cube.transform.localScale = scale;

		rotatingCubes.transform.position.Set(0f, 25f, 0f);
	}

	void Update() {
		rotatingCubes.transform.Rotate(Vector3.up * (-RotationSpeed * Time.deltaTime));
	}

	void Merge(GameObject fromContainer, GameObject toObject) {

	}

}