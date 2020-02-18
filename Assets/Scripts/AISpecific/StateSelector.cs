using UnityEngine;
using System;
using System.Collections.Generic;
public static class StateSelector
{
    public static (Stance stance, State state) SelectState(Stance currentStance, State currentState, Context currentContext)
    {
        // TODO : HERE - ALL THE STATE LOGIC GOES HERE
        return (Stance.Balanced, State.Roam);
    }
}