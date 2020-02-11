public static class AIStateSelector
{
    public static (AIStance stance, AIState state) SelectState(AIStance currentStance, AIState currentState, BattleContext currentContext)
    {
        // TODO : HERE - ALL THE STATE LOGIC GOES HERE
        return (AIStance.Balanced, AIState.Roam);
    }
}