
using System.Text.Json;
using System.Text.Json.Serialization;

internal class QueryRequestModel {

    private readonly TemplateRequestModel _template;

    public QueryRequestModel(string json)
    {
        _template = JsonSerializer.Deserialize<TemplateRequestModel>(json) ?? new();
    }

    public void SetPrefix(string p) { 
        this._template.prefix = p;
    }
    
    public string BuildQuery() { 
        List<string> q = new(); 
        
        var properties = _template.GetType().GetProperties(); 
        foreach (var prop in properties) { 
            string name = prop.Name; 
            object value = prop.GetValue(_template, null) ?? "";

            foreach (var attr in prop.GetCustomAttributes(false).Select(x=>((JsonPropertyNameAttribute)x).Name).Where(x=> !string.IsNullOrEmpty(x))) { 
                name = attr; 
            }

            q.Add($"{name}={value}");
            //Console.WriteLine($"{name} {value}");
        }

        string query = string.Join("&", q);
        return $"?{query}";

    }
}