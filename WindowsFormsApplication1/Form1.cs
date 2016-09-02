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
            if(cr == "")
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
        private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            textBox1.Text = getDirect();
        }

        /**
         * Click on button "Search"
         **/
        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            try
            {
                //get array of find files
                string[] listFiles = searchFiles(textBox1.Text, textBox2.Text);
                for (int i = 0; i < listFiles.Length; i++)
                {
                    textBox3.Text += listFiles[i] + "\r\n";
                }
                textBox3.Visible = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox3.Visible = false;
        }
    }
}
