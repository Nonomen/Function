using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UISubManager : MonoBehaviour {


    Dictionary<string, Transform> allChild;


    void Awake() {

        UIBase tmpBase = transform.GetComponentInParent<UIBase>();

        UIManager.Instance.RegisitGameObject(tmpBase.name, transform.name, gameObject);


        allChild = new Dictionary<string, Transform>();
        //所有子控件添加到allChild
        Transform[] tmpChild = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < tmpChild.Length; i++)
        {
            if (tmpChild[i].name.EndsWith("_S"))
            {
                allChild.Add(tmpChild[i].name, tmpChild[i]);
            }
        }
    }
    void Start () {

        
    }
    //根据名字获取子控件
    public Transform GetChildTransform(string wedgateName) {
        return allChild[wedgateName];
    }
    //销毁接口
    void OnDestroy(){
        if (allChild != null) {
            allChild.Clear();
            allChild = null;
        }
    }
    public void AddButtonListen(string wedgateName, UnityAction action) {
        //找到子控件
        Transform tmpTransform = GetChildTransform(wedgateName);

        
        //从子控件获取Button组件
        Button tmpButton = tmpTransform.GetComponent<Button>();


        if (tmpButton != null) {
            tmpButton.onClick.AddListener(action);
        }
    }

    void Update () {
		
	}
}
