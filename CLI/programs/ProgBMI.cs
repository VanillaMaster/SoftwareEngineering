
/// <summary>
/// handler, taht allow calculate bmi
/// </summary>
public class ProgBMI : Prog {

    private readonly static Dictionary<double, string> BmiDescriptions = new Dictionary<double, string>()
    {
        { 16, "Severe underweight" },
        { 18.5f, "Insufficient (deficit) body weight" },
        { 25, "Normal body weight" },
        { 30, "Overweight (preobesity)" },
        { 40, "Obesity" },
        { Double.MaxValue, "Obesity" }
    };

    private string GetDescription(double bmi) {
        var i = ProgBMI.BmiDescriptions.Keys.OrderBy(key => key).FirstOrDefault(key => key >= bmi);
        return ProgBMI.BmiDescriptions[i];
    }

    /// <summary>
    /// entrypoint into handler
    /// </summary>
    /// <param name="io">generic IO instanc, depends on cli</param>
    /// <param name="self">owner</param>
    /// <param name="args">extra data passed on init call</param>
    /// <returns>promise, resolved on "done"</returns>
    public async Task run(IO io, CLI self, string[] args) {
        uint? weight = null;
        while (weight == null) try { 
            weight = this.ParseWeight(await io.ReadLine("enter ur weight (kg)"));
        } catch {
            Console.WriteLine("fk u (weight)");                
        }

        uint? height = null;
        while (height == null) try {
            height = this.ParseHeight(await io.ReadLine("enter ur height (cm)"));
        } catch {
            Console.WriteLine("fk u (height)");                
        }

        var bmi = this.calc((uint)weight, (uint)height);
        var description = this.GetDescription(bmi);
        io.WriteLine($"bmi: {bmi}, {description}");
    }

    private double calc(uint weight, uint height) {
        return (double)weight / Math.Pow((double)height / 100, 2);
    }

    private uint? ParseWeight(string data) {
        if (UInt32.TryParse(data, out var weight)) {
            return weight;
        }
        return null;
    }

    private uint? ParseHeight(string data) {
        if (UInt32.TryParse(data, out var weight)) {
            //validate something, idk...
            return weight;
        }
        return null;
    }


}