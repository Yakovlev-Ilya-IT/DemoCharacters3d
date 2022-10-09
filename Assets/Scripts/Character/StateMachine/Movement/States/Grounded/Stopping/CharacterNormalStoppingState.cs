public class CharacterNormalStoppingState : CharacterStoppingState
{
    public CharacterNormalStoppingState(IStationStateSwitcher stateSwitcher, Character character, CharacterMovementStatesReusableData reusableData) : base(stateSwitcher, character, reusableData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Initialize();

        _character.View.StartMediumStopping();
    }

    private void Initialize()
    {
        _reusableData.TimeToStop = StoppingConfig.TimeToNormalStop;
    }

    public override void Exit()
    {
        base.Exit();

        _character.View.StopMediumStopping();
    }
}
