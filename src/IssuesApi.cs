using AngleSharp;
using Utils;

/// <summary>
/// IssuesApiエントリクラス
/// </summary>
public class IssuesApi
{
    /// <summary>
    /// IssuesAPIを呼び出し
    /// 必要に応じてIssuesページからマイルストーンを取得する
    /// </summary>
    /// <param name="uri">IssuesAPI</param>
    /// <param name="query">Issuesページからマイルストーン取得用クエリ</param>
    /// <returns>Issuesリスト</returns>
    public static List<JsonIssue> GetIssuesApi(string uri, string query)
    {
        var issueApiUtil = new IssueApiUtil(uri);

        var issues = issueApiUtil.GetIssues();
        foreach(var issue in issues)
        {
            if(string.IsNullOrEmpty(issue.mailestone) && !string.IsNullOrEmpty(issue.html_url))
            {
                var issuePageResults = GetQueryResults(issue.html_url, query).Result;
                issue.mailestone = issuePageResults.FirstOrDefault();
            }
        }
        return issues;
    }

    /// <summary>
    /// URLからqueryの値を取得
    /// </summary>
    /// <param name="url">url</param>
    /// <returns>IDocumentインスタンス</returns>
    private static async Task<List<string>> GetQueryResults(string url, string query)
    {
        var config = Configuration.Default
            .WithDefaultLoader();

        using var context = BrowsingContext.New(config);

        // URLを開く
        var doc = await context.OpenAsync(url);

        // 対象を取得
        var elements = doc.QuerySelectorAll(query)
            .Select(x => x.TextContent)
            .ToList();

        return elements;
    }
}