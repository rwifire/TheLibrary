using System.Collections.ObjectModel;
using DynamicData.Binding;

namespace TheLibrary.DesktopApp.Core.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
  public IObservableCollection<CardDbViewModel> AllCards { get; private set; }

  public MainWindowViewModel(IObservableCollection<CardDbViewModel> cards)
  {
    AllCards = cards;
  }
}