using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_to_do.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace maui_to_do.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<ActionItem> Items { get; } = new();

    [RelayCommand]
    void GetActionItems()
    {
        if (Items.Count != 0) return;

        Items.Add(new ActionItem
        {
            ID = 0,
            Title = "Install .NET MAUI",
            IsCompleted = true,
        });
        Items.Add(new ActionItem
        {
            ID = 1,
            Title = "Start a Demo App",
            IsCompleted = true,
        });
        Items.Add(new ActionItem
        {
            ID = 2,
            Title = "Make To-Do app",
            IsCompleted = false,
        });
        Items.Add(new ActionItem
        {
            ID = 3,
            Title = "Get To-Do working on Android, iOS, and Mac",
            IsCompleted = false,
        });
    }
}
