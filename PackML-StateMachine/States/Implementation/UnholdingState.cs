using PackML_StateMachine.StateMachine;

namespace PackML_StateMachine.States.Implementation;

/**
 * The {@link UnholdingState} denotes a transitive state that is entered after the machine has been suspended and an unhold command has been issued. After executing the action the state
 * machine will transition back to the {@link ExecuteState}.
 */
public class UnholdingState : StoppableState
{
    public override void start(Isa88StateMachine stateMachine)
    {
        // Start cannot be fired from Unholding -> Do nothing except maybe giving a warning
    }


    public override void hold(Isa88StateMachine stateMachine)
    {
        // Hold cannot be fired from Unholding -> Do nothing except maybe giving a warning
    }


    public override void unhold(Isa88StateMachine stateMachine)
    {
        // Unhold cannot be fired from Unholding -> Do nothing except maybe giving a warning
    }


    public override void suspend(Isa88StateMachine stateMachine)
    {
        // Start cannot be fired from Unholding -> Do nothing except maybe giving a warning
    }


    public override void unsuspend(Isa88StateMachine stateMachine)
    {
        // Unsuspend cannot be fired from Unholding -> Do nothing except maybe giving a warning
    }


    public override void reset(Isa88StateMachine stateMachine)
    {
        // Reset cannot be fired from Unholding -> Do nothing except maybe giving a warning
    }


    public override void clear(Isa88StateMachine stateMachine)
    {
        // Clear cannot be fired from Unholding -> Do nothing except maybe giving a warning
    }


    public override async Task executeActionAndCompleteAsync(Isa88StateMachine stateMachine, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Logger.LogDebug("Cancellation requested in {StateName} state.", nameof(this.GetType));
            return; // Exit if cancellation is requested
        }

        IStateAction actionToRun = stateMachine.getStateActionManager().getAction(ActiveStateName.Unholding);
        base.executeAction(actionToRun);

        // Make sure the current state is still Unholding before going to Execute (could have been changed in the mean time).
        if (stateMachine.getState() is UnholdingState) {
            await stateMachine.setStateAndRunActionAsync(new ExecuteState());
        }
    }

}