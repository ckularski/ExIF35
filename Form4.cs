using System;
using System.Web.UI;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;

namespace ExIF35
{
    public partial class Form4 : Form
    {
        Roll thisRoll = new Roll();
        List<int> skipNums = new List<int>();
        int activeIndex = -1;
        int selIndex = -1; 
        public int FileSource = 0;
        int counter = 0;
        
        public Form4(Roll rollOfExposures)
        {
            thisRoll = rollOfExposures;
            InitializeComponent();
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (Exposure exp in thisRoll.exposures)
            {
                listView1.Items.Add(new ListViewItem(new String[] { exp.Number, exp.ImageFile, exp.Orientation.ToString() }));
            }
        }

        private void rotateImg(string direction, int index)
        {
            int curOrientation = thisRoll.exposures[index].Orientation;
            int newOrientation = 9;
            if (direction.Equals("counter"))
            {
                if (curOrientation == 0)
                {
                    newOrientation = 2;
                }
                else if (curOrientation == 2)
                {
                    newOrientation = 3;
                }
                else if (curOrientation == 3)
                {
                    newOrientation = 1;
                }
                else if (curOrientation == 1)
                {
                    newOrientation = 0; 
                }
            }
            else if (direction.Equals("clock"))
            {
                if (curOrientation == 0)
                {
                    newOrientation = 1;
                }
                else if (curOrientation == 1)
                {
                    newOrientation = 3;
                }
                else if (curOrientation == 3)
                {
                    newOrientation = 2;
                }
                else if (curOrientation == 2)
                {
                    newOrientation = 0;
                }
            }
            
            thisRoll.exposures[index].Orientation = newOrientation;
            listView1.Items[index].SubItems[2].Text = thisRoll.exposures[index].Orientation.ToString();
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                
                //int selIndex = listView1.SelectedIndices[0];
                Image tmp = pictureBox1.Image;
                tmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox1.Image = tmp;
                rotateImg("counter", selIndex);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog();
            String getPath = folderBrowserDialog2.SelectedPath;
            doFileProcessing(Directory.GetFiles(getPath));
            button4.Visible = false;
            label6.Visible = false;
            txtfromdir.Text = getPath;
            txtfromdir.Visible = true;

        }

        private void folderBrowserDialog2_HelpRequest(object sender, EventArgs e)
        {

        }
        public bool ThumbnailCallback()
        {
            return false;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                selIndex = listView1.SelectedIndices[0];

            }
            if (listView1.SelectedIndices.Count > 0)
            {
                //int selIndex = listView1.SelectedIndices[0];

                if (!thisRoll.exposures[selIndex].ImageFile.Equals(""))
                {
                    Image tmp; 
                    Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                    try
                    {
                        Image i = Image.FromFile(thisRoll.exposures[selIndex].ImageFile);
                        int x = i.Height;
                        int y = i.Width;
                        int w = 400;
                        int h = 400; 

                        if (x > y)
                        {
                            w = Convert.ToInt32(Math.Round((((float)y / (float)x) * 400), 0));
                        }
                        else if (y > x)
                        {
                            h = Convert.ToInt32(Math.Round((((float)x / (float)y) * 400), 0));
                        }

                        tmp = Image.FromFile(thisRoll.exposures[selIndex].ImageFile).GetThumbnailImage(w, h, myCallback, IntPtr.Zero);
                        
                    }
                    catch (FileNotFoundException eFile)
                    {
                        tmp = pictureBox1.InitialImage; 
                    }
                    if (thisRoll.exposures[selIndex].Orientation != 0)
                    {
                        if (thisRoll.exposures[selIndex].Orientation == 1)
                        {
                            tmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        }
                        else if (thisRoll.exposures[selIndex].Orientation == 2)
                        {
                            tmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                        else if (thisRoll.exposures[selIndex].Orientation == 3)
                        {
                            tmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        }

                    }
                    pictureBox1.Image = tmp;
                    
                    
                    
                }
            }
        }
        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                doFileProcessing(files);
            }
        }
        private void doFileProcessing(String[] files)
        {
            foreach (String curFileName in files)
            {
                if (skipNums.Contains(counter))
                {
                    counter++;
                }
                if (counter < thisRoll.exposures.Count)
                {

                   
                    FileInfo tmpfileio = new FileInfo(curFileName);
                    if (tmpfileio.Extension.Equals(".jpg") || tmpfileio.Extension.Equals(".jpeg") || tmpfileio.Extension.Equals(".JPG") || tmpfileio.Extension.Equals(".JPEG"))
                    {
                        if (!thisRoll.exposures[counter].ImageFile.Equals(""))
                        {
                            DialogResult result = MessageBox.Show("Replace file?", "Exposure " + thisRoll.exposures[counter].Number + " already contains a file, replace?", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                thisRoll.exposures[counter].ImageFile = curFileName;
                                listView1.Items[counter] = new ListViewItem(new String[] { thisRoll.exposures[counter].Number, curFileName, thisRoll.exposures[counter].Orientation.ToString() });
                            }
                        }
                        else
                        {
                            thisRoll.exposures[counter].ImageFile = curFileName;
                            listView1.Items[counter] = new ListViewItem(new String[] { thisRoll.exposures[counter].Number, curFileName, thisRoll.exposures[counter].Orientation.ToString() });
                        }
                        counter++;
                    }
                }
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnClock_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                
                //int selIndex = listView1.SelectedIndices[0];
                Image tmp = pictureBox1.Image;
                tmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Image = tmp;
                rotateImg("clock", selIndex);


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (Exposure exp in thisRoll.exposures)
            {
                listView1.Items.Add(new ListViewItem(new String[] { exp.Number, "" }));
                exp.ImageFile = "";
            }
            pictureBox1.Image = pictureBox1.InitialImage; 
            counter = 0;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void skipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int skipNumber = listView1.SelectedIndices[0];
                if (skipNums.Contains(skipNumber))
                {
                    skipNums.Remove(skipNumber);
                    listView1.Items[skipNumber] = new ListViewItem(new string[] { thisRoll.exposures[skipNumber].Number, "File Not Set", thisRoll.exposures[counter].Orientation.ToString() });

                }
                else
                {
                    skipNums.Add(skipNumber);
                    listView1.Items[skipNumber] = new ListViewItem(new string[] { thisRoll.exposures[skipNumber].Number, "Skipped", thisRoll.exposures[counter].Orientation.ToString() });
                }

            }
        }

        private void setFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                activeIndex = listView1.SelectedIndices[0];
                openFileDialog1.ShowDialog();
            }
        }

        private void btnTags_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                List<String> exposureTags = thisRoll.exposures[listView1.SelectedIndices[0]].Tags;
                txtTags FormTag = new txtTags(exposureTags);
                FormTag.ShowDialog();
                exposureTags = new List<String>();
                foreach (String strTag in FormTag.rtbTags.Text.Split('\n'))
                {
                    if (!strTag.Equals(""))
                    {
                        exposureTags.Add(strTag);
                    }
                }
                thisRoll.exposures[listView1.SelectedIndices[0]].Tags = exposureTags;
            }
        }
    }
}
