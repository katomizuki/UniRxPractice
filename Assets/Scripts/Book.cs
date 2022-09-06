using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Book : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        var books = new List<BookSample>
        {
            new BookSample(title: "心", price: 300, 1),
            new BookSample(title: "心", price: 300, 1),
            new BookSample(title: "心", price: 300, 1),
            new BookSample(title: "心", price: 300, 1),
        };
        // Listに変換。
        var numbers = Enumerable.Repeat(1, 20).ToList();
// 配列に連続した値を設定する。 
        var array = Enumerable.Range(1, 20).ToArray();
// int配列の平均を出す。
        var average = array.Average();
        // オブジェクト配列の可能
        var ave = books.Average(book => book.Price);
        // 合計
        var total = array.Sum();
        // 最小値
        var min = books.Min(book => book.Price);
        // 条件に一致する要素のカウント
        var count = numbers.Count(n => n == 0);
        // 条件に当てはまる要素があるかどうか調べる。
        bool exists = numbers.Any(n => n == 0);
        // 条件が全て当てはまるかどうか調べる
        bool all = numbers.All(n => n == 0);
        // 配列が等しいかどうか調べる
        numbers.SequenceEqual(array);
        // 当てはまる要素の最初を取り出す。なければnullを返す
        var num = numbers.FirstOrDefault(n => n == 0);
        // 条件に一致する最初のインデックス
        var index = numbers.FindIndex(n => n < 0);
        // 複数の要素をn個取り出す
        var n = numbers.Where(n => n == 0).Take(5);
        // 条件に当てはまった値だけ取り出す
        var selected = books.TakeWhile(x => x.Price > 500);
        // 逆に読み飛ばす
        var skipped = books.SkipWhile(n => n.Pages >= 0).ToList();
        numbers.ForEach(Console.WriteLine);
// mapメソッド的にコレクションを生成
        var words = numbers.Select(n => n.ToString()).ToArray();
        // 重複を削除
        var distinct = words.Distinct();
        // ソート
        var sort = numbers.OrderBy(x => x);
        // コレクションの連結
        var allFiles = numbers.Concat(n);
        // タイプobject
        Type type = typeof(BookSample);
        // 型情報に取得
        Type ty = books.GetType();



    }
}

class BookSample
{
    public string Title { get; set; }
    public int Price { get; set; }
    public int Pages { get; set; }

    public BookSample(string title, int price, int pages)
    {
        this.Title = title;
        this.Price = price;
        this.Pages = pages;
    }
}