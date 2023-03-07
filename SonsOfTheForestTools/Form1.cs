using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace SonsOfTheForestTools
{
    public partial class Form1 : Form
    {

        public bool loadMultiplayer = false;

        public Form1()
        {
            InitializeComponent();
        }


        private string[] getSaveFolders(bool Multiplayer = false)
        {
            string localLow = Path.GetFullPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "..", "LocalLow"));
            string setttingsPath = localLow + @"\Endnight\SonsOfTheForest";
            string savePath = setttingsPath + @"\Saves";
            string prpfileDirectory = "";

            string[] subDirs = Directory.GetDirectories(savePath);

            if (subDirs.Length > 0)
            {
                prpfileDirectory = subDirs[0];
                string modeFolder = "";
                if (Multiplayer == true)
                {
                    modeFolder = Path.GetFullPath(prpfileDirectory + @"\Multiplayer");

                }
                else
                {
                    modeFolder = Path.GetFullPath(prpfileDirectory + @"\SinglePlayer");
                }
                string[] saveDirs = Directory.GetDirectories(modeFolder);
                return saveDirs;
            }
            return new string[0];
        }

        // GameStateSaveData.json
        // SaveData.json

        private int getGameDays(string s)
        {

            // define the regular expression pattern for SaveGame Time
            string pattern = @"\\\""GameDays\\\"":(\d+),";

            // create the Regex object
            Regex regex = new Regex(pattern);

            // match the pattern in the text
            Match match = regex.Match(s);

            string val = "";
            if (match.Success)
            {
                val = match.Groups[1].Value;
            }

            int result;
            if (int.TryParse(val, out result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        private int getGameHours(string s)
        {

            // define the regular expression pattern for SaveGame Time
            string pattern = @"\\\""GameHours\\\"":(\d+),";

            // create the Regex object
            Regex regex = new Regex(pattern);

            // match the pattern in the text
            Match match = regex.Match(s);

            string val = "";
            if (match.Success)
            {
                val = match.Groups[1].Value;
            }

            int result;
            if (int.TryParse(val, out result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        private int getGameMinutes(string s)
        {

            // define the regular expression pattern for SaveGame Time
            string pattern = @"\\\""GameMinutes\\\"":(\d+),";

            // create the Regex object
            Regex regex = new Regex(pattern);

            // match the pattern in the text
            Match match = regex.Match(s);

            string val = "";
            if (match.Success)
            {
                val = match.Groups[1].Value;
            }

            int result;
            if (int.TryParse(val, out result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        private int getGameSeconds(string s)
        {

            // define the regular expression pattern for SaveGame Time
            string pattern = @"\\\""GameSeconds\\\"":(\d+),";

            // create the Regex object
            Regex regex = new Regex(pattern);

            // match the pattern in the text
            Match match = regex.Match(s);

            string val = "";
            if (match.Success)
            {
                val = match.Groups[1].Value;
            }

            int result;
            if (int.TryParse(val, out result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        private int getGameMilliseconds(string s)
        {

            // define the regular expression pattern for SaveGame Time
            string pattern = @"\\\""GameMilliseconds\\\"":(\d+),";

            // create the Regex object
            Regex regex = new Regex(pattern);

            // match the pattern in the text
            Match match = regex.Match(s);

            string val = "";
            if (match.Success)
            {
                val = match.Groups[1].Value;
            }

            int result;
            if (int.TryParse(val, out result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        private string getGameDifficulty(string s)
        {

            // define the regular expression pattern for SaveGame Time
            string pattern = @"\\""GameType\\"":\\""(\w+)\\""";

            // ",\"GameType\":\"Normal\",

            // create the Regex object
            Regex regex = new Regex(pattern);

            // match the pattern in the text
            Match match = regex.Match(s);

            string val = "";
            if (match.Success)
            {
                val = match.Groups[1].Value;
            }
            return val;
        }

        private bool? getIsRobbyDead(string s)
        {

            // define the regular expression pattern for SaveGame Time
            string pattern = @"\\\""IsRobbyDead\\\"":(true|false),";

            // create the Regex object
            Regex regex = new Regex(pattern);

            // match the pattern in the text
            Match match = regex.Match(s);

            string val = "";
            if (match.Success)
            {
                val = match.Groups[1].Value;
            }

            bool result;
            if (bool.TryParse(val, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        private bool? getIsVirginiaDead(string s)
        {

            // define the regular expression pattern for SaveGame Time
            string pattern = @"\\\""IsVirginiaDead\\\"":(\w+),";

            // create the Regex object
            Regex regex = new Regex(pattern);

            // match the pattern in the text
            Match match = regex.Match(s);

            string val = "";
            if (match.Success)
            {
                val = match.Groups[1].Value;
            }

            bool result;
            if (bool.TryParse(val, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        private (string, string, string) getTypePositions(string s, int TypeId)
        {

            // define the regular expression pattern to match x, y, and z values
            string pattern = @"\\""TypeId\\"":" + TypeId.ToString() + @",\\""FamilyId\\"":\d+,\\""Position\\"":\{\\""x\\"":(-?\d+(?:\.\d+)?),\\""y\\"":(-?\d+(?:\.\d+)?),\\""z\\"":(-?\d+(?:\.\d+)?)}";

            // create the Regex object
            Regex regex = new Regex(pattern);

            // match the pattern in the text
            Match match = regex.Match(s);

            string x = "", y = "", z = "";
            if (match.Success)
            {
                x = match.Groups[1].Value;
                y = match.Groups[2].Value;
                z = match.Groups[3].Value;

            }
            return (x, y, z);
        }

        private (string, string, string) getPlayerPosition(string s)
        {
            // define the regular expression patterns
            string pattern = @"\{\\""Name\\"":\\""player\.position\\"",.*,\\""FloatArrayValue\\"":\[(-?\d+(?:\.\d+)?),(-?\d+(?:\.\d+)?),(-?\d+(?:\.\d+)?)\],\\""IsSet\\"":\S+\}";

            // create the Regex object
            Regex regex = new Regex(pattern);

            // match the pattern in the text
            Match match = regex.Match(s);

            string x = "", y = "", z = "";
            if (match.Success)
            {
                x = match.Groups[1].Value;
                y = match.Groups[2].Value;
                z = match.Groups[3].Value;

            }
            return (x, y, z);
        }

        private string getIsKilledByPlayer(string s, int TypeId)
        {
            // define the regular expression pattern for SaveGame Time
            string pattern = @"\{\\""TypeId\\"":" + TypeId.ToString() + @",\\""PlayerKilled\\"":(\d+)\}";

            // create the Regex object
            Regex regex = new Regex(pattern);

            // match the pattern in the text
            Match match = regex.Match(s);

            string val = "";
            if (match.Success)
            {
                val = match.Groups[1].Value;
            }
            return val;
        }

        private void readSaveGame()
        {
            listView1.Items.Clear();

            // define the regular expression pattern for SaveGame Time
            string pattern = @"\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{7}\+\d{2}:\d{2}";

            // define the format of the input string
            string format = "yyyy-MM-dd'T'HH:mm:ss.fffffffzzz";

            string dateTimeString = "";

            string file = "";
            string fileContent = "";
            foreach (string saveGameFullPath in getSaveFolders(loadMultiplayer))
            {
                string saveGameFolder = new DirectoryInfo(saveGameFullPath).Name;
                // get the fileContent of the SaveFile
                file = saveGameFullPath + @"\GameStateSaveData.json";
                fileContent = File.ReadAllText(file);

                // create the Regex object
                Regex regex = new Regex(pattern);

                // match the pattern in the text
                Match match = regex.Match(fileContent);

                if (match.Success)
                {
                    dateTimeString = match.Value;
                }

                // parse the input string to a DateTime object
                DateTime dateTime = DateTime.ParseExact(dateTimeString, format, CultureInfo.InvariantCulture);

                // get the individual date and time values
                DateTime date = dateTime.Date;
                TimeSpan time = dateTime.TimeOfDay;

                string[] saLvwItem = new string[5];

                saLvwItem[0] = saveGameFolder;
                saLvwItem[1] = date.ToString("yyyy-MM-dd") + " - " + time.ToString(@"hh\:mm\:ss");
                saLvwItem[2] = getGameDifficulty(fileContent);
                saLvwItem[3] = getGameDays(fileContent).ToString();
                saLvwItem[4] = getGameHours(fileContent).ToString("D2") + ":" + getGameMinutes(fileContent).ToString("D2") + ":" + getGameSeconds(fileContent).ToString("D2");

                ListViewItem ListItem = new ListViewItem(saLvwItem);
                listView1.Items.Add(ListItem);
            }
        }

        private string setTypePositions(string s, int TypeId, string x, string y, string z)
        {
            // define the regular expression patterns
            string pattern = @"\\""TypeId\\"":" + TypeId.ToString() + @",\\""FamilyId\\"":\d+,\\""(Position\\"":\{\\""x\\"":(-?\d+(?:\.\d+)?),\\""y\\"":(-?\d+(?:\.\d+)?),\\""z\\"":(-?\d+(?:\.\d+)?)})";
            string pattern2 = @"\\""x\\"":(-?\d+(?:\.\d+)?),\\""y\\"":(-?\d+(?:\.\d+)?),\\""z\\"":(-?\d+(?:\.\d+)?)";
            string replacement = @"\""x\"":" + x.ToString() + @",\""y\"":" + y.ToString() + @",\""z\"":" + z.ToString();
            string sMatch = "";

            // create the Regex object
            Regex regex = new Regex(pattern);

            // match the pattern in the text
            Match match = regex.Match(s);

            if (match.Success)
            {
                sMatch = match.Groups[1].Value;
            }

            string output = Regex.Replace(sMatch, pattern2, replacement);
            return s.Replace(sMatch, output);
        }

        private string setIsRobbyDead(bool IsRobbyDead = false)
        {
            foreach (string saveGameFullPath in getSaveFolders(loadMultiplayer))
            {
                string saveGameFolder = new DirectoryInfo(saveGameFullPath).Name;
                if (saveGameFolder == listView1.SelectedItems[0].SubItems[0].Text)
                {
                    // Read "GameStateSaveData.json" content
                    string fGameStateSaveData = saveGameFullPath + @"\GameStateSaveData.json";
                    string cGameStateSaveData = File.ReadAllText(fGameStateSaveData);

                    string pattern = @",\\""IsRobbyDead\\"":(false|true),";
                    string replacement = @",\""IsRobbyDead\"":" + IsRobbyDead.ToString().ToLower() + @",";

                    string output = Regex.Replace(cGameStateSaveData, pattern, replacement);
                    return output;
                }
            }
            return "";
        }

        private string setIsVirginiaDead(bool IsVirginiaDead = false)
        {
            foreach (string saveGameFullPath in getSaveFolders(loadMultiplayer))
            {
                string saveGameFolder = new DirectoryInfo(saveGameFullPath).Name;
                if (saveGameFolder == listView1.SelectedItems[0].SubItems[0].Text)
                {
                    // Read "GameStateSaveData.json" content
                    string fGameStateSaveData = saveGameFullPath + @"\GameStateSaveData.json";
                    string cGameStateSaveData = File.ReadAllText(fGameStateSaveData);

                    string pattern = @",\\""IsVirginiaDead\\"":(false|true),";
                    string replacement = @",\""IsVirginiaDead\"":" + IsVirginiaDead.ToString().ToLower() + @",";

                    string output = Regex.Replace(cGameStateSaveData, pattern, replacement);
                    return output;
                }
            }
            return "";
        }

        private string setRobbyPlayerKilled(bool PlayerKilled = false)
        {
            foreach (string saveGameFullPath in getSaveFolders(loadMultiplayer))
            {
                string saveGameFolder = new DirectoryInfo(saveGameFullPath).Name;
                if (saveGameFolder == listView1.SelectedItems[0].SubItems[0].Text)
                {
                    // Read "SaveData.json" content
                    string fSaveData = saveGameFullPath + @"\SaveData.json";
                    string cSaveData = File.ReadAllText(fSaveData);

                    int iPlayerKilled = PlayerKilled ? 1 : 0;
                    string pattern = @",\{\\""TypeId\\"":9,\\""PlayerKilled\\"":\d+\},";
                    string replacement = @",{\""TypeId\"":9,\""PlayerKilled\"":" + iPlayerKilled.ToString() + @"},";

                    string output = Regex.Replace(cSaveData, pattern, replacement);
                    return output;
                }
            }
            return "";
        }

        private string setVirginiaPlayerKilled(bool PlayerKilled = false)
        {
            foreach (string saveGameFullPath in getSaveFolders(loadMultiplayer))
            {
                string saveGameFolder = new DirectoryInfo(saveGameFullPath).Name;
                if (saveGameFolder == listView1.SelectedItems[0].SubItems[0].Text)
                {
                    // Read "SaveData.json" content
                    string fSaveData = saveGameFullPath + @"\SaveData.json";
                    string cSaveData = File.ReadAllText(fSaveData);

                    int iPlayerKilled = PlayerKilled ? 1 : 0;
                    string pattern = @",\{\\""TypeId\\"":10,\\""PlayerKilled\\"":\d+\},";
                    string replacement = @",{\""TypeId\"":10,\""PlayerKilled\"":" + iPlayerKilled.ToString() + @"},";

                    string output = Regex.Replace(cSaveData, pattern, replacement);
                    return output;
                }
            }
            return "";
        }

        private void ReLoadNPCData()
        {
            if (listView1.Items.Count > 0 && listView1.SelectedItems.Count == 1)
            {
                listView2.Items.Clear();

                foreach (string saveGameFullPath in getSaveFolders(loadMultiplayer))
                {
                    string saveGameFolder = new DirectoryInfo(saveGameFullPath).Name;
                    if (saveGameFolder == listView1.SelectedItems[0].SubItems[0].Text)
                    {
                        // Read "GameStateSaveData.json" content
                        string cGameStateSaveData = File.ReadAllText(saveGameFullPath + @"\GameStateSaveData.json");

                        // Read "SaveData.json" content
                        string cSaveData = File.ReadAllText(saveGameFullPath + @"\SaveData.json");

                        // Read "PlayerStateSaveData.json" content
                        string cPlayerStateSaveData = File.ReadAllText(saveGameFullPath + @"\PlayerStateSaveData.json");

                        string player_x = "", player_y = "", player_z = "";
                        (player_x, player_y, player_z) = getPlayerPosition(cPlayerStateSaveData);

                        // Read Kelvin Position x, y and z
                        string kelvin_x = "", kelvin_y = "", kelvin_z = "";
                        (kelvin_x, kelvin_y, kelvin_z) = getTypePositions(cSaveData, 9);

                        // Read Virginia Position x, y and z
                        string virginia_x = "", virginia_y = "", virginia_z = "";
                        (virginia_x, virginia_y, virginia_z) = getTypePositions(cSaveData, 10);

                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.Text = "Kelvin";

                        string[] saLvwItem = new string[5];
                        saLvwItem[0] = getIsRobbyDead(cGameStateSaveData).ToString();
                        saLvwItem[1] = getIsKilledByPlayer(cSaveData, 9);
                        saLvwItem[2] = getTypePositions(cSaveData, 9).Item1;
                        saLvwItem[3] = getTypePositions(cSaveData, 9).Item2;
                        saLvwItem[4] = getTypePositions(cSaveData, 9).Item3;
                        foreach (string s in saLvwItem)
                        {
                            listViewItem.SubItems.Add(s);
                        }
                        listView2.Items.Add(listViewItem);

                        ListViewItem listViewItem2 = new ListViewItem();
                        listViewItem2.Text = "Virginia";

                        saLvwItem[0] = getIsVirginiaDead(cGameStateSaveData).ToString();
                        saLvwItem[1] = getIsKilledByPlayer(cSaveData, 10);
                        saLvwItem[2] = getTypePositions(cSaveData, 10).Item1;
                        saLvwItem[3] = getTypePositions(cSaveData, 10).Item2;
                        saLvwItem[4] = getTypePositions(cSaveData, 10).Item3;
                        foreach (string s in saLvwItem)
                        {
                            listViewItem2.SubItems.Add(s);
                        }
                        listView2.Items.Add(listViewItem2);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
            listView1.Items.Clear();
            listView2.Items.Clear();

            readSaveGame();
            sortListViewColumnOnStart(listView1, 1);
            
            radioButton1.Checked = true;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            loadMultiplayer = false;
            readSaveGame();
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            loadMultiplayer = true;
            readSaveGame();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Get the actual ListView control from the "object sender"
            System.Windows.Forms.ListView listView = (System.Windows.Forms.ListView)sender;
            if (listView.Items.Count > 0 && listView.SelectedItems.Count == 1)
            {
                ReLoadNPCData();

                listView.ContextMenuStrip = contextMenuStrip1;

                button_MoveToPlayer_Kelvin.Enabled = true;
                button_MoveToPlayer_Virginia.Enabled = true;
                button_MoveToKelvin_Virginia.Enabled = true;
                button_MoveToVirginia_Kelvin.Enabled = true;
                button_Revive_Kelvin.Enabled = true;
                button_Revive_Virginia.Enabled = true;
            }
            else
            {
                listView.ContextMenuStrip = null;

                button_MoveToPlayer_Kelvin.Enabled = false;
                button_MoveToPlayer_Virginia.Enabled = false;
                button_MoveToKelvin_Virginia.Enabled = false;
                button_MoveToVirginia_Kelvin.Enabled = false;
                button_Revive_Kelvin.Enabled = false;
                button_Revive_Virginia.Enabled = false;
            }
        }

        private void sortListViewColumnOnStart(System.Windows.Forms.ListView listView, int columnIndex)
        {
            // ignoreCase when sorting
            bool ignoreCase = true;

            // set SortOrder.Descending for "First Time"
            SortOrder sortOrder = SortOrder.Descending;

            // Set the tag property of the column header to the new sort order
            listView.Columns[columnIndex].Tag = sortOrder;

            // Set the ListViewItemSorter property to a new instance of the ListViewColumnSorter class
            listView.ListViewItemSorter = new ListViewColumnSorter(columnIndex, sortOrder, ignoreCase);

            // Call the Sort method to perform the sort
            listView.Sort();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the ListView control and the column clicked
            System.Windows.Forms.ListView listView = (System.Windows.Forms.ListView)sender;
            int columnIndex = e.Column;

            // ignoreCase when sorting
            bool ignoreCase = true;

            // Get the current sort order for the column clicked
            SortOrder sortOrder = listView.Columns[columnIndex].Tag == null ? SortOrder.Ascending :
                ((SortOrder)listView.Columns[columnIndex].Tag == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending);

            // Set the tag property of the column header to the new sort order
            listView.Columns[columnIndex].Tag = sortOrder;

            // Set the ListViewItemSorter property to a new instance of the ListViewColumnSorter class
            listView.ListViewItemSorter = new ListViewColumnSorter(columnIndex, sortOrder, ignoreCase);

            // Call the Sort method to perform the sort
            listView.Sort();
        }

        private void button_MoveToPlayer_Kelvin_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to move Kevlin to Player's Position?", "Move Kelvin to Player", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (string saveGameFullPath in getSaveFolders(loadMultiplayer))
                {
                    string saveGameFolder = new DirectoryInfo(saveGameFullPath).Name;
                    if (saveGameFolder == listView1.SelectedItems[0].SubItems[0].Text)
                    {
                        // Read "GameStateSaveData.json" content
                        string fGameStateSaveData = saveGameFullPath + @"\GameStateSaveData.json";
                        string cGameStateSaveData = File.ReadAllText(fGameStateSaveData);

                        // Read "SaveData.json" content
                        string fSaveData = saveGameFullPath + @"\SaveData.json";
                        string cSaveData = File.ReadAllText(fSaveData);

                        // Read "PlayerStateSaveData.json" content
                        string fPlayerStateSaveData = saveGameFullPath + @"\PlayerStateSaveData.json";
                        string cPlayerStateSaveData = File.ReadAllText(fPlayerStateSaveData);

                        // Read Player Position x, y and z
                        string player_x = "", player_y = "", player_z = "";
                        (player_x, player_y, player_z) = getPlayerPosition(cPlayerStateSaveData);

                        // Read Kelvin Position x, y and z
                        string kelvin_x = "", kelvin_y = "", kelvin_z = "";
                        (kelvin_x, kelvin_y, kelvin_z) = getTypePositions(cSaveData, 9);

                        // Read Virginia Position x, y and z
                        string virginia_x = "", virginia_y = "", virginia_z = "";
                        (virginia_x, virginia_y, virginia_z) = getTypePositions(cSaveData, 10);

                        string result = setTypePositions(cSaveData, 9, player_x, player_y, player_z);

                        File.WriteAllText(fSaveData, result);

                        ReLoadNPCData();
                    }
                }
            }
        }

        private void button_MoveToPlayer_Virginia_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to move Virginia to Player's Position?", "Move Virginia to Player", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (string saveGameFullPath in getSaveFolders(loadMultiplayer))
                {
                    string saveGameFolder = new DirectoryInfo(saveGameFullPath).Name;
                    if (saveGameFolder == listView1.SelectedItems[0].SubItems[0].Text)
                    {
                        // Read "GameStateSaveData.json" content
                        string fGameStateSaveData = saveGameFullPath + @"\GameStateSaveData.json";
                        string cGameStateSaveData = File.ReadAllText(fGameStateSaveData);

                        // Read "SaveData.json" content
                        string fSaveData = saveGameFullPath + @"\SaveData.json";
                        string cSaveData = File.ReadAllText(fSaveData);

                        // Read "PlayerStateSaveData.json" content
                        string fPlayerStateSaveData = saveGameFullPath + @"\PlayerStateSaveData.json";
                        string cPlayerStateSaveData = File.ReadAllText(fPlayerStateSaveData);

                        // Read Player Position x, y and z
                        string player_x = "", player_y = "", player_z = "";
                        (player_x, player_y, player_z) = getPlayerPosition(cPlayerStateSaveData);

                        // Read Kelvin Position x, y and z
                        string kelvin_x = "", kelvin_y = "", kelvin_z = "";
                        (kelvin_x, kelvin_y, kelvin_z) = getTypePositions(cSaveData, 9);

                        // Read Virginia Position x, y and z
                        string virginia_x = "", virginia_y = "", virginia_z = "";
                        (virginia_x, virginia_y, virginia_z) = getTypePositions(cSaveData, 10);

                        string result = setTypePositions(cSaveData, 10, player_x, player_y, player_z);

                        File.WriteAllText(fSaveData, result);

                        ReLoadNPCData();
                    }
                }
            }
        }

        private void button_MoveToKelvin_Virginia_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to move Virginia to Kelvin's Position?", "Move Virginia to Kelvin", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (string saveGameFullPath in getSaveFolders(loadMultiplayer))
                {
                    string saveGameFolder = new DirectoryInfo(saveGameFullPath).Name;
                    if (saveGameFolder == listView1.SelectedItems[0].SubItems[0].Text)
                    {
                        // Read "GameStateSaveData.json" content
                        string fGameStateSaveData = saveGameFullPath + @"\GameStateSaveData.json";
                        string cGameStateSaveData = File.ReadAllText(fGameStateSaveData);

                        // Read "SaveData.json" content
                        string fSaveData = saveGameFullPath + @"\SaveData.json";
                        string cSaveData = File.ReadAllText(fSaveData);

                        // Read "PlayerStateSaveData.json" content
                        string fPlayerStateSaveData = saveGameFullPath + @"\PlayerStateSaveData.json";
                        string cPlayerStateSaveData = File.ReadAllText(fPlayerStateSaveData);

                        // Read Player Position x, y and z
                        string player_x = "", player_y = "", player_z = "";
                        (player_x, player_y, player_z) = getPlayerPosition(cPlayerStateSaveData);

                        // Read Kelvin Position x, y and z
                        string kelvin_x = "", kelvin_y = "", kelvin_z = "";
                        (kelvin_x, kelvin_y, kelvin_z) = getTypePositions(cSaveData, 9);

                        // Read Virginia Position x, y and z
                        string virginia_x = "", virginia_y = "", virginia_z = "";
                        (virginia_x, virginia_y, virginia_z) = getTypePositions(cSaveData, 10);

                        string result = setTypePositions(cSaveData, 10, kelvin_x, kelvin_y, kelvin_z);

                        File.WriteAllText(fSaveData, result);

                        ReLoadNPCData();
                    }
                }
            }
        }

        private void button_MoveToVirginia_Kelvin_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to move Kelvin to Virginia's Position?", "Move Virginia to Kelvin", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (string saveGameFullPath in getSaveFolders(loadMultiplayer))
                {
                    string saveGameFolder = new DirectoryInfo(saveGameFullPath).Name;
                    if (saveGameFolder == listView1.SelectedItems[0].SubItems[0].Text)
                    {
                        // Read "GameStateSaveData.json" content
                        string fGameStateSaveData = saveGameFullPath + @"\GameStateSaveData.json";
                        string cGameStateSaveData = File.ReadAllText(fGameStateSaveData);

                        // Read "SaveData.json" content
                        string fSaveData = saveGameFullPath + @"\SaveData.json";
                        string cSaveData = File.ReadAllText(fSaveData);

                        // Read "PlayerStateSaveData.json" content
                        string fPlayerStateSaveData = saveGameFullPath + @"\PlayerStateSaveData.json";
                        string cPlayerStateSaveData = File.ReadAllText(fPlayerStateSaveData);

                        // Read Player Position x, y and z
                        string player_x = "", player_y = "", player_z = "";
                        (player_x, player_y, player_z) = getPlayerPosition(cPlayerStateSaveData);

                        // Read Kelvin Position x, y and z
                        string kelvin_x = "", kelvin_y = "", kelvin_z = "";
                        (kelvin_x, kelvin_y, kelvin_z) = getTypePositions(cSaveData, 9);

                        // Read Virginia Position x, y and z
                        string virginia_x = "", virginia_y = "", virginia_z = "";
                        (virginia_x, virginia_y, virginia_z) = getTypePositions(cSaveData, 10);

                        string result = setTypePositions(cSaveData, 9, virginia_x, virginia_y, virginia_z);

                        File.WriteAllText(fSaveData, result);

                        ReLoadNPCData();
                    }
                }
            }
        }

        private void button_Revive_Kelvin_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Revive Kelvin?", "Revive Kelvin", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (string saveGameFullPath in getSaveFolders(loadMultiplayer))
                {
                    string saveGameFolder = new DirectoryInfo(saveGameFullPath).Name;
                    if (saveGameFolder == listView1.SelectedItems[0].SubItems[0].Text)
                    {
                        // Read "GameStateSaveData.json" content
                        string fGameStateSaveData = saveGameFullPath + @"\GameStateSaveData.json";
                        string cGameStateSaveData = File.ReadAllText(fGameStateSaveData);

                        // Read "SaveData.json" content
                        string fSaveData = saveGameFullPath + @"\SaveData.json";
                        string cSaveData = File.ReadAllText(fSaveData);

                        // Read "PlayerStateSaveData.json" content
                        string fPlayerStateSaveData = saveGameFullPath + @"\PlayerStateSaveData.json";
                        string cPlayerStateSaveData = File.ReadAllText(fPlayerStateSaveData);

                        string IsRobbyDead = setIsRobbyDead(false);

                        File.WriteAllText(fGameStateSaveData, IsRobbyDead);

                        string RobbyPlayerKilled = setRobbyPlayerKilled(false);

                        File.WriteAllText(fSaveData, RobbyPlayerKilled);

                        ReLoadNPCData();

                        cGameStateSaveData = String.Empty;
                        cSaveData = String.Empty;
                        cPlayerStateSaveData = String.Empty;
                    }
                }
            }
        }

        private void button_Revive_Virginia_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Revive Virginia?", "Revive Virginia", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (string saveGameFullPath in getSaveFolders(loadMultiplayer))
                {
                    string saveGameFolder = new DirectoryInfo(saveGameFullPath).Name;
                    if (saveGameFolder == listView1.SelectedItems[0].SubItems[0].Text)
                    {
                        // Read "GameStateSaveData.json" content
                        string fGameStateSaveData = saveGameFullPath + @"\GameStateSaveData.json";
                        string cGameStateSaveData = File.ReadAllText(fGameStateSaveData);

                        // Read "SaveData.json" content
                        string fSaveData = saveGameFullPath + @"\SaveData.json";
                        string cSaveData = File.ReadAllText(fSaveData);

                        // Read "PlayerStateSaveData.json" content
                        string fPlayerStateSaveData = saveGameFullPath + @"\PlayerStateSaveData.json";
                        string cPlayerStateSaveData = File.ReadAllText(fPlayerStateSaveData);

                        string IsRobbyDead = setIsVirginiaDead(false);

                        File.WriteAllText(fGameStateSaveData, IsRobbyDead);

                        string RobbyPlayerKilled = setVirginiaPlayerKilled(false);

                        File.WriteAllText(fSaveData, RobbyPlayerKilled);

                        ReLoadNPCData();

                        cGameStateSaveData = String.Empty;
                        cSaveData = String.Empty;
                        cPlayerStateSaveData = String.Empty;
                    }
                }
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.ListView listView = (System.Windows.Forms.ListView)sender;
            if (e.Button == MouseButtons.Right)
            {
                if (listView.GetItemAt(e.X, e.Y) != null)
                {
                    listView.GetItemAt(e.X, e.Y).Selected = true;
                }
            }
        }

        private void openSavegameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0 && listView1.SelectedItems.Count == 1)
            {
                foreach (string saveGameFullPath in getSaveFolders(loadMultiplayer))
                {
                    string saveGameFolder = new DirectoryInfo(saveGameFullPath).Name;
                    if (saveGameFolder == listView1.SelectedItems[0].SubItems[0].Text)
                    {
                        Process.Start(saveGameFullPath);
                    }
                }
            }
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            System.Windows.Forms.ListView listView = (System.Windows.Forms.ListView)sender;
            e.Cancel = true;
            e.NewWidth = listView.Columns[e.ColumnIndex].Width;
        }
    }
}

public class ListViewColumnSorter : IComparer
{
    private int columnIndex;
    private SortOrder sortOrder;
    private bool ignoreCase;

    public ListViewColumnSorter()
    {
        this.columnIndex = 0;
        this.sortOrder = SortOrder.None;
    }

    public ListViewColumnSorter(int columnIndex, SortOrder sortOrder, bool ignoreCase = true)
    {
        this.columnIndex = columnIndex;
        this.sortOrder = sortOrder;
        this.ignoreCase = ignoreCase;
    }

    public int Compare(object x, object y)
    {
        int compareResult = 0;
        ListViewItem item1 = (ListViewItem)x;
        ListViewItem item2 = (ListViewItem)y;

        // Get the values to compare from the subitems collection of the ListViewItems
        string value1 = item1.SubItems[columnIndex].Text;
        string value2 = item2.SubItems[columnIndex].Text;

        // Check if the values are numbers
        double number1, number2;
        bool isNumber1 = double.TryParse(value1, out number1);
        bool isNumber2 = double.TryParse(value2, out number2);

        // Compare the values based on the sort order
        if (isNumber1 && isNumber2 && sortOrder == SortOrder.Ascending)
        {
            compareResult = number1.CompareTo(number2);
        }
        else if (isNumber1 && isNumber2 && sortOrder == SortOrder.Descending)
        {
            compareResult = number2.CompareTo(number1);
        }
        else if (sortOrder == SortOrder.Ascending)
        {
            compareResult = string.Compare(value1, value2, ignoreCase);
        }
        else if (sortOrder == SortOrder.Descending)
        {
            compareResult = string.Compare(value2, value1, ignoreCase);
        }

        return compareResult;
    }
}
