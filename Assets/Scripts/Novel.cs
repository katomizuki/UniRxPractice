using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;

public partial class Novel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[DataContract(Name = "novel")]
public partial class Novel
{
    [DataMember(Name = "title")]
    public string Title { get; set; }
    
    [DataMember(Name = "published")]
    public string Author { get; set; }
    
    [DataMember(Name = "published")]
    public int Published { get; set; }

    public override string ToString()
    {
        return "";
    }
    
    
}

// public class Novel2
// {
//     public int Index { get; set; }
//
//     Novel2 novel = new Novel2
//         {
//             Index = 0,
//         };
//
//         using (var stream = new StreamWriter(@"sample.json"))
//         using (var writer = new JsonTextWriter(stream)) {
//         JsonSerializer serialzer = new JsonSerializer
//         {
//             NullValueHandling = NullValueHandling.Ignore,
//             ContractResolver = new CamelCasePropertyNamesContractResolver(),
//         };
//         serialzer.Serialize(writer, novel);
//     }
interface IGreeting
{
    string GetMessage();
}

public class GreetingClass : IGreeting
{
    public string GetMessage()
    {
        return "";
    }
  
}