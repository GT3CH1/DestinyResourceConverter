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
            commentBox.TextChanged += CheckCommentBox;
            additionalOptionsList.ItemCheck += AdditionalOptionsSet;
            convertButton.Click += ConvertFile;
            fileBrowse.Enabled = false;
            commentBox.Enabled = false;
            conditionBox.Enabled = false;
            availablityBox.Enabled = false;
            additionalOptionsList.SetItemChecked(0,true);
            optionList.SetItemChecked(0,true);
            Constants.IDAsMAC = true;
            Constants.HasMacComment = true;
            AddItems();
        }

        /// <summary>
        /// Delegate used to check whether or not something is typed in the comment box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckCommentBox(object sender, EventArgs e)
        {
            Constants.HasAdditionalNote = false;
            if (commentBox.TextLength > 0)
                Constants.HasAdditionalNote = true;
            Constants.AdditionalNote = commentBox.Text;
        }

        /// <summary>
        /// Launches the CSV to XML conversion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertFile(object sender, EventArgs e)
        {
            int selectedCondition = conditionBox.SelectedIndex;
            int selectedStatus = availablityBox.SelectedIndex;
            Constants.Condition = ConditionConstants.CONSTANTS[selectedCondition];
            Constants.CurrentStatus = StatusConstants.CONSTANTS[selectedStatus];
            int currentSelection = resourceSelection.SelectedIndex;
            bool result = reader.CreateExportXML(filePathToRead, poText.Text, reader.DestinyItems[currentSelection]);
            if (result)
                MessageBox.Show("Success!", "CSV to Destiny", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error!", "CSV to Destiny", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Delegate used to check 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdditionalOptionsSet(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
                Constants.HasMacComment = e.NewValue == CheckState.Checked;
            if (e.Index == 1)
                Constants.HasAdditionalNote = e.NewValue == CheckState.Checked;
            if (e.Index == 2)
                Constants.HasBarcode = e.NewValue == CheckState.Checked;
            
            if (Constants.HasAdditionalNote)
                commentBox.Enabled = true;
            else
                commentBox.Enabled = false;
        }

        /// <summary>
        /// Delegate used to check the purchase order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPO(object sender, EventArgs e)
        {
            
            conditionBox.Enabled = false;
            availablityBox.Enabled = false;
            convertButton.Enabled = false;
            if (poText.TextLength > 0)
            {
                conditionBox.Enabled = true;
                availablityBox.Enabled = true;
                convertButton.Enabled = true;
            }
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
            Constants.IDAsMAC = optionList.GetItemChecked(0);
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
            foreach (string item in ConditionConstants.CONSTANTS)
                conditionBox.Items.Add(item);
            foreach (string item in StatusConstants.CONSTANTS)
                availablityBox.Items.Add(item);
            conditionBox.SelectedIndex = 0;
            availablityBox.SelectedIndex = 0;
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