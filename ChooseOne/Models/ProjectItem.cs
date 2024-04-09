using SQLite;



namespace ChooseOne.Models;

public class ProjectItem
{
    [PrimaryKey,AutoIncrement]
    public int ID { get; set; }
    public string Project { get; set; } = "";
    public int Weight { get; set; } = 1;

}
