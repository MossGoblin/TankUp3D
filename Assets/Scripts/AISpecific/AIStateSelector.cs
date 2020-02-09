public static class AIStateSelector
{
    public static AIState SelectState(AIStance currentStance, AIState currentState, BattleContext currentContext)
    {
        // TODO : HERE - ALL THE STATE LOGIC GOES HERE
        return AIState.Roam;
    }
}