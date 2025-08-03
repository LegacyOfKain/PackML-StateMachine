using PackML_StateMachine.StateMachine;
using PackML_StateMachine.States.Implementation;

namespace PackML_StateMachine.Tests.transitioning;

/**
* Simple test class that contains tests to check whether immediate inputs interrupt the state machine
*/

public class TestTransitioningWithoutActions
{
    static Isa88StateMachine stateMachine;

    public TestTransitioningWithoutActions()
    {
        testSimpleSetup();
    }

    public static void testSimpleSetup()
    {
        stateMachine = new StateMachineBuilder().build();
    }

    [Fact]
    public async Task testOtherInitialState()
    {
        stateMachine.start();
        stateMachine.abort();

        // Wait to be safe, otherwise there is a race condition between state changes and assertion 
        await Task.Delay(500);

        Assert.True(stateMachine.getState() is AbortedState,
            $"State Machine should directly abort after starting and switch to AbortedState. Current state is {stateMachine.getState()}");
    }
}