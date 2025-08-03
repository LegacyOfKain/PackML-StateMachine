using PackML_StateMachine.StateMachine;

namespace PackML_StateMachine.States.Implementation;
/**
 * The {@link StoppedState} denotes a state in which the machine is powered and stationary. Communications with other systems are functioning. A
 * reset-command will cause a transition from {@link StoppedState} to {@link ResettingState}.
 */
public class StoppedState : AbortableState
{
    public override void start(Isa88StateMachine stateMachine)
    {
        // Start cannot be fired from Stopped -> Do nothing except maybe giving a warning
    }


    public override void hold(Isa88StateMachine stateMachine)
    {
        // Hold cannot be fired from Stopped -> Do nothing except maybe giving a warning
    }


    public override void unhold(Isa88StateMachine stateMachine)
    {
        // Unhold cannot be fired from Stopped -> Do nothing except maybe giving a warning
    }


    public override void suspend(Isa88StateMachine stateMachine)
    {
        // Suspend cannot be fired from Stopped -> Do nothing except maybe giving a warning
    }


    public override void unsuspend(Isa88StateMachine stateMachine)
    {
        // Unsuspend cannot be fired from Stopped -> Do nothing except maybe giving a warning
    }


    public override void reset(Isa88StateMachine stateMachine)
    {
        stateMachine.setStateAndRunAction(new ResettingState());
    }


    public override void clear(Isa88StateMachine stateMachine)
    {
        // Clear cannot be fired from Stopped -> Do nothing except maybe giving a warning
    }

}

