using Newtonsoft.Json;

namespace ConfigProgram
{
    public partial class Form1 : Form
    {

        ShortcutModel shortcuts;
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\shortcut_config.json";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            var shortcutList = new List<string>();
            loadShortcutsFromFile();
            populateComboBox();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            foreach (var shortcut in shortcuts.Shortcuts)
            {
                if (shortcut.Name == comboBox1.SelectedItem.ToString())
                {
                    shortcut.Name = tb_name.Text;
                    shortcut.ShortcutString = tb_shortcut.Text;
                }
            }

            saveShortcutsToFile();
            loadShortcutsFromFile();
            populateComboBox();
        }

        private void btn_shortcut_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var shortcut in shortcuts.Shortcuts)
            {
                if (shortcut.Name == comboBox1.SelectedItem.ToString())
                {
                    tb_name.Text = shortcut.Name;
                    tb_shortcut.Text = shortcut.ShortcutString;
                }
            }
        }

        private void loadShortcutsFromFile()
        {
            string jsonString = File.ReadAllText(filePath);
            shortcuts = JsonConvert.DeserializeObject<ShortcutModel>(jsonString);
        }

        private void saveShortcutsToFile()
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(shortcuts));
        }

        private void populateComboBox()
        {
            var shortcutList = new List<string>();
            foreach (var shortcut in shortcuts.Shortcuts)
            {
                shortcutList.Add($"{shortcut.Name}");
            }

            this.comboBox1.DataSource = shortcutList;
        }
    }
}