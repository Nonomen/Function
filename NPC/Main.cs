using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    /// <summary>
    /// 启动组织框架
    /// </summary>
    private void Awake()
    {
        gameObject.AddComponent<UIManager>();
        gameObject.AddComponent<WWWHelper>();
        gameObject.AddComponent<AudioManager>();
        gameObject.AddComponent<NPCManager>();


        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
