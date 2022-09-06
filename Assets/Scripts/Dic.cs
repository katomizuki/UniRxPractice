using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Dic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var flowerDic = new Dictionary<string, int>()
        {
            ["sun"] = 40,
            ["pansy"] = 20,
            ["tulip"] = 1,
            ["dahlia"] = 90,
        };

        int price = flowerDic["rose"];
        flowerDic.Remove("sun");
        var a = flowerDic.Average(x => x.Value);
        var keys = flowerDic.Keys;
        var valus = flowerDic.Values;
        var nums = new List<int>();
        var numDic = nums.ToDictionary(a => a);
        
    }
}

class Abbreviations
{
    private Dictionary<string, string> _dict = new Dictionary<string, string>();
    
    // コンストラクタ
    public Abbreviations()
    {
        var lines = File.ReadAllLines("Abbreviations.txt");
        _dict = lines.Select(line => line.Split("=")).ToDictionary(x => x[0], x => x[1]);
        
    }
    
    // 要素を追加
    public void Add(string abbr, string japanese)
    {
        _dict[abbr] = japanese;
    }
    
    // インデクサ
    public string this[string abbr]
    {
        get
        {
            return _dict.ContainsKey(abbr) ? _dict[abbr] : null;
        }
    }
    
    // 日本語から対応する省略語

    public string ToAbbreviation(string japanese)
    {
        return _dict.FirstOrDefault(x => x.Value == japanese).Key;
    }
    
    public IEnumerable<KeyValuePair<string, string>> FindAll(string substring)
    {
        foreach (var item in _dict)
        {
            if (item.Value.Contains(substring))
            {
                yield return item;
            }
        }
    }
}
