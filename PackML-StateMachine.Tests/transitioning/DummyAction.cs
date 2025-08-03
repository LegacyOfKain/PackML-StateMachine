using PackML_StateMachine.States;

namespace PackML_StateMachine.Tests.transitioning;
public class DummyAction : IStateAction
{
    int dummyActionTime;

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
        catch (ThreadInterruptedException e)
        {
            Console.WriteLine("Thread interrupted");
        }
    }
}
 