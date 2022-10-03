using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineGostop
{
    public enum StateEvent
    {
        INIT = 0,
        START,
        PROGRESS,
        DONE,
    }

    public enum State
    {
        WAIT = 0,

        CREATE_DECK,

        SHUFFLE_8,
        SHUFFLE_10,

        OPEN_8,

        CHECK_JORKER,

        HANDS_UP,
        HANDS_OPEN,
        HANDS_SORT,

        CARD_HIT, // ī�� ġ��.
        CARD_POP, // ī�� ������.

        EAT_CHECK, // �Դ� ����.
        SCORE_UPDATE, // ���� ����.
        TURN_CHECK, // �� �ٲٱ�.

        GAME_OVER_TIE, // ���º�.
    }

    public Stack<TurnInfo> stack;

    /// <summary>
    /// �� ���� ����.
    /// </summary>
    public class TurnInfo
    {
        public int index; // �� Ƚ��.
        public Board.Player userIndex; // �� ����.
        public Card pop; // ������ ���� ����.
        public Card hit; // ���� ģ ī��.
        public bool hited = false; // �ƴ°�.
        private Stack<StateInfo> stack = null;
        

        public TurnInfo(int num = 0)
        {
            index = num;
            pop = null;
            hit = null;
            hited = false; // �ƴ°�.
            stack = new Stack<StateInfo>();
            userIndex = Board.Player.NONE;
            //queue = new Queue<StateInfo>();
        }

        public void AddState(StateInfo info)
        {
            stack.Push(info);
            //queue.Enqueue(info);
        }

        public StateInfo GetCurrentStateInfo()
        {
            return stack.Peek();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class StateInfo {
        public State state;
        public StateEvent evt;

        public StateInfo()
        {
            state = State.WAIT;
            evt = StateEvent.INIT;
        }
    }

    public static StateMachineGostop Create()
    {
        StateMachineGostop ret = new StateMachineGostop();
        if (ret != null && ret.Init())
        {
            return ret;
        }

        return null;
    }

    public bool Init()
    {
        stack = new Stack<TurnInfo>();
        stack.Push(new TurnInfo());

        return true;
    }

    public void Clear()
    {
        stack.Clear();
    }

    public void AddTurn(Board.Player userIndex)
    {
        TurnInfo info = new TurnInfo(stack.Count);
        info.userIndex = userIndex;
        stack.Push(info);
    }

    public void Change(State state)
    {
        StateInfo info = new StateInfo();
        info.state = state;
        info.evt = StateEvent.INIT;

        var turnInfo = GetCurrturnInfo();
        turnInfo.AddState(info);
    }

    public TurnInfo GetCurrturnInfo()
    {
        return stack.Peek();
    }

    public void Process(Action start, Func<bool> trigger, Action compete)
    {
        var turn = GetCurrturnInfo();
        var info = turn.GetCurrentStateInfo();
        if (info != null)
        {
            switch (info.evt)
            {
                case StateEvent.INIT:
                    info.evt = StateEvent.START;
                    break;

                case StateEvent.START:
                    info.evt = StateEvent.PROGRESS;
                    start();
                    break;

                case StateEvent.PROGRESS:
                    if (trigger() == true)
                    {
                        info.evt = StateEvent.DONE;
                    }
                    break;

                case StateEvent.DONE:
                    //queue.Dequeue();
                    compete();
                    break;
            }
        }
    }
}
