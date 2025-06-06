static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake) 
        => !knightIsAwake;

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake) 
        => knightIsAwake || archerIsAwake || prisonerIsAwake;

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
        => prisonerIsAwake && !archerIsAwake;

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
    {
        bool condition1 = petDogIsPresent && !archerIsAwake;
        bool condition2 = !petDogIsPresent && !archerIsAwake && !knightIsAwake && prisonerIsAwake;
        return condition1 || condition2;
    }
}
