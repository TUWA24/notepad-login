using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        private bool unsavedChanges = false;
        public Form2()
        {
            InitializeComponent();
            richTextBox1.TextChanged += richTextBox1_TextChanged;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            unsavedChanges = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (unsavedChanges)
            {
                var result = MessageBox.Show("Do you want to save changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Save();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            richTextBox1.Clear();
            unsavedChanges = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckUnsavedChanges())
            {
                Application.Exit();
            }
        }

        private void Save()
        {
           
            unsavedChanges = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

           
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Open Text File";

          
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                string contents = File.ReadAllText(openFileDialog.FileName);

              
                richTextBox1.Text = contents;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save Text File";

           
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
            }
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog  fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
              
                richTextBox1.Font = fontDialog.Font;
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.WordWrap = !richTextBox1.WordWrap;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            string aboutText = "Joshua Scalercio\nCourse: BSIT\nYear Level: 2nd Year";

           
            MessageBox.Show(this, aboutText, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool CheckUnsavedChanges()
        {
            
            if (richTextBox1.Modified)
            {
                
                DialogResult result = MessageBox.Show("Do you want to save your changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

               
                if (result == DialogResult.Yes)
                {
                   
                    return true;
                }
               
                else if (result == DialogResult.No)
                {
                    return true;
                }
              
                else
                {
                    return false;
                }
            }
          
            else
            {
                return true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
    

