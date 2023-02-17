// ReSharper disable InconsistentNaming
namespace Data
{
    public class EnumContainer
    {
        
    }

    public enum GameState
    {
        CheckState,
        CutScene,
        GamePlay,
        GameEnd
    }

    public enum StoryProgressStates
    {
        Idle,
        IntroCS,
        ExitStorageBoxGP,
        LookAroundGP,
        ControlsTutorialGP,
        FindFilesGP,
        MorgueHistoryCS,
        NurseReturningCS,
        HideInStorageBoxGP,
        ObserveNurseAndBehaviorCS,
        StealInjectionGP,
        
    }

    public enum SpawnableUIObjects
    {
        ScreenFade,
        
    }
}