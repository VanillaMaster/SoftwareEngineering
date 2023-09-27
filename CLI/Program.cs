using System;
using System.Threading;
using System.Threading.Tasks;


var cli = new CLI(new ConsoleIO());
cli.register("/quit", new ProgQuit());
cli.register("/help", new ProgHelp());
cli.register("/bmi", new ProgBMI());


await cli.start().working();
