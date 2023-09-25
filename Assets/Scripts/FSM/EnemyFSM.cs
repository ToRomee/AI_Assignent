using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyFSM : MonoBehaviour
{
    public Animator animator;

    protected BaseState currentState;

    protected virtual void OnEnable()
    {

    }
    protected virtual void Start()
    {

    }
    protected virtual void Update()
    {
        currentState.OnUpdate();
    }

    public virtual void SwicthState(BaseState state)
    {
        currentState.ExitState();
        currentState = state;
        currentState.EnterState(this);
    }

    // Update is called once per frame


    private void OnDestroy()
    {
        
    }
}
