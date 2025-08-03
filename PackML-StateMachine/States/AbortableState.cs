using PackML_StateMachine.StateMachine;
using PackML_StateMachine.States.Implementation;

namespace PackML_StateMachine.States;

/**
 * Abstract super class of all ISA-88 states that can just be aborted but not stopped (i.e. Stopping, Clearing, Stopped).
 */
public abstract class AbortableState : State
{
    public override void abort(Isa88StateMachine stateMachine)
    {
        stateMachine.setStateAndRunAction(new AbortingState());
    }


    public override void stop(Isa88StateMachine stateMachine)
    {
    }
}

