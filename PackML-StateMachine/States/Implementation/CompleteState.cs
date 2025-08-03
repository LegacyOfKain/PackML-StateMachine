using PackML_StateMachine.StateMachine;

namespace PackML_StateMachine.States.Implementation;
/**
 * The {@link CompleteState} denotes a state in which the machine has completed production. In order to start the next order, a reset command is
 * necessary to transition to {@link IdleState}.
 */
public class CompleteState : StoppableState
{
    public override void start(Isa88StateMachine stateMachine)
    {
        // Start cannot be fired from Complete -> Do nothing except maybe giving a warning
    }


    public override void hold(Isa88StateMachine stateMachine)
    {
        // Hold cannot be fired from Complete -> Do nothing except maybe giving a warning
    }


    public override void unhold(Isa88StateMachine stateMachine)
    {
        // Unhold cannot be fired from Complete -> Do nothing except maybe giving a warning
    }


    public override void suspend(Isa88StateMachine stateMachine)
    {
        // Suspend cannot be fired from Complete -> Do nothing except maybe giving a warning
    }


    public override void unsuspend(Isa88StateMachine stateMachine)
    {
        // Unsuspend cannot be fired from Complete -> Do nothing except maybe giving a warning
    }


    public override void reset(Isa88StateMachine stateMachine)
    {
        stateMachine.setStateAndRunAction(new ResettingState());
    }


    public override void clear(Isa88StateMachine stateMachine)
    {
        // Clear cannot be fired from Clearing -> Do nothing except maybe giving a warning
    }

}

