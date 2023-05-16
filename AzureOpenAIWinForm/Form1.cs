using Azure;
using Azure.AI.OpenAI;
using System.Text;
using System.Windows.Forms;

namespace AzureOpenAIWinForm
{
    public partial class Form1 : Form
    {

        private string apiKey = "***";
        private string endpoint = "https://***/";
        private string modelName = "gpt-35";
        private OpenAIClient client;
        private ChatCompletionsOptions completionsOptions;

        public Form1()
        {
            InitializeComponent();
            client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            completionsOptions = new ChatCompletionsOptions
            {
                Messages =
                {
                    new ChatMessage(ChatRole.System, "����һ�������Ů�����ó������Ե����Թ����������ˣ�������������˽���Ȱο������һ�㣬���ﻯһЩ��"),
                    new ChatMessage(ChatRole.User, "���"),
                }
            };
            Answer();
        }
        private async void Answer() {
            this.btnSendMsg.Enabled = false;

            //this.txtRichChat.SelectionColor = Color.Blue;
            this.txtRichChat.AppendText("��: ");

            var completionsResponse = await client.GetChatCompletionsStreamingAsync(
                modelName,
                completionsOptions
            );
            var resonseText = new StringBuilder();
            await foreach (var choice in completionsResponse.Value.GetChoicesStreaming())
            {
                await foreach (var message in choice.GetMessageStreaming())
                {
                    resonseText.Append(message.Content);
                    await Task.Delay(TimeSpan.FromMilliseconds(100));
                    //Console.Write(message.Content);
                    this.txtRichChat.AppendText(message.Content);
                }
            }
            this.txtRichChat.AppendText("\r\n");
            completionsOptions.Messages.Add(new ChatMessage(ChatRole.Assistant, resonseText.ToString()));

            this.btnSendMsg.Enabled = true;

        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            var userMessage = this.txtMsg.Text;
            if (userMessage.Trim() == "")
            {
                MessageBox.Show("����������");
                return;
            }
            this.txtRichChat.SelectionColor = Color.Red;
            this.txtRichChat.AppendText("��: ");
            this.txtRichChat.AppendText(userMessage+"\r\n");
            completionsOptions.Messages.Add(new ChatMessage(ChatRole.User, userMessage));
            this.txtMsg.Text="";
            Answer();
        }
    }
}