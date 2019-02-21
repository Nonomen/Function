using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanCtrl : MonoBehaviour {

    //设置动画位移方式为脚本控制
    void OnAnimatorMove()
    {

        //characterCtl.Move(animator.deltaPosition);//animator.deltaPosition  应用 动画片段 的位移
        //characterCtl.Move(animator.rootPosition);//animator.deltaPosition  应用 动画根骨骼 的位移
        //characterCtl.Move(Vector3.forward * 0.1f);
        //characterCtl.Move(animator.rootPosition);
    }

    CharacterController characterCtl;
    Animator animator;
    // Use this for initialization
    void Start () {
        characterCtl = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
