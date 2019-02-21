using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectAttack : MonoBehaviour {

    //矩型攻击判定
    public bool IsRectAttack(Transform attacker, Transform attacked, float forwardDistance, float rightDistance) {
        //A向量
        Vector3 deltA = attacked.position - attacker.position;
        float forwardDotA = Vector3.Dot(attacker.forward, deltA);
        if (forwardDotA > 0 || forwardDotA < forwardDistance) {
            if (Mathf.Abs(Vector3.Dot(attacker.right, deltA)) < rightDistance) {
                return true;
            }
        }
        return false;
    }
    public bool IsUmbrellaAttack(Transform attacker, Transform attacked, float angle, float radius) {
        Vector3 deltA = attacked.position - attacker.position;
        float tmpAngle = Mathf.Acos(Vector3.Dot(deltA.normalized, attacker.forward)) * Mathf.Deg2Rad;
        if (tmpAngle < angle * 0.5f && deltA.magnitude < radius) {
            return true;
        }
        return false;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
