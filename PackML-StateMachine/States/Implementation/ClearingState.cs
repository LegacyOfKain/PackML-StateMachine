﻿using PackML_StateMachine.StateMachine;

namespace PackML_StateMachine.States.Implementation;
/**
 * The {@link ClearingState} denotes a transitive state that can be used to clear a machine from damaged products after it was aborted. After the
 * clearing action has been executed, the state machine will change to the {@link StoppedState}.
 */
public class ClearingState : AbortableState
{
    public override void start(Isa88StateMachine stateMachine)
    {
        // Start cannot be fired from Clearing -> Do nothing except maybe giving a warning
    }


    public override void hold(Isa88StateMachine stateMachine)
    {
        // Hold cannot be fired from Clearing -> Do nothing except maybe giving a warning
    }


    public override void unhold(Isa88StateMachine stateMachine)
    {
        // Unhold cannot be fired from Clearing -> Do nothing except maybe giving a warning
    }


    public override void suspend(Isa88StateMachine stateMachine)
    {
        // Suspend cannot be fired from Clearing -> Do nothing except maybe giving a warning
    }


    public override void unsuspend(Isa88StateMachine stateMachine)
    {
        // Unsuspend cannot be fired from Clearing -> Do nothing except maybe giving a warning
    }


    public override void reset(Isa88StateMachine stateMachine)
    {
        // Reset cannot be fired from Clearing -> Do nothing except maybe giving a warning
    }


    public override void stop(Isa88StateMachine stateMachine)
    {
        // Stop cannot be fired from Clearing -> Do nothing except maybe giving a warning
    }


    public override void clear(Isa88StateMachine stateMachine)
    {
        // Clear cannot be fired from Clearing -> Do nothing except maybe giving a warning
    }


    public override async Task executeActionAndCompleteAsync(Isa88StateMachine stateMachine, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Logger.LogDebug("Cancellation requested in {StateName} state.", nameof(this.GetType));
            return; // Exit if cancellation is requested
        }

        IStateAction actionToRun = stateMachine.getStateActionManager().getAction(ActiveStateName.Clearing);
        base.executeAction(actionToRun);

        // Make sure the current state is still Clearing before going to Stopped (could have been changed in the mean time).
        if (stateMachine.getState() is ClearingState) {
            await stateMachine.setStateAndRunActionAsync(new StoppedState());
        }
    }

}
