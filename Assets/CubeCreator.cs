using UnityEngine;
using System.Collections;

public class CubeCreator : MonoBehaviour {

    public Transform cube;

	void Start () {
        int gridSize = 10;
	    for (int x = 0; x < gridSize; ++x)
        {
            for (int y = 0; y < gridSize; ++y)
            {
                for (int z = 0; z < gridSize; ++z)
                {
                    if (x == 0 && y == 0 && z == 0)
                        continue;
                    Instantiate(cube, new Vector3(x - gridSize/2, y - gridSize/2, z - gridSize/2), Quaternion.Euler(0, 180, 0));
                }
            }
        }
	}

	void Update () {

	}
}
