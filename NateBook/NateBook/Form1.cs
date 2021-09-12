using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NateBook;

namespace NateBook
{
    public partial class Form1 : Form
    {
        bool change;
        public Form1()
        {
            
            InitializeComponent();
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();

            var fontFamilies = installedFontCollection.Families;
            foreach (var fonts in fontFamilies)
            {
                string fontName = fonts.Name;
                toolStripComboBox1.Items.Add(fontName);
            }



        }
        NoteBookChild ActivForm { get => ActiveMdiChild as NoteBookChild; }

        private void NoteBook_Load(object sender, EventArgs e)
        {

        }

    

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
                var ColorDialog = new ColorDialog();
                if (ColorDialog.ShowDialog() == DialogResult.OK)

                {
                    if (ActivForm.richTextBox1.SelectedText.Length > 0)
                    {
                    ActivForm.richTextBox1.SelectionBackColor = ColorDialog.Color;
                    }
                    else
                    {
                    ActivForm.richTextBox1.SelectAll();

                    ActivForm.richTextBox1.SelectionBackColor = ColorDialog.Color;
                    }
                }
        }


        

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var FontDialog = new FontDialog();
            FontDialog.ShowColor=true;
            if(FontDialog.ShowDialog()==DialogResult.OK);
            {
                if (ActivForm.richTextBox1.SelectedText.Length > 0)
                {
                    ActivForm.richTextBox1.SelectionFont = FontDialog.Font;
                    ActivForm.richTextBox1.SelectionColor = FontDialog.Color;
                }
                else
                {
                    ActivForm.richTextBox1.Font = FontDialog.Font;
                    ActivForm.richTextBox1.ForeColor = FontDialog.Color;
                }
            }
           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            change = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var fileopen= new OpenFileDialog();
            fileopen.Filter = "Text document|*.txt*| RTF|*.rtf| HTML| *.html| CS| *.cs";
            fileopen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (change == true)
            {
                const string message = "Are you sure that you would like to close the form?";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (fileopen.ShowDialog() == DialogResult.OK)
                    {
                        ActivForm.richTextBox1.LoadFile(fileopen.FileName);
                    }
                }

            }
            else {
                if (fileopen.ShowDialog() == DialogResult.OK)
                {
                    ActivForm.richTextBox1.LoadFile(fileopen.FileName);
                }
            }
        }
            

        private void safeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ActivForm.richTextBox1.SaveFile(saveDialog.FileName, RichTextBoxStreamType.RichText);
                change = false;
            }
        }

        private void windowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics objGraphics;
            Clipboard.SetData(DataFormats.Rtf, ActivForm.richTextBox1.SelectedRtf);
            //Clipboard.Clear();
        }

        private void safeAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text document|*.txt*| RTF|*.rtf| HTML| *.html| CS| *.cs";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ActivForm.richTextBox1.SaveFile(saveDialog.FileName, RichTextBoxStreamType.UnicodePlainText);
                change = false;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text document|*.txt*| RTF|*.rtf| HTML| *.html| CS| *.cs";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ActivForm.richTextBox1.SaveFile(saveDialog.FileName, RichTextBoxStreamType.UnicodePlainText);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var fileopen = new OpenFileDialog();
            fileopen.Filter = "Text document|*.txt*| RTF|*.rtf| HTML| *.html| CS| *.cs";
            fileopen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (fileopen.ShowDialog() == DialogResult.OK)
            {
                ActivForm.richTextBox1.LoadFile(fileopen.FileName);
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog();
           

            if (ActivForm.richTextBox1.SelectedText.Length > 0)
            {
                ActivForm.richTextBox1.SelectionFont = new System.Drawing.Font(fontDialog.Font, System.Drawing.FontStyle.Italic);

            }
            else
            {
                ActivForm.richTextBox1.Font = new System.Drawing.Font(fontDialog.Font, System.Drawing.FontStyle.Italic);

            }

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog();


            if (ActivForm.richTextBox1.SelectedText.Length > 0)
            {
                ActivForm.richTextBox1.SelectionFont = new System.Drawing.Font(fontDialog.Font, System.Drawing.FontStyle.Bold);

            }
            else
            {
                ActivForm.richTextBox1.Font = new System.Drawing.Font(fontDialog.Font, System.Drawing.FontStyle.Bold);

            }

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

            var fontDialog = new FontDialog();


            if (ActivForm.richTextBox1.SelectedText.Length > 0)
            {
                ActivForm.richTextBox1.SelectionFont = new System.Drawing.Font(fontDialog.Font, System.Drawing.FontStyle.Underline);

            }
            else
            {
                ActivForm.richTextBox1.Font = new System.Drawing.Font(fontDialog.Font, System.Drawing.FontStyle.Underline);

            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {

            if (ActivForm.richTextBox1.SelectedText.Length > 0)
            {
                ActivForm.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
            else
            {
                ActivForm.richTextBox1.SelectAll();
                ActivForm.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (ActivForm.richTextBox1.SelectedText.Length > 0)
            {
                ActivForm.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            }
            else
            {
                ActivForm.richTextBox1.SelectAll();
                ActivForm.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (ActivForm.richTextBox1.SelectedText.Length > 0)
            {
                ActivForm.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            }
            else
            {
                ActivForm.richTextBox1.SelectAll();
                ActivForm.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            
            if (ActivForm.richTextBox1.SelectedText.Length > 0)
            {
                ActivForm.richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, Convert.ToInt32(toolStripButton11.SelectedItem));
            }
            else
            {
                ActivForm.richTextBox1.Font = new Font(richTextBox1.SelectionFont.Name, Convert.ToInt32(toolStripButton11.SelectedItem));
            }
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {

            if (ActivForm.richTextBox1.SelectedText.Length > 0)
            {
                ActivForm.richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size-1);
            }
            else
            {
                ActivForm.richTextBox1.Font = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size - 1);
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            if (ActivForm.richTextBox1.SelectedText.Length > 0)
            {
                ActivForm.richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size + 1);
            }
            else
            {
                ActivForm.richTextBox1.Font = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size + 1);
            }
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            var ColorDialog = new ColorDialog();
            if (ColorDialog.ShowDialog() == DialogResult.OK)

            {
                if (ActivForm.richTextBox1.SelectedText.Length > 0)
                {
                    ActivForm.richTextBox1.SelectionColor = ColorDialog.Color;
                }
                else
                {
                    ActivForm.richTextBox1.SelectAll();

                    ActivForm.richTextBox1.SelectionColor = ColorDialog.Color;
                }
            }
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            if (ActivForm.richTextBox1.SelectionBullet == false)
            {
                if (ActivForm.richTextBox1.SelectedText.Length > 0)
                {
                    ActivForm.richTextBox1.SelectionBullet = true;
                }
                else
                {
                    ActivForm.richTextBox1.SelectAll();
                    ActivForm.richTextBox1.SelectionBullet = true;
                }
            }
            else
            {
                if (ActivForm.richTextBox1.SelectedText.Length > 0)
                {
                    ActivForm.richTextBox1.SelectionBullet = false;
                }
                else
                {
                    ActivForm.richTextBox1.SelectAll();
                    ActivForm.richTextBox1.SelectionBullet = false;
                }
            }
            
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActivForm.richTextBox1.SelectedText.Length > 0)
            {
                ActivForm.richTextBox1.SelectionFont = new Font(Convert.ToString(toolStripComboBox1.SelectedItem), richTextBox1.SelectionFont.Size, FontStyle.Regular);
            }
            else
            {
                ActivForm.richTextBox1.SelectAll();

                ActivForm.richTextBox1.SelectionFont = new Font(Convert.ToString(toolStripComboBox1.SelectedItem), richTextBox1.SelectionFont.Size, FontStyle.Regular);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivForm.richTextBox1.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                ActivForm.richTextBox1.SelectedRtf= Clipboard.GetData(DataFormats.Rtf).ToString();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivForm.richTextBox1.Clear();
        }


        NoteBookChild childform = new NoteBookChild();
        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var childform = new NoteBookChild();

            childform.MdiParent = this;
           
            childform.Show();
            childform.TopMost = true;

            this.LayoutMdi(MdiLayout.Cascade);
        }
           
    }
}
