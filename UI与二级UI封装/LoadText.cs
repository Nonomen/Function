using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadText : UIBase {


    public void OnClickN() {
        Debug.Log("On Click N");
    }
    public void OnClickS()
    {
        Debug.Log("On Click S");
    }
    public void OnClickS1()
    {
        Debug.Log("On Click S1");
    }
    // Use
    // Use this for initialization
    public void Drag(BaseEventData eventData)
    {
        PointerEventData tmpEvent = (PointerEventData)eventData;
        transform.position = tmpEvent.position;
    }
    void Start () {
        AddButtonListen("Button_N", OnClickN);

        ChangeTextContent("Text_N", "Click!!");

        AddDrag("Image_N", Drag);

        AddButtonListen("Panel_C", "Button_S", OnClickS);
        AddButtonListen("Panel1_C", "Button_S", OnClickS1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
