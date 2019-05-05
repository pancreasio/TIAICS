﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    int[,] fsm;

    int currentState;

    public FSM(int statesCount, int eventCounts, int initState)
    {
        fsm = new int[statesCount, eventCounts];

        for (int i = 0; i < statesCount; i++)
        {
            for (int j = 0; j < eventCounts; j++)
            {
                fsm[i, j] = -1;
            }
        }

        currentState = initState;

    }

    public void SetRelation(int srcState, int evt, int dstState)
    {
        fsm[srcState, evt] = dstState;
    }

    public void SendEvent(int evt)
    {
        if (fsm[currentState, evt] != -1)
        {
            currentState = fsm[currentState, evt];
        }

    }

    public int GetState()
    {
        return currentState;
    }


}
