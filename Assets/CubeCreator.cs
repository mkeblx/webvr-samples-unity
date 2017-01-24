using UnityEngine;
using System.Collections;

/*
 * Create the Cube Sea
 TODO:
 -add background: color change on click
 -add rotating cubes
*/

public class CubeCreator : MonoBehaviour {

    public GameObject cube;

    public GameObject rotatingCubes;
    private readonly float RotationSpeed = 0.5f;

    void Start() {
        int gridSize = 10;
	    for (int x = 0; x < gridSize; ++x)
        {
            for (int y = 0; y < gridSize; ++y)
            {
                for (int z = 0; z < gridSize; ++z)
                {
                    Vector3 position = new Vector3(x - gridSize / 2, y - gridSize / 2, z - gridSize / 2);
                    if (position.x == 0 && position.y == 0 && position.z == 0)
                    { // TODO: correct, float issue? works, so why cube at 0
                        Debug.Log("zero");
                        Debug.Log(position.x);
                        continue;
                    }
                    //Instantiate(cube, position, Quaternion.Euler(0, 180, 0));
                }
            }
        }

        // TODO: merge
        // https://docs.unity3d.com/ScriptReference/Mesh.CombineMeshes.html

        // TODO: make rotating cubes
        // = [ [0, 0.25, -0.8], [0.8, 0.25, 0], [0, 0.25, 0.8], [-0.8, 0.25, 0] ];
        rotatingCubes.transform.position.Set(0f, 0.25f, 0f);
        GameObject _cube;
        _cube = Instantiate(cube, rotatingCubes.transform) as GameObject;
        _cube.transform.position.Set(0f, 0f, -0.8f);
        _cube = Instantiate(cube, rotatingCubes.transform) as GameObject;
        _cube.transform.position.Set(0f, 0f, 0.8f);
        _cube = Instantiate(cube, rotatingCubes.transform) as GameObject;
        _cube.transform.position.Set(0.8f, 0f, 0f);
        _cube = Instantiate(cube, rotatingCubes.transform) as GameObject;
        _cube.transform.position.Set(-0.8f, 0f, 0f);
    }

    void Update() {
        // TODO: rotating cubes
        rotatingCubes.transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));

    }
}
