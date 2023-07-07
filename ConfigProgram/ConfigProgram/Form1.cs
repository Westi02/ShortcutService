using Microsoft.Win32;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace ConfigProgram
{
    public partial class Form1 : Form
    {

        ShortcutModel shortcuts;
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\shortcut_config.json";
        string serviceName = "shortcutservice";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            var shortcutList = new List<string>();
            loadShortcutsFromFile();
            populateComboBox();

            if(IsUserAdministrator())
            {
                cb_Autostart.Enabled = true;
            }
            else
            {
                cb_Autostart.Enabled = false;
            }

            if(checkIfAutostartExists())
            {
                cb_Autostart.Checked = true;
            }
            else
            {
                cb_Autostart.Checked = false;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            bool canSave = true;

            foreach (var shortcut in shortcuts.Shortcuts)
            {
                if (tb_name.Text == shortcut.Name && tb_name.Text != comboBox1.SelectedItem.ToString())
                {
                    canSave = false;
                    MessageBox.Show("You already have a Shortcut with this name", "ERROR", MessageBoxButtons.OK);
                }
            }

            if (canSave)
            {
                foreach (var shortcut in shortcuts.Shortcuts)
                {
                    if (shortcut.Name == comboBox1.SelectedItem.ToString())
                    {
                        shortcut.Name = tb_name.Text;
                        shortcut.ShortcutString = tb_shortcut.Text;
                        shortcut.ProgramPath = tb_program.Text;
                    }
                }

                saveShortcutsToFile();
                loadShortcutsFromFile();
                populateComboBox();
                Process[] processes = Process.GetProcessesByName(serviceName);
                foreach (var process in processes)
                {
                    process.Kill();
                }
                Process.Start(serviceName + ".exe");
            }

        }

        private void btn_newShortcut_Click(object sender, EventArgs e)
        {
            Shortcut newShortcut = new Shortcut();
            newShortcut.Name = " ";
            newShortcut.ProgramPath = " ";
            newShortcut.ShortcutString = " ";

            bool canCreateNew = true;

            foreach (var shortcut in shortcuts.Shortcuts)
            {
                if (shortcut.Name == newShortcut.Name)
                {
                    canCreateNew = false;
                    MessageBox.Show("You already have a Shortcut with this name", "ERROR", MessageBoxButtons.OK);
                }
            }

            if (canCreateNew)
            {
                shortcuts.Shortcuts.Add(newShortcut);

                populateComboBox();

                foreach (var item in comboBox1.Items)
                {
                    if (item.ToString() == newShortcut.Name)
                    {
                        comboBox1.SelectedItem = item;
                    }
                }
            }

        }

        private void btn_shortcut_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Enabled = true;
            form2.ShowDialog();

            var cb_ctrl = (CheckBox)form2.Controls.Find("cb_Strg", true)[0];
            var cb_alt = (CheckBox)form2.Controls.Find("cb_alt", true)[0];
            var tb_char = (TextBox)form2.Controls.Find("tb_char", true)[0];


            if (form2.Enabled == false)
            {
                string shortcutString = "";
                if (cb_ctrl.Checked)
                {
                    shortcutString = $"{shortcutString}Ctrl+";
                }

                if (cb_alt.Checked)
                {
                    shortcutString = $"{shortcutString}Alt+";
                }

                shortcutString = $"{shortcutString}{tb_char.Text}";

                tb_shortcut.Text = shortcutString;
            }

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "exe files (*.exe)|*.exe|link files (*.lnk)|*.lnk|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var programPath = openFileDialog.FileName;
                    tb_program.Text = programPath;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var shortcut in shortcuts.Shortcuts)
            {
                if (shortcut.Name == comboBox1.SelectedItem.ToString())
                {
                    tb_name.Text = shortcut.Name;
                    tb_shortcut.Text = shortcut.ShortcutString;
                    tb_program.Text = shortcut.ProgramPath;
                }
            }
        }

        private void cb_Autostart_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUserAdministrator())
            {
                if (cb_Autostart.Checked)
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    rk.SetValue("ShortcutService", Directory.GetCurrentDirectory() + "\\" + serviceName + ".exe");
                }
                else
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    rk.DeleteValue("ShortcutService");
                }
            }               
        }

        private void loadShortcutsFromFile()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                shortcuts = JsonConvert.DeserializeObject<ShortcutModel>(jsonString);
            }
            else
            {
                using (var writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("{\"Shortcuts\":[{ \"Name\":\"Test Shortcut\",\"ShortcutString\":\"\",\"ProgramPath\":\"\"}]}");
                    writer.Close();
                }

                string jsonString = File.ReadAllText(filePath);
                shortcuts = JsonConvert.DeserializeObject<ShortcutModel>(jsonString);
            }

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

        public bool IsUserAdministrator()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            return isAdmin;
        }

        public static bool checkIfAutostartExists()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            return (key.GetValueNames().Contains("ShortcutService"));
        }
    }
}