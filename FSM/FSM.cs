using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMBase {
    public virtual void OnEnter() {

    }
    public virtual void OnStay() {

    }
    public virtual void OnExit() {

    }
}
public class FSMManager {
    FSMBase[] allState;

    #region Initial

    public FSMManager(int stateCount) {
        Initial(stateCount);
    }

    public void Initial(int stateCount) {
        allState = new FSMBase[stateCount];
    }

    #endregion

    sbyte curState = -1;//存储状态数量
    sbyte stateIndex = -1;//当前状态
    //添加新的状态
    public void AddState(FSMBase tmpBase) {
        if (curState > allState.Length - 1) return;
        curState++;
        allState[curState] = tmpBase;
        
    }
    //状态切换
    public void ChangeState(sbyte index) {

        if (index > allState.Length || index == stateIndex) return;
        if (stateIndex != -1) {
            allState[stateIndex].OnExit();
        }
        stateIndex = index;
        allState[stateIndex].OnEnter();
    }
    //一直在UpData
    public void Stay() {
        if (stateIndex != -1) 
            allState[stateIndex].OnStay();
    }
}
