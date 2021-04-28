using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DestinyConverter
{
    public partial class Form1 : Form
    {
        private CsvReader reader;

        private string filePathToRead;
        private bool foundFile;
        private bool changedResource;
        

        public Form1()
        {
            InitializeComponent();
            reader = new CsvReader();
            resourceSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            resourceSelection.SelectedIndexChanged += GetNewInfo;
            fileBrowse.Click += BrowseForFile;
            optionList.ItemCheck += ItemCheck;
            poText.TextChanged += CheckPO;
            convertButton.Click += ConvertFile;
            fileBrowse.Enabled = false;
            AddItems();
        }

        private void ConvertFile(object sender, EventArgs e)
        {
            bool idAsMac = optionList.GetItemChecked(0);
            bool macComment = additionalOptionsList.GetItemChecked(0);
            int currentSelection = resourceSelection.SelectedIndex;
            bool result = reader.CreateExportXML(filePathToRead,idAsMac,macComment,poText.Text,reader.DestinyItems[currentSelection]);
            if (result)
                MessageBox.Show("Success!", "CSV to Destiny", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error!", "CSV to Destiny", MessageBoxButtons.OK, MessageBoxIcon.Error);
            EnableOptions(false);
        }

        /// <summary>
        /// Delegate used to check the purchase order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPO(object sender, EventArgs e)
        {
            convertButton.Enabled = false;
            if (poText.TextLength > 0)
                convertButton.Enabled = true;
        }

        /// <summary>
        /// Event delegate for when an item is checked (enforces only one option to be checked).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < optionList.Items.Count; ++ix)
                    if (e.Index != ix)
                        optionList.SetItemChecked(ix, false);
        }

        /// <summary>
        /// Delegate used to update the price, location, and manufacture labels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetNewInfo(object sender, EventArgs e)
        {
            int index = resourceSelection.SelectedIndex;
            changedResource = true;
            priceText.Text = reader.DestinyItems[index].Price.ToString();
            locationText.Text = reader.DestinyItems[index].Template;
            manufacturerText.Text = reader.DestinyItems[index].Manufacturer;

            fileBrowse.Enabled = true;
        }

        /// <summary>
        /// Adds the destiny items to the drop down list.
        /// </summary>
        private void AddItems()
        {
            foreach (DestinyItem readerDestinyItem in reader.DestinyItems)
                resourceSelection.Items.Add(readerDestinyItem.Description);
        }

        /// <summary>
        /// Enables all the options in the options container.
        /// </summary>
        /// <param name="state">The state to set the options to.</param>
        private void EnableOptions(bool state)
        {
            foundFile = state;
            optionList.Enabled = state;
            poText.Enabled = state;
            additionalOptionsList.Enabled = state;
        }
        
        /// <summary>
        /// Enables the user to browse for a csv file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void BrowseForFile(object sender, EventArgs eventArgs)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = "c:\\";
                dialog.Filter = "csv (*.csv)|*.csv";
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePathToRead = dialog.FileName;
                    selectedFileText.Text = filePathToRead;
                    EnableOptions(true);
                }
            }
        }
    }
}