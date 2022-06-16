using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_to_do.Models;
using maui_to_do.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace maui_to_do.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<ActionItem> Items { get; } = new();

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private bool isComplete;

    private ActionItemRepository Repo;

    public MainViewModel(ActionItemRepository air)
    {
        Repo = air;
    }

    [RelayCommand]
    async void GetActionItems()
    {
        Items.Clear();
        var ai = await Repo.GetAllActionItemsAsync();

        foreach (var item in ai)
        {
            Items.Add(item);
        }
    }

    [RelayCommand]
    async void AddActionItem()
    {
        await Repo.AddNewActionItemAsync(Title, IsComplete);
        Title = string.Empty;
        IsComplete = false;
    }
}
