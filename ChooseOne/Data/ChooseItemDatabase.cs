using ChooseOne.Models;
using SQLite;


namespace ChooseOne.Data;

public class ChooseItemDatabase
{
    SQLiteAsyncConnection Database;
    public ChooseItemDatabase() 
    { 
    }

    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await
            Database.CreateTableAsync<ProjectItem>();
    }
    public async Task<List<ProjectItem>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<ProjectItem>().ToListAsync();
    }


    public async Task<ProjectItem> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<ProjectItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(ProjectItem item)
    {
        await Init();
        if (item.ID != 0)
        {
            return await Database.UpdateAsync(item);
        }
        else
        {
            return await Database.InsertAsync(item);
        }
    }

    public async Task<int> DeleteItemAsync(ProjectItem item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }


}
