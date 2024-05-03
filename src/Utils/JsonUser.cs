using System.Text;

namespace Utils
{
  /// <summary>
  /// Json用ユーザーエンティティ
  /// </summary>
  public class JsonUser
  {
    public string? login { set; get; }
    public string? email { set; get; }
    public string? type { set; get; }
    public bool? site_admin { set; get; }
    public DateTimeOffset? created_at { set; get; }
    public int? id { set; get; }
    public string? url { set; get; }
    public string? html_url { set; get; }
    public string? avatar_url { set; get; }

    public override string ToString()
    {
      var results = new StringBuilder();
      var properties = typeof(JsonUser).GetProperties();
      foreach (var property in properties)
      {
        var value = property.GetValue(this);
        results.Append($"{property.Name}:{value} ");
      }
      return results.ToString();
    }
  }
}