
public class TestIO : IO
{
    private Queue<TaskCompletionSource<string>> Iqueue = new();
    private Queue<TaskCompletionSource<string>> Oqueue = new();

    public Task<string> ReadLine(string? msg = null) {
        var promise = new TaskCompletionSource<string>();
        this.Iqueue.Enqueue(promise);
        return promise.Task;
    }

    public void WriteLine(string msg)
    {
        var promise = this.Oqueue.Dequeue();
        if (promise != null) {
            promise.TrySetResult(msg);
        }
    }

    public Task<string> NextLine() {
        var promise = new TaskCompletionSource<string>();
        this.Oqueue.Enqueue(promise);
        return promise.Task;
    }

    public void PushLine(string msg) {
        var promise = this.Iqueue.Dequeue();
        if (promise != null) {
            promise.TrySetResult(msg);
        }
    }
}