using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapText : MonoBehaviour {


    public Transform player;
    public Terrain terrain;
    // Use this for initialization

    RectTransform parentRect;
    Vector3 deltaPos;
    float tmpRateX;
    float tmpRateY;
    Vector2 resule = Vector2.zero;

    void Start () {

        parentRect = transform.parent.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        deltaPos = player.position - terrain.transform.position;
        tmpRateX = deltaPos.x / terrain.terrainData.size.x;
        tmpRateY = deltaPos.z / terrain.terrainData.size.z;



        resule.x = parentRect.sizeDelta.x * tmpRateX;
        resule.y = parentRect.sizeDelta.y * tmpRateY;

        transform.localPosition = resule;
    }
}
