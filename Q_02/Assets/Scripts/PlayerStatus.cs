using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float _MoveSpeed;
    public float MoveSpeed
    {
        get => MoveSpeed;
        private set => _MoveSpeed = value;
        
    }
    

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        MoveSpeed = 5f;
    }
}
