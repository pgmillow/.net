using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Dictionary<string, List<string>> _phoneUrlMap = new Dictionary<string, List<string>>();
        private const int MaxPhoneNumbers = 100;
        private CancellationTokenSource _cts;
        private HashSet<string> _visitedLinks = new HashSet<string>();
        private const int MaxDepth = 2; // 设置最大深度

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("请输入搜索关键词！");
                return;
            }

            _phoneUrlMap.Clear();
            listBoxUrls.Items.Clear();
            lblStatus.Text = "正在搜索...";

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            var tasks = new List<Task>
            {
                SearchBaidu(keyword, token),
                SearchBing(keyword, token)
            };

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("搜索已取消");
            }
            finally
            {
                lblStatus.Text = "搜索完成！";
                DisplayResults();
            }
        }

        private async Task SearchBaidu(string keyword, CancellationToken token)
        {
            var url = $"https://www.baidu.com/s?wd={keyword}";
            await CrawlUrl(url, token);
        }

        private async Task SearchBing(string keyword, CancellationToken token)
        {
            var url = $"https://www.bing.com/search?q={keyword}";
            await CrawlUrl(url, token);
        }

        private async Task CrawlUrl(string url, CancellationToken token, int currentDepth = 0)
        {
            if (string.IsNullOrEmpty(url) || !Uri.IsWellFormedUriString(url, UriKind.Absolute) || currentDepth > MaxDepth)
            {
                return;
            }

            if (_visitedLinks.Contains(url))
            {
                return; // 如果已经访问过，直接返回
            }

            _visitedLinks.Add(url); // 记录已访问的链接

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetStringAsync(url);
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("任务被取消");
                        return;
                    }

                    ExtractPhoneNumbers(response, url);

                    var resultLinks = ExtractResultLinks(response);
                    foreach (var link in resultLinks)
                    {
                        if (token.IsCancellationRequested)
                        {
                            Console.WriteLine("任务被取消");
                            return;
                        }
                        // 递归调用，增加深度
                        await CrawlUrl(link, token, currentDepth + 1);
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"请求错误: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"错误: {ex.Message}");
                }
            }
        }

        private List<string> ExtractResultLinks(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var links = doc.DocumentNode.SelectNodes("//a[@href]")
                          .Select(node => node.GetAttributeValue("href", ""))
                          .Where(href => href.StartsWith("http")).Distinct().ToList();
            return links;
        }

        private void ExtractPhoneNumbers(string html, string url)
        {
            try
            {
                var regex = new Regex(@"\b(\+?\d{1,3}[-.\s]?)?(\(?\d{2,3}\)?[-.\s]?)?\d{3}[-.\s]?\d{4}\b");
                var matches = regex.Matches(html);

                foreach (Match match in matches)
                {
                    if (_phoneUrlMap.Count >= MaxPhoneNumbers)
                    {
                        _cts.Cancel();
                        break; // 如果达到最大数量，取消所有任务
                    }

                    string normalizedPhoneNumber = NormalizePhoneNumber(match.Value);
                    Console.WriteLine($"找到电话号码: {normalizedPhoneNumber}");
                    if (!_phoneUrlMap.ContainsKey(normalizedPhoneNumber))
                    {
                        // 如果电话号码不存在，初始化URL列表
                        _phoneUrlMap[normalizedPhoneNumber] = new List<string> { url };
                    }
                    else if (!_phoneUrlMap[normalizedPhoneNumber].Contains(url))
                    {
                        // 如果电话号码已存在，但URL尚未添加，则添加URL
                        _phoneUrlMap[normalizedPhoneNumber].Add(url);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"提取电话号码时发生错误: {ex.Message}");
            }
        }

        private string NormalizePhoneNumber(string phoneNumber)
        {
            return Regex.Replace(phoneNumber, @"[^\d]", ""); // 仅保留数字
        }

        private void DisplayResults()
        {
            int index = 1; // 初始化计数器
            foreach (var kvp in _phoneUrlMap)
            {
                string phone = kvp.Key;
                string urls = string.Join(", ", kvp.Value);
                listBoxUrls.Items.Add($"第{index}个电话号码: {phone} url :   {urls}");
                index++; // 递增计数器
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
        }

        private void listBoxUrls_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
