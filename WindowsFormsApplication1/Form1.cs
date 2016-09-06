using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        /**
         * Return selected directory 
         * */
        public string getDirect()
        {
            string dir = "";
            FolderBrowserDialog getDir = new FolderBrowserDialog();
            if (dir == "")
            {
                getDir.SelectedPath = "d:\\";
            }
            else
            {
                getDir.SelectedPath = dir;
            }

            getDir.ShowNewFolderButton = true;
            if (getDir.ShowDialog() == DialogResult.OK)
            {
                dir = getDir.SelectedPath;
            }
            return dir;
         }

        /**
         * Search files
         * @Params dir - directory for search
         * @params cr - criteria of search
         **/
         public string[] searchFiles(string dir, string cr)
        {
            if(String.IsNullOrWhiteSpace(cr))
            {
                cr = "*";
            }

            string criteria = "?" + cr; 
            string[] files = Directory.GetFiles(dir, criteria);
            return files;
        }

        /*
         * Click on button "Open" 
         */
        private void btnOpen_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            txtDirectory.Text = getDirect();
        }

        /**
         * Click on button "Search"
         **/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtResults.Text = "";
            try
            {
                //get array of find files
                string[] listFiles = searchFiles(txtDirectory.Text, txtFileType.Text);
                for (int i = 0; i < listFiles.Length; i++)
                {
                    txtResults.Text += listFiles[i] + "\r\n";
                }
                txtResults.Visible = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка поиска: " + ex.Message);
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDirectory.Text = "";
            txtFileType.Text = "";
            txtResults.Text = "";
            txtResults.Visible = false;
        }
    }
}
