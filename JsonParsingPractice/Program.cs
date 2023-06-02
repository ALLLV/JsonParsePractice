namespace JsonParsingPractice;
internal class Program
{
    static readonly string pathMain = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\data.json");
    static readonly string pathNew = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\dataEdit.json");
    static List<Employee> employees = new();
    static async Task Main(string[] args)
    {
        employees = ParseJson(File.ReadAllText(pathMain));
        foreach (var e in employees) e.PhoneNumber = PhoneFormat(e.PhoneNumber);
        await CreateJsonView(pathNew, SortEmployees(employees, 20));
    }

    static Func<string, List<Employee>> ParseJson = json => System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(json);
    static List<Employee> SortEmployees(List<Employee> employee, int length)
       => employees.OrderByDescending(e => int.Parse(e.Salary)).ToList().GetRange(0, length);
    static string PhoneFormat(string phone)
        => string.Format($"+{phone.Substring(0, 1)}({phone.Substring(1, 3)}){phone.Substring(4, 3)}-{phone.Substring(7, 2)}-{phone.Substring(9, 2)}");
    static async Task CreateJsonView(string path, List<Employee> employees)
    {
        string? output = null;
        foreach (var e in employees) output += $"{e.Name} {e.PhoneNumber} {e.Salary}\n";
        File.WriteAllText(path, output);
    }
}