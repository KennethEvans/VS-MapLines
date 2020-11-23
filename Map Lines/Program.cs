using System.Threading;
using System.Windows.Forms;
using MapLines;

var thread = new Thread(() => {
    Application.SetHighDpiMode(HighDpiMode.SystemAware);
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new MainForm());
});
thread.SetApartmentState(ApartmentState.STA);
thread.Start();