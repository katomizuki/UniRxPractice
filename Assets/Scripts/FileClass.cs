using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class FileClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        var filePath = "aaa";
        // StreamReaderでfilePathを指定してファイルを開ける。EndOfStremで最後まで読み込ませるまで処理をして、
        // ReaLineメソッドで一行ずつ

        var sw = new StreamWriter(filePath);
        // streamWriter()を使用することで指定したfilePathにテキストを出力できる。
//ファイル出力用クラスになっている。
        var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

        // FileInfoからファイル情報を参照できる。
        var file = new FileInfo(filePath);
        if (File.Exists(filePath))
        {
            // 一気に読み込む
            var lines = File.ReadAllLines(filePath, Encoding.UTF8);
            using (var reader = new StreamReader(filePath, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }
        }
    }
}
