
/// <summary>
/// generic IO instance
/// </summary>
public interface IO {
    /// <summary>
    /// write line to this IO instance
    /// </summary>
    /// <param name="msg">text to write</param>
    void WriteLine(string msg);

    /// <summary>
    /// read line from this IO instance
    /// </summary>
    /// <param name="msg">optional message shown before reading</param>
    /// <returns> promise of readed line</returns>
    Task<string> ReadLine(string? msg = null);
}
