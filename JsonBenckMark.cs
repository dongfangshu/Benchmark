using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
[CategoriesColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class JsonBenckMark<T> where T : class,new()
{
    T Value;
    string jsonUtilityJson;
    string jsonNewton;
    string litjson;
    string utf8Json;
    string catJson;
    string messagePackJson;
    public JsonBenckMark()
    {
        Value = ModelHelper.GetTest1Data<T>();
        jsonUtilityJson = System.Text.Json.JsonSerializer.Serialize(Value);
        var jsonUtilityObj = System.Text.Json.JsonSerializer.Deserialize<T>(jsonUtilityJson);
        bool result = Value.Equals(jsonUtilityObj);
        Console.WriteLine($"JsonSerializer Length:{jsonUtilityJson.Length} result:{result}");

        jsonNewton = Newtonsoft.Json.JsonConvert.SerializeObject(Value);
        var NewtonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonNewton);
        result = Value.Equals(NewtonObj);
        Console.WriteLine($"Newtonsoft Length:{jsonNewton.Length} result:{result}");

        litjson = LitJson.JsonMapper.ToJson(Value);
        var litjsonObj = LitJson.JsonMapper.ToObject(litjson);
        result = Value.Equals(litjsonObj);
        Console.WriteLine($"LitJson Length:{litjson.Length} result:{result}");

        utf8Json = Utf8Json.JsonSerializer.ToJsonString(Value);
        var utf8JsonObj = Utf8Json.JsonSerializer.Deserialize<T>(utf8Json);
        result = Value.Equals(utf8JsonObj);
        Console.WriteLine($"Utf8Json Length:{utf8Json.Length} result:{result}");

        //catJson = CatJson.JsonParser.Default.ToJson(Value);
        //var catJsonObj = CatJson.JsonParser.Default.ParseJson<T>(catJson);
        //result = Value.Equals(catJsonObj);
        //Console.WriteLine($"CatJson Length:{catJson.Length} result:{result}");

        //messagePackJson = MessagePack.MessagePackSerializer.SerializeToJson(Value);
        //MessagePack.MessagePackSerializer.json
        //var MessagePackObj = MessagePack.MessagePackSerializer.Deserialize<T>(messagePackJson);
        //result = Value.Equals(utf8JsonObj);
        //Console.WriteLine($"Utf8Json Length:{utf8Json.Length} result:{result}");
    }
    [Benchmark,BenchmarkCategory("Serialize","Json")]
    public void JsonUtility_Serialize()
    {
        System.Text.Json.JsonSerializer.Serialize(Value);
    }
    [Benchmark, BenchmarkCategory("Deserialize", "Json")]
    public void JsonUtility_Deserialize()
    {
        System.Text.Json.JsonSerializer.Deserialize<T>(jsonUtilityJson);
    }

    [Benchmark, BenchmarkCategory("Serialize", "Json")]
    public void Newtonsoft_Serialize()
    {
        Newtonsoft.Json.JsonConvert.SerializeObject(Value);
    }
    [Benchmark, BenchmarkCategory("Deserialize", "Json")]
    public void Newtonsoft_Deserialize()
    {
        Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonNewton);
    }

    [Benchmark, BenchmarkCategory("Serialize", "Json")]
    public void LitJson_Serialize()
    {
        LitJson.JsonMapper.ToJson(Value);
    }
    [Benchmark, BenchmarkCategory("Deserialize", "Json")]
    public void LitJson_Deserialize()
    {
        LitJson.JsonMapper.ToObject(litjson);
    }

    [Benchmark, BenchmarkCategory("Serialize", "Json")]
    public void Utf8Json_Serialize()
    {
        Utf8Json.JsonSerializer.ToJsonString(Value);
    }
    [Benchmark, BenchmarkCategory("Deserialize", "Json")]
    public void Utf8Json_Deserialize()
    {
        Utf8Json.JsonSerializer.Deserialize<T>(utf8Json);
    }

    //[Benchmark, BenchmarkCategory("Serialize", "Json")]
    //public void CatJson_Serialize()
    //{
    //    CatJson.JsonParser.Default.ToJson(Value);
    //}
    //[Benchmark, BenchmarkCategory("Deserialize", "Json")]
    //public void CatJson_Deserialize()
    //{
    //    CatJson.JsonParser.Default.ParseJson<T>(catJson);
    //}
}
