using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    private Transform mainCanvas;
    //将Canvas存放
    public Transform MainCanvas {
        get {
            return mainCanvas;
        }
    }
    /// <summary>
    /// 第一个String Panel 第二个String 表示控件名字
    /// </summary>
    Dictionary<string, Dictionary<string,GameObject>> allWedgate;
    //子控件注册
    public void RegisitGameObject(string panelName, string wedgateName, GameObject obj) {
        if (!allWedgate.ContainsKey(panelName)) {
            allWedgate[panelName] = new Dictionary<string, GameObject>();
        }
        allWedgate[panelName].Add(wedgateName, obj);
    }
    //获取某一个Panel下面的子控件
    public GameObject GetGameObject(string panelName, string wedgateName) {
        if (allWedgate.ContainsKey(panelName)) {
            return allWedgate[panelName][wedgateName];
        }
        return null;
    }

    #region destory
    //将子控件从widegeName销毁
    public void UnRegistGameObject(string panelName, string widegeName) {
        if (allWedgate.ContainsKey(panelName)) {
            if (allWedgate[panelName].ContainsKey(widegeName)) {
                allWedgate[panelName].Remove(widegeName);
            }
        }
    }
    public void UnRegistPanel(string panelName)
    {
        if (allWedgate.ContainsKey(panelName))
        {
            allWedgate[panelName].Clear();
            allWedgate[panelName] = null;
        }
    }

    #endregion

    
    void Awake()
    {
        Instance = this;
        allWedgate = new Dictionary<string, Dictionary<string, GameObject>>();
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas").transform;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
