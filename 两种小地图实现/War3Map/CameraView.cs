using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour {

	// Use this for initialization
	void Start () {
        rayPoint = new Vector3[4];

        for (int i = 0; i < 4; i++) {
            rayPoint[i] = Vector3.zero;
        }

	}
    public Vector3[] rayPoint;

    public Vector2 GetRate(int index) {
        Vector2 result = Vector2.zero;
        //防止越界
        index = index % rayPoint.Length;
        Vector3 localToTerrain = rayPoint[index] - myTerrain.transform.position;
        result.x = localToTerrain.x / myTerrain.terrainData.size.x;
        result.y = localToTerrain.z / myTerrain.terrainData.size.z;

        return result;
    }

    public Terrain myTerrain;
	// Update is called once per frame
	void Update () {
        Ray tmpZeroRay = Camera.main.ViewportPointToRay(Vector3.zero);
        Debug.DrawRay(tmpZeroRay.origin,tmpZeroRay.direction,Color.red);

        Ray oneToZeroRay = Camera.main.ViewportPointToRay(Vector3.right);
        Debug.DrawRay(oneToZeroRay.origin, oneToZeroRay.direction, Color.blue);

        Ray oneToOneRay = Camera.main.ViewportPointToRay(Vector3.one);
        Debug.DrawRay(oneToOneRay.origin, oneToOneRay.direction, Color.yellow);

        Ray zeroToOneRay = Camera.main.ViewportPointToRay(Vector3.up);
        Debug.DrawRay(zeroToOneRay.origin, zeroToOneRay.direction, Color.green);

        RaycastHit hitOut;
        if (Physics.Raycast(tmpZeroRay,out hitOut, 1000)) {
            //if (hitOut.transform.CompareTag("Terrain")) {
            //
            //}
            rayPoint[0] = hitOut.point;
        }
        if (Physics.Raycast(oneToZeroRay, out hitOut, 1000))
        {
            rayPoint[1] = hitOut.point;
        }
        if (Physics.Raycast(oneToOneRay, out hitOut, 1000))
        {
            rayPoint[2] = hitOut.point;
        }
        if (Physics.Raycast(zeroToOneRay, out hitOut, 1000))
        {
            rayPoint[3] = hitOut.point;
        }

    }
}
