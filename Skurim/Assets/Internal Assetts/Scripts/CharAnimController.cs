using System;   
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class CharAnimController : MonoBehaviour
{
    //private Animator animController;
    private State state;
    private Vector3 slideTargetPos;
    private Action onSlideComplete;

    private Vector3 startPos;

    private enum State
    {
        Idle,
        Sliding,
        Busy,
    }

    private void Awake()
    {
        //animController = GetComponent<Animator>();
        state = State.Idle;
    }

    private void Start()
    {
        startPos = transform.position;
    }

    public void Setup(bool isPlayer)
    {
        if(isPlayer) 
        {
            //hero animations 
        }
        else
        {
            //enemy animations 
        }
    }

    private void Update()
    {
        switch(state)
        {
            case State.Idle:
                break;
            case State.Sliding:
                float slideSpeed = 10f;
                transform.position += (slideTargetPos - GetPosition()) * slideSpeed * Time.deltaTime;
                float reachedDistance = 1;
                if (Vector3.Distance(GetPosition(), slideTargetPos) < reachedDistance)
                {
                    //transform.position = slideTargetPos;
                    onSlideComplete();
                }
                break;
            case State.Busy:
                break;

        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void AttackTurn(CharAnimController targetChar, Action onAttackComplete)
    {

        Vector3 startingPos = startPos;
        Vector3 slideTargetPos = targetChar.GetPosition() +(GetPosition() - targetChar.GetPosition()).normalized*2;
        
        //attack animation

        SlideToPos(slideTargetPos, () =>
        {
            state = State.Busy;
            Vector3 attackDir = (targetChar.GetPosition() - GetPosition()).normalized;
            SlideToPos(startingPos, () =>
            {
                state = State.Idle;
                onAttackComplete();
            });
            
        });
    }

    private void SlideToPos(Vector3 slideTargetPos, Action onSlideComplete)
    {
        this.slideTargetPos = slideTargetPos;
        this.onSlideComplete = onSlideComplete;
        state = State.Sliding;
    }
}
