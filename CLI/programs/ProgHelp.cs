/// <summary>
/// handler, that display "help" information
/// </summary>
public class ProgHelp : Prog
{
    /// <summary>
    /// entrypoint into handler
    /// </summary>
    /// <param name="io">generic io instanc, depends on cli</param>
    /// <param name="self">owner</param>
    /// <param name="args">extra data passed on init call</param>
    /// <returns>promise, resolved on "done"</returns>
    public async Task run(IO io, CLI self, string[] args)
    {
        io.WriteLine("no help allowd here");
    }
}