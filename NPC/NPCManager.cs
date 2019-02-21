using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCManagerModle {
    private float forwardDistance = 10;
    public float ForwardDistance {
        get {
            return forwardDistance;
        }
        set {
            forwardDistance = value;
        }
    }
    private float rightDistance = 5;
    public float RightDistance
    {
        get
        {
            return rightDistance;
        }
        set {
            rightDistance = value;
        }
    }
    private float reduceDistance = 5;
    public float ReduceDistance
    {
        get
        {
            return reduceDistance;
        }
        set
        {
            reduceDistance = value;
        }
    }
}
public class NPCManager : MonoBehaviour {

    public static NPCManager Instance;
    private Transform player;
    public Transform Player {
        get {
            if (player == null) {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
            return player;
        }
    }

    /// <summary>
    /// 矩阵攻击判定
    /// </summary>
    /// <param name="attacker">攻击者</param>
    /// <param name="attacked">被攻击者</param>
    /// <param name="forwardDistance">矩阵前后长度</param>
    /// <param name="rightDistance">矩阵左右长度</param>
    /// <returns>bool</returns>
    public bool IsRectAttack(Transform attacker, Transform attacked, float forwardDistance, float rightDistance)
    {
        //A向量
        Vector3 deltA = attacked.position - attacker.position;
        float forwardDotA = Vector3.Dot(attacker.forward, deltA);
        if (forwardDotA > 0 || forwardDotA < forwardDistance)
        {
            if (Mathf.Abs(Vector3.Dot(attacker.right, deltA)) < rightDistance)
            {
                return true;
            }
        }
        return false;
    }


    /// <summary>
    /// 玩家放大招 NPC检测受伤
    /// </summary>
    public void AttackByPlayer() {
        for (int i = 0; i < allNpc.Count; i++) {
            NPCCell tmpCell = allNpc[i];
            if (IsRectAttack(Player, tmpCell.transform, npcManagerModle.ForwardDistance, npcManagerModle.RightDistance)) {
                tmpCell.ReduceBlood(npcManagerModle.ReduceDistance);
            }
        }
    }
    //存储所有NPC
    List<NPCCell> allNpc;
    /// <summary>
    /// 工厂模式 生成一个NPC
    /// </summary>
    /// <param name="path">NPC资源路径</param>
    /// <param name="NPCParent">NPC位置父类</param>
    /// <returns></returns>
    public GameObject FactoryNPC(string path, Transform NPCParent) {
        Object tmpOBJ = Resources.Load(path);
        GameObject tmpNPC = GameObject.Instantiate(tmpOBJ) as GameObject;
        tmpNPC.transform.SetParent(NPCParent, false);
        NPCCell tmpCell = tmpNPC.AddComponent<NPCCell>();
        allNpc.Add(tmpCell);
        return tmpNPC;
    }



    NPCManagerModle npcManagerModle;
    private void Awake()
    {
        Instance = this;
        allNpc = new List<NPCCell>();
        npcManagerModle = new NPCManagerModle();
    }
    // Use this for initialization
    void Start () {
		
	}
    /// <summary>
    /// 是否跟随玩家
    /// </summary>
    public void AIFollowPlayer() {
        for (int i = 0; i < allNpc.Count; i++) {
            NPCCell tmpCell = allNpc[i];
            tmpCell.AIAttack();
        }
    }
    
	// Update is called once per frame
	void Update () {
        AIFollowPlayer();
	}
}
