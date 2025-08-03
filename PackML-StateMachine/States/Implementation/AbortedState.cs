using PackML_StateMachine.StateMachine;

namespace PackML_StateMachine.States.Implementation;
/**
 * The {@link AbortedState} denotes a state in which the machine has been brought to a sudden halt. A
 * clear-command is necessary to transition to {@link StoppedState}.
 */
public class AbortedState : State
{

    public override void start(Isa88StateMachine stateMachine)
    {
        // Start cannot be fired from Aborted -> Do nothing except maybe giving a warning
    }

    public override void hold(Isa88StateMachine stateMachine)
    {
        // Hold cannot be fired from Aborted -> Do nothing except maybe giving a warning
    }


    public override void unhold(Isa88StateMachine stateMachine)
    {
        // Unhold cannot be fired from Aborted -> Do nothing except maybe giving a warning
    }


    public override void suspend(Isa88StateMachine stateMachine)
    {
        // Suspend cannot be fired from Aborted -> Do nothing except maybe giving a warning
    }


    public override void unsuspend(Isa88StateMachine stateMachine)
    {
        // Unsuspend cannot be fired from Aborted -> Do nothing except maybe giving a warning
    }


    public override void reset(Isa88StateMachine stateMachine)
    {
        // Reset cannot be fired from Aborted -> Do nothing except maybe giving a warning
    }


    public override void stop(Isa88StateMachine stateMachine)
    {
        // Stop cannot be fired from Aborted -> Do nothing except maybe giving a warning
    }


    public override void abort(Isa88StateMachine stateMachine)
    {
        // Abort cannot be fired from Aborted -> Do nothing except maybe giving a warning
    }


    public override void clear(Isa88StateMachine stateMachine)
    {
        stateMachine.setStateAndRunAction(new ClearingState());
    }
}

