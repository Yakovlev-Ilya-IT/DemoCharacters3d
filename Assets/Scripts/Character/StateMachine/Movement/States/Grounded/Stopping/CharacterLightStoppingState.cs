public class CharacterLightStoppingState : CharacterStoppingState
{
    public CharacterLightStoppingState(IStationStateSwitcher stateSwitcher, Character character, CharacterMovementStatesReusableData reusableData) : base(stateSwitcher, character, reusableData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Initialize();
    }

    private void Initialize()
    {
        _reusableData.TimeToStop = StoppingConfig.TimeToLightStop;
    }
}
