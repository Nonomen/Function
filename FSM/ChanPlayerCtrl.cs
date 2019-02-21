using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWait : FSMBase {
    Animator animator;
    public PlayerWait(Animator tmpAnimator) {
        animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        //base.OnEnter();
        animator.SetInteger("Index",1);
    }
}

public class PlayerJump : FSMBase
{
    Animator animator;
    ChanPlayerCtrl myCtrl;
    public PlayerJump(Animator tmpAnimator, ChanPlayerCtrl ctrl)
    {
        animator = tmpAnimator;
        myCtrl = ctrl;
    }
    public override void OnEnter()
    {
        //base.OnEnter();
        animator.SetInteger("Index", 2);
        isPlayerWait = false;
        timeCount = 0;
    }
    float timeCount = 0;
    bool isPlayerWait = false;
    public override void OnStay()
    {
        //base.OnStay();
        timeCount += Time.deltaTime;

        if (timeCount > 1.30f && !isPlayerWait) {
            //do something

            isPlayerWait = true;
            Debug.Log("Player Jump!");

        }
        else if (timeCount > 2.5f) {
            myCtrl.ChangeState((sbyte)ChanPlayerCtrl.AnimationEnum.Wait);
        }
    }
    public override void OnExit()
    {
        //base.OnExit();
        Debug.Log("Jump Exit!");
        isPlayerWait = false;
        timeCount = 0;
    }
}

public class PlayerWalk : FSMBase
{
    Animator animator;
    public PlayerWalk(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        //base.OnEnter();
        animator.SetInteger("Index", 3);
    }
    public override void OnStay()
    {
        //base.OnStay();
    }
}

public class PlayerWait02 : FSMBase
{
    Animator animator;
    public PlayerWait02(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        //base.OnEnter();
        animator.SetInteger("Index", 4);
    }
}


public class ChanPlayerCtrl : MonoBehaviour {

    FSMManager fsmManager;
    public enum AnimationEnum {
        Wait,
        Jump,
        Walk,
        Wait02,
        Max
    }
    public void ChangeState(sbyte state) {
        fsmManager.ChangeState(state);
    }

	// Use this for initialization
	void Start () {
        fsmManager = new FSMManager((int)AnimationEnum.Max);
        Animator animator = GetComponent<Animator>();
        PlayerWait tmpWait = new PlayerWait(animator);
        fsmManager.AddState(tmpWait);
        PlayerJump tmpJump = new PlayerJump(animator, this);
        fsmManager.AddState(tmpJump);
        PlayerWalk tmpWalk = new PlayerWalk(animator);
        fsmManager.AddState(tmpWalk);
        PlayerWait02 tmpWait02 = new PlayerWait02(animator);
        fsmManager.AddState(tmpWait02);


    }
	
	// Update is called once per frame
	void Update () {
        fsmManager.Stay();

        if (Input.GetKeyDown(KeyCode.A)) {
            fsmManager.ChangeState((sbyte)AnimationEnum.Walk);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            fsmManager.ChangeState((sbyte)AnimationEnum.Jump);
        }
    }
}
