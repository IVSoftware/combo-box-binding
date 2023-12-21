
namespace combo_box_binding
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Example 
                exampleA = new Example(),
                exampleB = new Example(), 
                exampleC = new Example();

            var examples = new List<Example> 
            {
                exampleA,
                exampleB,
                exampleC,
            };

            comboBox.DataSource = examples;
            comboBox.DisplayMember = "Name";

            await localCycleWaitCursor();

            // Select exampleB programmatically from index
            comboBox.SelectedIndex = 1;

            await localCycleWaitCursor();

            // Select exampleC programmatically from Example object
            comboBox.SelectedItem = exampleC;


            async Task localCycleWaitCursor()
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                Cursor.Position = PointToScreen(new Point(20, 30));
                Cursor = Cursors.WaitCursor;
                await Task.Delay(TimeSpan.FromSeconds(1));
                Cursor = Cursors.Default;
            }
        }
    }
    class Example
    {
        public Example() => _genID++;

        private static char _genID = 'A';
        public string Name { get; set; } = $"Example {_genID}";
        public object A { get; set; } = $"Object-A-{_genID}";
        public string B { get; set; } = $"Object-B-{_genID}";
        public override string ToString() => Name;
    }
}
