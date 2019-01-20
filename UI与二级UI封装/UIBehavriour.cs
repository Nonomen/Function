using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class UIBehavriour : MonoBehaviour {

    void Awake() {
        UIBase tmpBase = transform.GetComponentInParent<UIBase>();
        UIManager.Instance.RegisitGameObject(tmpBase.name, transform.name, gameObject);
    }
    public void AddButtonListen(UnityAction action) {
        Button tmpBtn = transform.GetComponent<Button>();
        if (tmpBtn != null) {
            tmpBtn.onClick.AddListener(action);
        }
    }
    public void AddSliderListen(UnityAction<float> action) {
        Slider tmpBtn = transform.GetComponent<Slider>();
        if (tmpBtn != null)
        {
            tmpBtn.onValueChanged.AddListener(action);
        }
    }
    public void AddInputFiledEndEditorListen(UnityAction<string> action)
    {
        TMP_InputField tmpBtn = transform.GetComponent<TMP_InputField>();
        if (tmpBtn != null)
        {
            tmpBtn.onEndEdit.AddListener(action);
        }
    }
    public void AddInputFiledValueChangeListen(UnityAction<string> action)
    {
        InputField tmpBtn = transform.GetComponent<InputField>();
        if (tmpBtn != null)
        {
            tmpBtn.onValueChanged.AddListener(action);
        }
    }
    public void ChangeTextContent(string content) {
        Text tmp = transform.GetComponent<Text>();
        if (tmp != null) {
            tmp.text = content;
        }
    }
    public void ChangeImage(Sprite content)
    {
        Image tmp = transform.GetComponent<Image>();
        if (tmp != null)
        {
            tmp.sprite = content;
        }
    }
    //动态添加接口事件
    public void AddDragInterface(UnityAction<BaseEventData> action) {
        //获取事件系统 不存在动态添加
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
            trigger = gameObject.AddComponent<EventTrigger>();

        //事件实体
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //拖拽事件（类型）
        entry.eventID = EventTriggerType.Drag;
        //事件回调
        entry.callback = new EventTrigger.TriggerEvent();
        //添加回调函数
        entry.callback.AddListener(action);
        //监听事件
        trigger.triggers.Add(entry);
    }
    public void AddBeginDrag(UnityAction<BaseEventData> action)
    {
        //获取事件系统 不存在动态添加
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
            trigger = gameObject.AddComponent<EventTrigger>();

        //事件实体
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //拖拽事件（类型）
        entry.eventID = EventTriggerType.BeginDrag;
        //事件回调
        entry.callback = new EventTrigger.TriggerEvent();
        //添加回调函数
        entry.callback.AddListener(action);
        //监听事件
        trigger.triggers.Add(entry);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
