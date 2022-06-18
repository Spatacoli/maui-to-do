using SQLite;
using maui_to_do.Models;

namespace maui_to_do.Services;

public class ActionItemRepository
{
    string _dbPath;

    public string StatusMessage { get; set; }

    SQLiteAsyncConnection conn;

    private void Init()
    {
        if (conn != null) return;

        conn = new SQLiteAsyncConnection(_dbPath);
        conn.CreateTableAsync<ActionItem>();
    }

    public ActionItemRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public async Task AddNewActionItemAsync(string title, bool isComplete)
    {
        int result = 0;
        try
        {
            Init();

            if (string.IsNullOrEmpty(title))
                throw new Exception("Valid title required");

            result = await conn.InsertAsync(new ActionItem
            {
                Title = title,
                IsCompleted = isComplete,
            });

            StatusMessage = string.Format("{0} record(s) added", result);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add. Error: {0}", ex.Message);
        }
    }

    public async Task<List<ActionItem>> GetAllActionItemsAsync()
    {
        try
        {
            Init();
            return await conn.Table<ActionItem>().ToListAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }
        return new List<ActionItem>();
    }
}
