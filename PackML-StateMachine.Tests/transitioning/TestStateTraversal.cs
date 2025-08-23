using PackML_StateMachine.StateMachine;
using PackML_StateMachine.States;
using PackML_StateMachine.States.Implementation;

namespace PackML_StateMachine.Tests.transitioning;
public class TestStateTraversal
{
    private static readonly int dummyActionTime = 3000;
    private IStateAction dummyAction = new DummyAction(dummyActionTime);

    // Set up an observer that collects all states that have been reached
    class ExampleObserver : IStateChangeObserver
    {
        List<String> stateList = [];

        public void onStateChanged(IState newState)
        {
            var observedStateName = newState.GetType().Name;
            stateList.Add(observedStateName + "_" + Environment.CurrentManagedThreadId);
        }

        public List<String> getStateList()
        {
            return this.stateList;
        }
    };

    [Fact]
    public void TestAbortingWhileStarting()
    {
        // Setup in Execute State
        var stateMachine = new StateMachineBuilder()
            .withInitialState(new IdleState())
            .withActionInStarting(dummyAction)
            .withActionInExecute(dummyAction)
            .withActionInCompleting(dummyAction)
            .build();

        var observer = new ExampleObserver();
        stateMachine.addStateChangeObserver(observer);

        // start and wait for execute
        stateMachine.start();
        waitForDummyActionToBeCompleted(1);

        stateMachine.abort();
        waitForDummyActionToBeCompleted(1); // Wait for aborting

        int numberOfStatesTraversed = observer.getStateList().Count;
        Assert.True(4==numberOfStatesTraversed, 
            $"State machine should only traverse through 4 States: Starting, Execute, Aborting, Aborted. States traversed: {string.Join(", ", observer.getStateList())}");
    }

    private void waitForDummyActionToBeCompleted(int numberOfActionsToAwait)
    {
        try
        {
            Thread.Sleep((int)(numberOfActionsToAwait * dummyActionTime + 0.2 * dummyActionTime));
        }
        catch (ThreadInterruptedException e)
        {
            Console.WriteLine($"{e.Message}\n{e.StackTrace}");
        }
    }
}
