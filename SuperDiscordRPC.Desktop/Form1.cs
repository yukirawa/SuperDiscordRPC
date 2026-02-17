// 【完全防御版 Form1.cs】
using DiscordRPC;
using SuperDiscordRPC.Shared;
using System.Diagnostics;
using System.Text.Json;

namespace SuperDiscordRPC.Desktop
{
    public partial class Form1 : Form
    {
        private DiscordRpcClient? client; // ?をつけてnull許容にする
        private static readonly HttpClient http = new HttpClient();

        // ★自分の環境に合わせて変更
        private const string SERVER_URL = "http://localhost:5050/api/activity";
        private const string DISCORD_ID = "123456789012345678"; // ★ダミーIDのままだと動かないことがあります

        public Form1()
        {
            InitializeComponent();
            InitializeRPC();
        }

        private void InitializeRPC()
        {
            try
            {
                client = new DiscordRpcClient(DISCORD_ID);
                client.Initialize();
            }
            catch
            {
                // 初期化失敗しても握りつぶす（アプリを落とさない）
            }
        }

        // デザイナーのイベント名と一致させる
        private async void rpcTimer_Tick(object sender, EventArgs e)
        {
            // 防御1: コントロールが死んでいたら何もしない
            if (chkEnableRPC == null || lblStatus == null || client == null) return;

            if (!chkEnableRPC.Checked)
            {
                client.ClearPresence();
                lblStatus.Text = "Status: RPC無効";
                return;
            }

            // --- ここから下は変更なし ---
            ActivityStatus? mobile = null;
            if (chkSyncMobile != null && chkSyncMobile.Checked)
            {
                try
                {
                    using var cts = new CancellationTokenSource(1000);
                    var json = await http.GetStringAsync(SERVER_URL, cts.Token);
                    mobile = JsonSerializer.Deserialize<ActivityStatus>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                catch { }
            }

            var rp = new RichPresence()
            {
                Details = "Developing SuperDiscordRPC",
                State = "Visual Studio 2022",
                Assets = new Assets() { LargeImageKey = "vs_icon", LargeImageText = "Coding" }
            };

            if (mobile != null && mobile.IsActive)
            {
                rp.State = $"📱 {mobile.Details}";
                rp.Assets.SmallImageKey = "youtube";
                rp.Assets.SmallImageText = mobile.AppName;
                lblStatus.Text = $"Status: Syncing ({mobile.AppName})";
            }
            else
            {
                lblStatus.Text = "Status: PC Mode";
            }

            client.SetPresence(rp);
        }
    }
}