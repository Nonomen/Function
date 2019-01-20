using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class UIBase : MonoBehaviour {
    //子控件注册
    void Awake() {
        Transform[] allChildren = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChildren.Length; i++) {
            if (allChildren[i].name.EndsWith("_N")) {
                allChildren[i].gameObject.AddComponent<UIBehavriour>();
            }
            if (allChildren[i].name.EndsWith("_C")) {
                allChildren[i].gameObject.AddComponent<UISubManager>();
            }
        }
    }

    public UISubManager GetSubManager(string cellName) {
        GameObject tmpObj = GetWedgate(cellName);
        if (tmpObj != null) {
            return tmpObj.GetComponent<UISubManager>();
        }
        return null;
    }
    //获取子控件
    public GameObject GetWedgate(string wedgateName) {
        return UIManager.Instance.GetGameObject(transform.name,wedgateName);
    }
    //获取脚本
    public UIBehavriour GetBehavriour(string wedgateName) {
        GameObject tmpObj = GetWedgate(wedgateName);
        if (tmpObj != null) {
            return tmpObj.GetComponent<UIBehavriour>();
        }
        return null;
    }
    //销毁本身
    private void OnDestroy()
    {
        UIManager.Instance.UnRegistPanel(transform.name);
    }

    #region 获取Canvas
    public Transform GetCanvas()
    {
        return UIManager.Instance.MainCanvas;
    }

    #endregion


    #region 生成新窗口
    public GameObject InitialPanel(string panelPath)
    {
        //界面加载到内存
        Object tmpObj = Resources.Load(panelPath);
        //实例化GameObject
        GameObject panelObj = GameObject.Instantiate(tmpObj) as GameObject;
        panelObj.name = panelObj.name.Replace("(Clone)", "");

        //放在Canvs下
        Transform mainCanvas = GetCanvas();
        panelObj.transform.SetParent(mainCanvas, false);
        //返回生成的新窗口
        return panelObj;
    }
    #endregion 
    /*按钮绑定监听事件(string 按钮名， UnityAction 动作名)（string SubManager名， string 按钮名， UnityAction 动作名）*/
    public void AddButtonListen(string wedgateName, UnityAction action) {
        UIBehavriour tmpBehavriour = GetBehavriour(wedgateName);
        if (tmpBehavriour != null) {
            tmpBehavriour.AddButtonListen(action);
        }
    }
    public void AddButtonListen(string cellName, string wedgateName, UnityAction action)
    {
        UISubManager tmpSub = GetSubManager(cellName);
        if (tmpSub != null)
        {
            tmpSub.AddButtonListen(wedgateName, action);
        }
    }
    /*改变文字信息*/
    public void ChangeTextContent(string wedgateName,string content)
    {
        UIBehavriour tmpBehavriour = GetBehavriour(wedgateName);
        if (tmpBehavriour != null)
        {
            tmpBehavriour.ChangeTextContent(content);
        }
    }
    /*添加拖拽事件*/
    public void AddDrag(string wedgateName,UnityAction<BaseEventData> action) {
        UIBehavriour tmpBehavriour = GetBehavriour(wedgateName);
        if (tmpBehavriour != null)
        {
            tmpBehavriour.AddDragInterface(action);
        }
    }
    //获取文字信息
    public void AddInputFiledListen(string wedgateName, UnityAction<string> action)
    {
        UIBehavriour tmpBehavriour = GetBehavriour(wedgateName);
        if (tmpBehavriour != null)
        {
            tmpBehavriour.AddInputFiledEndEditorListen(action);
        }
    }

}
