
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

            await Task.Delay(TimeSpan.FromSeconds(2.5));

            // Select exampleB programmatically
            comboBox.SelectedIndex = 1;
            await Task.Delay(TimeSpan.FromSeconds(2.5));

            // Select exampleC programmatically
            comboBox.SelectedItem = exampleC;
        }
    }
    class Example
    {
        public Example() => _genID++;

        private static char _genID = 'A';
        public string Name { get; set; } = $"Example{_genID}";
        public object A { get; set; } = $"Object-A-{_genID}";
        public string B { get; set; } = $"Object-B-{_genID}";

    }
}
