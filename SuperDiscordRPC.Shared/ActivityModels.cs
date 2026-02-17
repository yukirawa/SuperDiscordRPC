namespace SuperDiscordRPC.Shared
{
    // スマホとPCでやり取りするデータの型
    public class ActivityStatus
    {
        public bool IsActive { get; set; } = false;
        public string AppName { get; set; } = "";   // YouTube, Game etc.
        public string Details { get; set; } = "";   // 動画タイトル
        public string State { get; set; } = "";     // チャンネル名
        public long Timestamp { get; set; } = 0;    // 開始時間
    }
}