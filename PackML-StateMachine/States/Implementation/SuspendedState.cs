using PackML_StateMachine.StateMachine;

namespace PackML_StateMachine.States.Implementation;

/**
 * The {@link SuspendedState} denotes a waiting state that is typically entered when external conditions prevent a machine from continuing execution. An
 * unsuspend command has to be issued in order to bring the state machine back to the {@link ExecuteState}.
 */
public class SuspendedState : StoppableState
{

    public override void start(Isa88StateMachine stateMachine)
    {
        // Start cannot be fired from Suspended -> Do nothing except maybe giving a warning
    }

    public override void hold(Isa88StateMachine stateMachine)
    {
        // Hold cannot be fired from Suspended -> Do nothing except maybe giving a warning
    }

    public override void unhold(Isa88StateMachine stateMachine)
    {
        // Unhold cannot be fired from Suspended -> Do nothing except maybe giving a warning
    }

    public override void suspend(Isa88StateMachine stateMachine)
    {
        // Suspend cannot be fired from Suspended -> Do nothing except maybe giving a warning
    }

    public override void unsuspend(Isa88StateMachine stateMachine)
    {
        stateMachine.setStateAndRunAction(new UnsuspendingState());
    }

    public override void reset(Isa88StateMachine stateMachine)
    {
        // Reset cannot be fired from Suspended -> Do nothing except maybe giving a warning
    }

    public override void clear(Isa88StateMachine stateMachine)
    {
        // Clear cannot be fired from Suspended -> Do nothing except maybe giving a warning
    }

}

