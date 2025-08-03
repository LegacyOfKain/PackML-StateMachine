using PackML_StateMachine.StateMachine;
using PackML_StateMachine.States.Implementation;

namespace PackML_StateMachine.States;

/**
 * Abstract super class for all states that can be stopped and aborted
 */
public abstract class StoppableState : AbortableState
{
    public override void stop(Isa88StateMachine stateMachine)
    {
        // Execute the stop-method that the developer implemented (has that to be executed in another thread?)
        // Inside of the thread: Update the state in the ontology to now be "Stopping"
        // When the thread is done: Update the state in the ontology to now be "Stopped" (might have to be done in the other thread as well)
        stateMachine.setStateAndRunAction(new StoppingState());
    }
}
