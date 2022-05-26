using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] State targetState;
    public EnemyData enemyData;

    public State TargetState
    {
        get {return targetState;}
    }
    
    public bool NeedTransit
    {
        get;
        protected set;
    }
}
