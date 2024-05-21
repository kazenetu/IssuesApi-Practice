internal class Program
{
    /// <summary>
    /// エントリメソッド
    /// </summary>    
    private static void Main(string[] args)
    {
        // パラメータが不足の場合はヘルプ表示
        if (args.Length < 2)
        {
            Console.WriteLine("dotnet run \"IssuesAPIUrl\" \"query\"");
            Console.WriteLine("  IssuesAPIUrl:IssueAPI url");
            Console.WriteLine("  IssuesPageMailestoneQuery:get mailestone for Issues Page");
            return;
        }

        var url = args[0];
        var query = args[1];

        var issuesResult = IssuesApi.GetIssuesApi(url, query);

        foreach (var issues in issuesResult)
        {
            Console.WriteLine("-------------");
            Console.WriteLine(issues);
        }
    }
}

