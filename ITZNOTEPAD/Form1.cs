namespace ITZNOTEPAD
{
    public partial class Form1 : Form
    {
        private bool haveOpen = false;
        DialogResult result;
        string name;
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //empty
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left); //setting anchor to fit by window size
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open file dialog
            OpenFileDialog openFileDialog1;  
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                name = openFileDialog1.FileName;
                haveOpen = true;
                Form.ActiveForm.Text = "ITZNOTEPAD " +openFileDialog1.FileName;
            }
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => new AboutPage().Show();


        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                name = saveFileDialog1.FileName;
                File.WriteAllText(name, richTextBox1.Text);
                haveOpen = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (haveOpen) {
                File.WriteAllText(name, richTextBox1.Text);
            }
            if (!haveOpen)
            {
                result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    name = saveFileDialog1.FileName;
                    File.WriteAllText(name, richTextBox1.Text);
                    haveOpen = true;
                }
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog res = new FontDialog();
            
            if(res.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = res.Font;
            }
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog res = new ColorDialog();
            if(res.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = res.Color;
            }
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog res = new ColorDialog();
            if (res.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = res.Color;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Undo();

        private void redoToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Redo();

        private void cutToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Cut();

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Copy();

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Paste();

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.SelectedText = "";

        private void menuStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog res = new ColorDialog();
            if (res.ShowDialog() == DialogResult.OK)
            {
                menuStrip1.BackColor = res.Color;
                fileToolStripMenuItem.BackColor = res.Color;
                editToolStripMenuItem.BackColor = res.Color;
            }
        }
    }
}