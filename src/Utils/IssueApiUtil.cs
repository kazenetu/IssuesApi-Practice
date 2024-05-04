using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace Utils
{
    /// <summary>
    /// API呼び出しユーティリティ
    /// </summary>
    public class IssueApiUtil
    {
        private string _uri = "";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IssueApiUtil(string uri)
        {
            this._uri = uri;
        }

        /// <summary>
        /// Issuesリストをネットワークから取得する
        /// </summary>
        /// <returns>Issuesリスト</returns>
        public List<JsonIssue> GetIssues()
        {
            var json = string.Empty;
            using (var client = new HttpClient())
            {
                var response =
                    client.GetAsync(this._uri).Result.Content.ReadAsStringAsync();
                json = response.Result;
            }
            var result = JsonSerializer.Deserialize<List<JsonIssue>>(json);
            if(result is null)
            {
                return new List<JsonIssue>();
            }
            return result;
        }
    }
}
