using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Third
{
    public partial class txtOriginalLineCoun1 : Form
    {
        private string filePath;

        public txtOriginalLineCoun1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "C# Files (*.cs)|*.cs";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        AnalyzeFile(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件错误: " + ex.Message);
            }
        }


        private void AnalyzeFile(string path)
        {
            try
            {
                var lines = File.ReadAllLines(path);
                int originalLineCount = lines.Length;
                int originalWordCount = CountWords(lines);

                txtOriginalLineCount.Text = originalLineCount.ToString();
                txtOriginalWordCount.Text = originalWordCount.ToString();

                //显示原始文本
                txtOriginalContent.Text = string.Join(Environment.NewLine, lines);

                var cleanedLines = lines.Where(line => !string.IsNullOrWhiteSpace(line) && !line.TrimStart().StartsWith("//"));
                var formattedText = string.Join(Environment.NewLine, cleanedLines);

                try
                {
                    File.WriteAllText(path, formattedText); // 可选择保存到新文件
                }
                catch (Exception ex)
                {
                    MessageBox.Show("写入文件错误: " + ex.Message);
                }

                int formattedLineCount = cleanedLines.Count();
                int formattedWordCount = CountWords(cleanedLines);

                txtFormattedLineCount.Text = formattedLineCount.ToString();
                txtFormattedWordCount.Text = formattedWordCount.ToString();


                // 显示修改后的文本
                txtFormattedContent.Text = formattedText;

                var wordCounts = CountWordOccurrences(formattedText);
                lstWordOccurrences.Items.Clear();
                foreach (var entry in wordCounts)
                {
                    lstWordOccurrences.Items.Add($"{entry.Key}: {entry.Value}");
                }

                lstWordOccurrencesInorder.Items.Clear();
                foreach (var entry in wordCounts.OrderByDescending(entry => entry.Value))
                {
                    lstWordOccurrencesInorder.Items.Add($"{entry.Key}: {entry.Value}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("分析文件错误: " + ex.Message);
            }
        }
        private int CountWords(IEnumerable<string> lines)
        {
            return lines.Sum(line => Regex.Matches(line, @"\b\w+\b").Count);
        }

        private Dictionary<string, int> CountWordOccurrences(string text)
        {
            var words = Regex.Matches(text, @"\b\w+\b");
            var wordCounts = new Dictionary<string, int>();

            foreach (Match word in words)
            {
                var key = word.Value.ToLower();
                if (wordCounts.ContainsKey(key))
                    wordCounts[key]++;
                else
                    wordCounts[key] = 1;
            }

            return wordCounts;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lstWordOccurrences_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
