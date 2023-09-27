namespace CLI_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task CLIUnknownCommandTest() {
            var input = "/test";
            var expected = $"unknown command '{input}'";
            
            var io = new TestIO();
            var cli = new CLI(io);
            cli.start();
            
            var outPromise = io.NextLine();
            io.PushLine(input);
            var o = await outPromise;
            Assert.AreEqual(expected, o);
            
        }

        [TestMethod]
        public async Task CLIQuitTest() {

            var io = new TestIO();
            var cli = new CLI(io);
            cli.register("/quit", new ProgQuit());
            cli.start();

            io.PushLine("/quit");
            await cli.working();
            Assert.AreEqual(cli.active, false);

        }


        [TestMethod]
        public async Task CLIHelpTest()
        {

            var io = new TestIO();
            var cli = new CLI(io);
            cli.register("/help", new ProgHelp());
            cli.start();

            var outPromise = io.NextLine();
            io.PushLine("/help");
            var o = await outPromise;

            Assert.AreEqual("no help allowd here", o);
        }

        [TestMethod]
        public async Task CLIBMITest()
        {

            var io = new TestIO();
            var cli = new CLI(io);
            cli.register("/bmi", new ProgBMI());
            cli.start();

            var outPromise = io.NextLine();
            io.PushLine("/bmi");
            io.PushLine("80");
            io.PushLine("200");
            var o = await outPromise;

            Assert.AreEqual("bmi: 20, Normal body weight", o);
        }
    }
}