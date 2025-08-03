using PackML_StateMachine.States;

namespace PackML_StateMachine.Tests.transitioning;
public class DummyAction : IStateAction
{
    readonly int dummyActionTime;

    public DummyAction(int dummyActionTime)
    {
        this.dummyActionTime = dummyActionTime;
    }

    public void execute()
    {
        try
        {
            Thread.Sleep(dummyActionTime);
        }
        catch (ThreadInterruptedException)
        {
            Console.WriteLine("Thread interrupted");
        }
    }
}
 