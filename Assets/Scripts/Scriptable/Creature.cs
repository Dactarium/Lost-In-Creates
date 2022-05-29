using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Creature", menuName = "ScriptableObjects/Creature", order = 1)]
public class Creature : ScriptableObject
{
    [SerializeField] public int health;

    [SerializeField] public bool canAttack;
    [ShowIf(ActionOnConditionFail.DontDraw, ConditionOperator.And, nameof(canAttack))]
    [SerializeField] public int damage;

    [SerializeField] public bool canMove;
    [ShowIf(ActionOnConditionFail.DontDraw, ConditionOperator.And, nameof(canMove))]
    [SerializeField] public float moveSpeed;

    [SerializeField] public bool canRun;
    [ShowIf(ActionOnConditionFail.DontDraw, ConditionOperator.And, nameof(canRun))]
    [SerializeField] public float runSpeed;

    [SerializeField] public bool canJump;
    [ShowIf(ActionOnConditionFail.DontDraw, ConditionOperator.And, nameof(canJump))]
    [SerializeField] public float jumpHeight;
    [ShowIf(ActionOnConditionFail.DontDraw, ConditionOperator.And, nameof(canJump))]
    [SerializeField] public float gravity;
}
