using PackML_StateMachine.States;

namespace PackML_StateMachine.StateMachine;
public class StateActionManager
{

    IStateAction actionInStarting = new NullStateAction();
    IStateAction actionInExecute = new NullStateAction();
    IStateAction actionInCompleting = new NullStateAction();
    IStateAction actionInSuspending = new NullStateAction();
    IStateAction actionInUnsuspending = new NullStateAction();
    IStateAction actionInHolding = new NullStateAction();
    IStateAction actionInUnholding = new NullStateAction();
    IStateAction actionInResetting = new NullStateAction();
    IStateAction actionInStopping = new NullStateAction();
    IStateAction actionInAborting = new NullStateAction();
    IStateAction actionInClearing = new NullStateAction();


    public IStateAction getAction(ActiveStateName stateName)
    {
        switch (stateName)
        {
            case ActiveStateName.Starting:
                return this.actionInStarting;
            case ActiveStateName.Execute:
                return this.actionInExecute;
            case ActiveStateName.Completing:
                return this.actionInCompleting;
            case ActiveStateName.Holding:
                return this.actionInHolding;
            case ActiveStateName.Unholding:
                return this.actionInUnholding;
            case ActiveStateName.Suspending:
                return this.actionInSuspending;
            case ActiveStateName.Unsuspending:
                return this.actionInUnsuspending;
            case ActiveStateName.Stopping:
                return this.actionInStopping;
            case ActiveStateName.Clearing:
                return this.actionInClearing;
            case ActiveStateName.Aborting:
                return this.actionInAborting;
            case ActiveStateName.Resetting:
                return this.actionInResetting;
            default:
                return null;
        }
    }


    public void setAction(IStateAction action, ActiveStateName stateName)
    {
        switch (stateName)
        {
            case ActiveStateName.Starting:
                this.actionInStarting = action;
                break;
            case ActiveStateName.Execute:
                this.actionInExecute = action;
                break;
            case ActiveStateName.Completing:
                this.actionInCompleting = action;
                break;
            case ActiveStateName.Holding:
                this.actionInHolding = action;
                break;
            case ActiveStateName.Unholding:
                this.actionInUnholding = action;
                break;
            case ActiveStateName.Suspending:
                this.actionInSuspending = action;
                break;
            case ActiveStateName.Unsuspending:
                this.actionInUnsuspending = action;
                break;
            case ActiveStateName.Stopping:
                this.actionInStopping = action;
                break;
            case ActiveStateName.Clearing:
                this.actionInClearing = action;
                break;
            case ActiveStateName.Aborting:
                this.actionInAborting = action;
                break;
            case ActiveStateName.Resetting:
                this.actionInResetting = action;
                break;
            default:
                break;
        }
    }

}