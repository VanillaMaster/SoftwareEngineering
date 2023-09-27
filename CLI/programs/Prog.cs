
/// <summary>
/// registrable cli handler
/// </summary>
public interface Prog {
    /// <summary>
    /// entrypoint into handler
    /// </summary>
    /// <param name="io">generic IO instanc, depends on cli</param>
    /// <param name="self">owner</param>
    /// <param name="args">extra data passed on init call</param>
    /// <returns>promise, resolved on "done"</returns>
    Task run(IO io, CLI self, string[] args);
}
