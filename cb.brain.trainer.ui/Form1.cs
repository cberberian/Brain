using System;
using System.Configuration;
using System.IO;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using AIMLbot;

namespace cb.brain.trainer.ui
{
    public partial class Form1 : Form
    {
        private readonly SpeechSynthesizer _synth;
        private readonly Bot _myBot;
        private readonly User _myUser;
        private string _currentFilename;

        public Form1()
        {
            InitializeComponent();
            _myBot = new Bot();
            _myBot.loadSettings();
            _myUser = new User("consoleUser", _myBot);
            _synth = new SpeechSynthesizer();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var r = new Request(txtInputText.Text, _myUser, _myBot);
            var res = _myBot.Chat(r);
            textBox1.Text = res.Output;
            if (checkBox1.Checked) 
                _synth.Speak(res.Output);
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location)
            };

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                var document = new XmlDocument();
                document.Load(openFileDialog1.OpenFile());
                UpdateBotAndText(document, openFileDialog1.FileName);
//                xmlEditor1.AllowXmlFormatting = true;
//                xmlEditor1.Text = document.OuterXml;
//                xmlEditor1.ReFormat();


            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        private void UpdateBotAndText(XmlDocument document, string currentFilename)
        {
            _myBot.LoadAimlFromXml(document, currentFilename);
            _currentFilename = currentFilename;


            var sb = new StringBuilder();
            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };
            using (var writer = XmlWriter.Create(sb, settings))
            {
                document.Save(writer);
            }

            //  Tokenize the Xml string
            var str = sb.ToString();
            txtAiml.Text = str;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdateBot_Click(object sender, EventArgs e)
        {
            var document = new XmlDocument();
            document.LoadXml(txtAiml.Text);
            UpdateBotAndText(document, _currentFilename);
        }
    }
}
