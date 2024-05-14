# IssuesApi-Practice
IssuesAPIを取得、必要に応じてIssusのページから必要な情報を取得する

下記の実装を参考にIssuesAPIを取得、必要に応じてIssusのページから必要な情報を取得する
* https://github.com/kazenetu/BaseIssuesChecker
* https://github.com/kazenetu/AngleSharp-Practice

## 実行環境
下記フォルダに移動して実行を行う
* .NET6: dotnet6
* .NET7: dotnet7
* .NET8: dotnet8

## 実行
```
dotnet run "IssuesAPIUrl" "IssuesPageMailestoneQuery"
```
* IssuesAPIUrl  
   Issues取得APIのURL
* IssuesPageMailestoneQuery  
   IssuesページからMailestone名を取得するためのQuery
   (IssuesページはIssues取得APIで取得するURLを使われる)