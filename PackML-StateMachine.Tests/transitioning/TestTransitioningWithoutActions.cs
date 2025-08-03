using PackML_StateMachine.StateMachine;
using PackML_StateMachine.States.Implementation;

namespace PackML_StateMachine.Tests.transitioning;

/**
* Simple test class that contains tests to check whether immediate inputs interrupt the state machine
*/

public class TestTransitioningWithoutActions
{
    [Fact]
    public async Task testOtherInitialState()
    {
        var stateMachine = new StateMachineBuilder().build();
        stateMachine.start();
        stateMachine.abort();

        // Wait to be safe, otherwise there is a race condition between state changes and assertion 
        await Task.Delay(500);

        Assert.True(stateMachine.getState() is AbortedState,
            $"State Machine should directly abort after starting and switch to AbortedState. Current state is {stateMachine.getState()}");
    }
}