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
                    new ChatMessage(ChatRole.System, "你是一个温柔的女生，擅长用理性的语言鼓励和引导人，对情绪低落的人进行劝慰。温柔一点，口语化一些。"),
                    new ChatMessage(ChatRole.User, "你好"),
                }
            };
            Answer();
        }
        private async void Answer() {
            this.btnSendMsg.Enabled = false;

            //this.txtRichChat.SelectionColor = Color.Blue;
            this.txtRichChat.AppendText("她: ");

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
                MessageBox.Show("请输入文字");
                return;
            }
            this.txtRichChat.SelectionColor = Color.Red;
            this.txtRichChat.AppendText("我: ");
            this.txtRichChat.AppendText(userMessage+"\r\n");
            completionsOptions.Messages.Add(new ChatMessage(ChatRole.User, userMessage));
            this.txtMsg.Text="";
            Answer();
        }
    }
}