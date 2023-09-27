
/// <summary>
/// io bound to console
/// </summary>
public class ConsoleIO: IO {

    /// <summary>
    /// asynchronously read line from console
    /// </summary>
    /// <param name="msg"></param>
    /// <returns>promise of reded line</returns>
    /// <exception cref="IOException">invalid user input</exception>
    public async Task<string> ReadLine(string? msg = null)
    {
        if (msg != null) {
            Console.WriteLine(msg);
        }

        var input = await Task.Run(() => Console.ReadLine());

        if (input != null) {
            return input;
        }

        throw new IOException("user input err");
    }

    /// <summary>
    /// just write to console
    /// </summary>
    /// <param name="msg">text to write</param>
    public void WriteLine(string msg) { Console.WriteLine(msg); }

}
