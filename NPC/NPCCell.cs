using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// M层的数据 从配置文件中读取
/// </summary>
public class NPCData {
    float bloodCount;
    public float BloodCount {
        get {
            return bloodCount;
        }
        set {
            bloodCount = value;
        }
    }
    float followDistance = 10;
    public float FollowDistance
    {
        get
        {
            return followDistance;
        }
        set
        {
            followDistance = value;
        }
    }
    float attackDistance = 5;
    public float AttackDistance
    {
        get
        {
            return attackDistance;
        }
        set
        {
            attackDistance = value;
        }
    }
    float moveSpeed = 5;
    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            moveSpeed = value;
        }
    }
}
public class NPCCell : RolerBase {
    NPCData npcData;

    public void Awake()
    {
        Initial();    }

    public override void Initial()
    {
        base.Initial();
        npcData = new NPCData();
    }

    /// <summary>
    /// NPC掉血
    /// </summary>
    /// <param name="reduce"></param>
    public void ReduceBlood(float reduce) {
        npcData.BloodCount -= reduce;
    }

    public void AIAttack() {
        //NPC 与玩家距离小于10  跟随 小于5  攻击
        Vector3 deltA = NPCManager.Instance.Player.position - transform.position;
        if (deltA.magnitude < npcData.FollowDistance) {

            if (deltA.magnitude < npcData.AttackDistance)
            {
                //攻击
                ChangeState((sbyte)AnimationEnum.Wait02);

            }
            else {
                //跟随
                SimpleMove(deltA.normalized * npcData.MoveSpeed);
            }
        }
        
    }
}
