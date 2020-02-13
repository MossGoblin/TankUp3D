using UnityEngine;
using System;
using System.Collections.Generic;
public static class AIStateSelector
{
    public static (AIStance stance, AIState state) SelectState(AIStance currentStance, AIState currentState, Context currentContext)
    {
        // TODO : HERE - ALL THE STATE LOGIC GOES HERE
        return (AIStance.Balanced, AIState.Roam);
    }
}