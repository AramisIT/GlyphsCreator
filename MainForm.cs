namespace GlyphsCreator
    {
    using GlyphBuilding;
    using Models;
    using System;
    using System.Windows.Forms;

    public partial class MainForm : Form
        {
        GlyphModel glyph = new GlyphModel() { GlyphCodeType = 1 };
        public MainForm()
            {
            InitializeComponent();

            glyphDataTextBox.DataBindings.Add(nameof(glyphDataTextBox.Text), glyph,
                nameof(glyph.GlyphData), false, DataSourceUpdateMode.OnPropertyChanged);

            glyphTypeTextBox.DataBindings.Add(nameof(glyphTypeTextBox.Text), glyph,
                nameof(glyph.GlyphCodeType), false, DataSourceUpdateMode.OnPropertyChanged);

            var imageBuilder = new GlyphImageBuilder();
            glyph.PropertyChanged += (sender, e) =>
            {
                glyphPictureBox.Image = imageBuilder.BuildGlyphImage(glyph.GlyphData, glyph.GlyphCodeType, glyphPictureBox.Size.Width);
            };

            glyph.GlyphData = 1;
            }

        private void autoUpdateTimer_Tick(object sender, System.EventArgs e)
            {
            if (InvokeRequired)
                {
                Invoke(new Action(updateGlyphData), null);
                }
            else
                {
                updateGlyphData();
                }
            }

        private void updateGlyphData()
            {
            const long MAX_VALUE_FOR_GLYPH_DATA = 34359738367;
            if (glyph.GlyphData == MAX_VALUE_FOR_GLYPH_DATA)
                {
                glyph.GlyphData = 1;
                }
            else
                {
                glyph.GlyphData += 1;
                }
            }

        private void runAutoDataUpdateButton_Click(object sender, System.EventArgs e)
            {
            autoUpdateTimer.Enabled = true;
            (sender as Button).Enabled = false;
            }
        }
    }
