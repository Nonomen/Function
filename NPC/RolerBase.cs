using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class RolerBase : MonoBehaviour {

    FSMManager fSMManager;
    CharacterController characterController;


    public enum AnimationEnum
    {
        Wait,
        Jump,
        Walk,
        Wait02,
        Max
    }

    public void SimpleMove(Vector3 speed) {
        characterController.SimpleMove(speed);
    }
    public virtual void ChangeState(sbyte state) {
        fSMManager.ChangeState(state);
    }
    public virtual void Initial() {
        fSMManager = new FSMManager((int)AnimationEnum.Max);
        characterController = transform.GetComponent<CharacterController>();


    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
