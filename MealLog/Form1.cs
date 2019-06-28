using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealLog
{
    public partial class Form1 : Form
    {
        List<User> currentResidents = new List<User>();
        List<User> residentsScannedIn = new List<User>();
        public Form1()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            //TODO: load data from a database and create Users for them, for now ill use test users
#if DEBUG
            for(int i = 0; i < 5; i++)
            {
                User newUser = new User("test" + i, "user", 1000000 + i, "test" + i + "@email.com");
                currentResidents.Add(newUser);
            }
#endif
        }

        private bool validateAndAdd(string id)
        {
            foreach (var i in residentsScannedIn)
            {
                if (int.Parse(id) == i.getID())
                {
                    return false;
                }
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Make sure to click on Barcode Number before residents arrive.");
#if DEBUG
            foreach (var i in currentResidents)
            {
                Console.WriteLine(i.ToString());
            }
#endif
            textBoxBarcode.Focus();
        }

        private void TextBoxBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBoxBarcode.Text != "")
                    {
                        foreach (var i in currentResidents)
                        {
                            if (i.getID() == int.Parse(textBoxBarcode.Text))
                            {
                                if (validateAndAdd(textBoxBarcode.Text))
                                {
                                    foreach (var j in currentResidents)
                                    {
                                        if (int.Parse(textBoxBarcode.Text) == j.getID())
                                        {
                                            residentsScannedIn.Add(j);
                                            listBoxResidents.Items.Add(j.ToString());
                                            textBoxBarcode.Clear();
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Resident has already scanned in.", "Error");
                                    textBoxBarcode.Clear();
                                    return;
                                }
                            }
                        }
                        MessageBox.Show("Invalid Barcode, please try again.", "Error");
                        textBoxBarcode.Clear();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Barcode appears to be empty.", "Error");
                        textBoxBarcode.Clear();
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                textBoxBarcode.Clear();
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            textBoxBarcode.Focus();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MealLog: Created and Designed by Alexander Cheer\nhttps://alexcheer.tech/\nParts of this program may be licensed under the GPL v3 License, check LICENSE for more info");
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO: program settings window");
        }
    }
}
