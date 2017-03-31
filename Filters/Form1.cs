using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Imaging.Filters;

namespace Filters
{
    public partial class Form1 : Form
    {
        int flag = 0, flag1 = 0, flag2 = 0;
        SaveFileDialog save = new SaveFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                flag = 1;
                Bitmap image = new Bitmap(open.FileName);
                pictureBox1.Image = (Bitmap) image;
                pictureBox2.Image = null;
            }
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag == 1 && flag1 != 1)
            {

                if (save.ShowDialog() == DialogResult.OK)
                {
                    flag1 = 1;
                    pictureBox2.Image.Save(save.FileName);
                }
            }
          
            else
                this.Show();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (save.ShowDialog() == DialogResult.OK)
            {
                flag1 = 1;
                pictureBox2.Image.Save(save.FileName);
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Exit Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blur blur = new Blur();
            pictureBox2.Image = blur.Apply((Bitmap)pictureBox1.Image);
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Closing closing = new Closing();
            pictureBox2.Image = closing.Apply((Bitmap)pictureBox2.Image);
        }

        private void dilatationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag2 == 1)
            {
                Dilatation dilatation = new Dilatation();
                pictureBox2.Image = dilatation.Apply((Bitmap)pictureBox2.Image);
            }
            else
                this.Show();
        }

        private void dilatation33ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag2 == 1)
            {
                Dilatation3x3 dilatation33 = new Dilatation3x3();
                pictureBox2.Image = dilatation33.Apply((Bitmap)pictureBox2.Image);
            }
            else
                this.Show();
        }

        private void binaryDilatation33ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag2 == 1)
            {
                BinaryDilatation3x3 binaryDilatation33 = new BinaryDilatation3x3();
                pictureBox2.Image = binaryDilatation33.Apply((Bitmap)pictureBox2.Image);
            }
            else
                this.Show();
        }

        private void edgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edges edges = new Edges();
            pictureBox2.Image = edges.Apply((Bitmap)pictureBox1.Image);
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag2 = 1;
            Grayscale gray = new Grayscale(0.2125, 0.7154, 0.0721);
            pictureBox2.Image = gray.Apply((Bitmap)pictureBox1.Image);
        }

        private void hSLLinearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HSLFiltering hSLFiltering = new HSLFiltering();
            hSLFiltering.Hue = new IntRange(335, 0);
            hSLFiltering.Saturation = new Range(0.6f, 1);
            hSLFiltering.Luminance = new Range(0.1f, 1);
            pictureBox2.Image = hSLFiltering.Apply((Bitmap)pictureBox1.Image);
        }

        private void hSLFilteringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HSLLinear hSLLinear = new HSLLinear();
            hSLLinear.InLuminance = new Range(0, 0.85f);
            hSLLinear.OutSaturation = new Range(0.25f, 1);
            pictureBox2.Image = hSLLinear.Apply((Bitmap)pictureBox1.Image);
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opening opening = new Opening();
            pictureBox2.Image = opening.Apply((Bitmap)pictureBox2.Image);
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
        }
    }
}
