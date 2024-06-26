using System.Text;

namespace Utils
{
  /// <summary>
  /// Json用Isuueエンティティ
  /// </summary>
  public class JsonIssue
  {
    public int? number { set; get; }
    public string? title { set; get; }
    public JsonUser? user { set; get; }
    public string? state { set; get; }
    public DateTimeOffset? created_at { set; get; }
    public DateTimeOffset? updated_at { set; get; }
    public string? body { set; get; }
    public int? id { set; get; }
    public string? comments_url { set; get; }
    public string? html_url { set; get; }
    public string? mailestone { set; get; }

    public override string ToString()
    {
      var results = new StringBuilder();
      var properties = typeof(JsonIssue).GetProperties();
      foreach (var property in properties)
      {
        var value = property.GetValue(this);
        results.AppendLine($"{property.Name}:{value}");
      }
      return results.ToString();
    }
  }
}