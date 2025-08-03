﻿using PackML_StateMachine.States;

namespace PackML_StateMachine.StateMachine;

public class Isa88StateMachine
{
    private State currentState;
    private StateActionManager stateActionManager = new StateActionManager();
    private List<IStateChangeObserver> stateChangeObservers = new ();
    private CancellationTokenSource? runningActionCancellation;
    private Task? runningAction;

    /**
	 * Instantiates a new {@link Isa88StateMachine} with the a given initial state
	 * 
	 * @param initialState State that the state machine is in upon starting
	 */
    public Isa88StateMachine(State initialState)
    {
        this.currentState = initialState;
    }

    /**
     * Invokes a transition on the state machine.
     * 
     * @param transitionName Name of the transition that shall be invoked.
     */
    public void invokeTransition(TransitionName transitionName)
    {
        switch (transitionName)
        {
            case TransitionName.start:
                this.currentState.start(this);
                break;
            case TransitionName.hold:
                this.currentState.hold(this);
                break;
            case TransitionName.unhold:
                this.currentState.unhold(this);
                break;
            case TransitionName.suspend:
                this.currentState.suspend(this);
                break;
            case TransitionName.unsuspend:
                this.currentState.unsuspend(this);
                break;
            case TransitionName.reset:
                this.currentState.reset(this);
                break;
            case TransitionName.stop:
                this.currentState.stop(this);
                break;
            case TransitionName.abort:
                this.currentState.abort(this);
                break;
            case TransitionName.clear:
                this.currentState.clear(this);
                break;
            default:
                break;
        }
    }

    /**
	 * Execute a start command. Can be used to transition from Idle to Execute. Alias for invokeTransition(TransitionName.start).
	 */
    public void start()
    {
        this.currentState.start(this);
    }

    /**
	 * Execute a hold command. Can be used to transition from Execute to Held. Alias for invokeTransition(TransitionName.hold).
	 */
    public void hold()
    {
        this.currentState.hold(this);
    }

    /**
	 * Execute an unhold command. Can be used to transition from Held back to Execute. Alias for invokeTransition(TransitionName.unhold).
	 */
    public void unhold()
    {
        this.currentState.unhold(this);
    }

    /**
	 * Execute a suspend command. Can be used to transition Execute to Suspend. Alias for invokeTransition(TransitionName.suspend).
	 */
    public void suspend()
    {
        this.currentState.suspend(this);
    }

    /**
	 * Execute an unsuspend command. Can be used to transition from Suspended back to Execute. Alias for invokeTransition(TransitionName.unsuspend).
	 */
    public void unsuspend()
    {
        this.currentState.unsuspend(this);
    }

    /**
	 * Execute a reset command. Can be used to transition from Complete or Stopped back to Idle. Alias for invokeTransition(TransitionName.reset).
	 */
    public void reset()
    {
        this.currentState.reset(this);
    }

    /**
	 * Execute a stop command. Can be used to transition from all 'normal' states to Stopped. Alias for invokeTransition(TransitionName.stop).
	 */
    public void stop()
    {
        this.currentState.stop(this);
    }

    /**
	 * Execute an abort command. Can be used to transition from all 'normal' and 'stopping'-states to Aborted. Alias for
	 * invokeTransition(TransitionName.abort).
	 */
    public void abort()
    {
        this.currentState.abort(this);
    }

    /**
	 * Execute a clear command. Can be used to transition from Aborted to Stopped. Alias for invokeTransition(TransitionName.clear).
	 */
    public void clear()
    {
        this.currentState.clear(this);
    }

    /**
	 * Returns the current state of this state machine.
	 * 
	 * @return The current state instance
	 */
    public State getState()
    {
        return this.currentState;
    }

    /**
	 * Sets the current state of the StateMachine.
	 * 
	 * @param state The new state that will be set as the current state
	 */
    public void setState(State state)
    {
        this.currentState = state;
    }

    /**
     * Sets the current state of the StateMachine and runs this state's action.
     * 
     * @param state The new state that will be set as the current state
     */
    public async Task setStateAndRunActionAsync(State state)
    {
        // Cancel the current action if there is one
        if (runningActionCancellation != null)
        {
            await runningActionCancellation.CancelAsync();
            runningActionCancellation.Dispose();
        }

        // Wait for the previous action to complete if it's still running
        if (runningAction != null && !runningAction.IsCompleted)
        {
            try
            {
                await runningAction;
            }
            catch (OperationCanceledException)
            {
                // Expected when cancellation occurs
            }
        }

        // Set the new state and notify all observers
        this.currentState = state;
        foreach (var observer in stateChangeObservers)
        {
            observer.onStateChanged(this.currentState);
        }

        // Create new cancellation token for the new action
        runningActionCancellation = new CancellationTokenSource();

        // Execute the action of the new state on a background task
        this.runningAction = Task.Run(async () =>
        {
            try
            {
                await this.currentState.executeActionAndCompleteAsync(this, runningActionCancellation.Token);
            }
            catch (OperationCanceledException)
            {
                // Expected when cancellation occurs
            }
        }, runningActionCancellation.Token);
    }

    /**
     * Synchronous version of setStateAndRunAction for backward compatibility
     */
    public void setStateAndRunAction(State state)
    {
        _ = Task.Run(async () => await setStateAndRunActionAsync(state));
    }

    /**
     * Returns the {@link StateActionManager} of this state machine.
     * 
     * @return This state machine's state manager instance
     */
    public StateActionManager getStateActionManager()
    {
        return this.stateActionManager;
    }

    /**
     * Adds a new {@link IStateChangeObserver} instance to the list of observers.
     * 
     * @param observer The new observer to add.
     */
    public void addStateChangeObserver(IStateChangeObserver observer)
    {
        this.stateChangeObservers.Add(observer);
    }

    /**
	 * Removes a given {@link IStateChangeObserver} instance from the list of observers.
	 * 
	 * @param observer The observer that is going to be removed.
	 */
    public void removeStateChangeObserver(IStateChangeObserver observer)
    {
        this.stateChangeObservers.Remove(observer);
    }

}
