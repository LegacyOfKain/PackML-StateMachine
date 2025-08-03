﻿using PackML_StateMachine.StateMachine;

namespace PackML_StateMachine.States.Implementation;
/**
 * The {@link AbortingState} denotes a transitive state that should bring a machine to a sudden halt. Damages on products have to be expected. From
 * Aborting, no commands are accepted. After executing its action, the state machine will change to the {@link AbortedState}.
 */
public class AbortingState : State
{
    public override void start(Isa88StateMachine stateMachine)
    {
        // Start cannot be fired from Aborting -> Do nothing except maybe giving a warning
    }

    
    public override void hold(Isa88StateMachine stateMachine)
    {
        // Hold cannot be fired from Aborting -> Do nothing except maybe giving a warning
    }

    
    public override void unhold(Isa88StateMachine stateMachine)
    {
        // Unhold cannot be fired from Aborting -> Do nothing except maybe giving a warning
    }

    
    public override void suspend(Isa88StateMachine stateMachine)
    {
        // Suspend cannot be fired from Aborting -> Do nothing except maybe giving a warning
    }

    
    public override void unsuspend(Isa88StateMachine stateMachine)
    {
        // Unsuspend cannot be fired from Aborting -> Do nothing except maybe giving a warning
    }

    
    public override void reset(Isa88StateMachine stateMachine)
    {
        // Reset cannot be fired from Aborting -> Do nothing except maybe giving a warning
    }

    
    public override void stop(Isa88StateMachine stateMachine)
    {
        // Stop cannot be fired from Aborting -> Do nothing except maybe giving a warning
    }

    
    public override void abort(Isa88StateMachine stateMachine)
    {
        // Abort cannot be fired from Aborting -> Do nothing except maybe giving a warning
    }

    
    public override void clear(Isa88StateMachine stateMachine)
    {
        // Clear cannot be fired from Aborting -> Do nothing except maybe giving a warning
    }

    
    public override async Task executeActionAndCompleteAsync(Isa88StateMachine stateMachine, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Logger.LogDebug("Cancellation requested in {StateName} state.", nameof(this.GetType));
            return; // Exit if cancellation is requested
        }

        IStateAction actionToRun = stateMachine.getStateActionManager().getAction(ActiveStateName.Aborting);
        base.executeAction(actionToRun);

        // Make sure the current state is still Aborting before going to Aborted (could have been changed in the mean time).
        if (stateMachine.getState() is AbortingState) {
            await stateMachine.setStateAndRunActionAsync(new AbortedState());
        }
    }

}
