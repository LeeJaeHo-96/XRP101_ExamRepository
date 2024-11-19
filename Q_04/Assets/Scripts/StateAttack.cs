using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;

    private Coroutine _delayRoutine;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    public override void Enter()
    {
        if (_delayRoutine == null)
        {
            _delayRoutine = Controller.StartCoroutine(DelayRoutine(Attack));
        }
    }

    public override void OnUpdate()
    {
        Debug.Log("Attack On Update");
    }

    public override void Exit()
    {
        Machine.ChangeState(StateType.Idle);
    }

    private void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;
        foreach (Collider col in cols)
        {
            
                damagable = col.GetComponent<IDamagable>();

            if (damagable == null)
                return;
            
                Debug.Log(damagable);
                damagable.TakeHit(Controller.AttackValue);
            
            
        }
    }

    public IEnumerator DelayRoutine(Action action)
    {
        yield return _wait;
        Debug.Log("공격 시작");
        Attack();
        Exit();
    }

}
