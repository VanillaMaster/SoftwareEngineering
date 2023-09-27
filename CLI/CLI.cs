
/// <summary>
/// cli instance
/// </summary>
public class CLI {

    /// <summary>
    /// create new instance
    /// </summary>
    /// <param name="io">io to work with</param>
    public CLI(IO io) {
        this.io = io;
    }

    private readonly IO io;
    public bool active { get; private set; } = false;
    private Task? loop = null;
    private Dictionary<string, Prog> entries = new ();

    /// <summary>
    /// get promise resolved on "done"
    /// </summary>
    /// <returns>promise</returns>
    /// <exception cref="Exception"></exception>
    public Task working() {
        if (this.loop != null) return this.loop;
        throw new Exception();
    }

    /// <summary>
    /// start session
    /// </summary>
    /// <returns>self</returns>
    public CLI start() {
        if (!this.active) {
            this.active = true;
            this.loop = this.Loop();
        }
        return this;
    }
    /// <summary>
    /// stop session
    /// </summary>
    /// <returns>self</returns>
    public CLI stop() {
        this.active = false;
        return this;
    }

    /// <summary>
    /// register new handler
    /// </summary>
    /// <param name="key">run command</param>
    /// <param name="entry">handler</param>
    public void register(string key, Prog entry) {
        this.entries[key] = entry;
    }

    private async Task Loop() {
        while (this.active) {
            string? data = null;
            while (data == null) try {
                data = await this.io.ReadLine();
            } catch { };

            var input = data.Split(' ');
            var name = input[0];
            
            if (this.entries.TryGetValue(name, out var entry)) {
                await entry.run(this.io, this, input.Skip(1).ToArray());
            } else {
                this.io.WriteLine($"unknown command '{data}'");
            }

        }
    } 


}
