using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using TheLibrary.DesktopApp.Core.ViewModels;
using TheLibrary.DesktopApp.Core.Views;

namespace TheLibrary.DesktopApp.Core;

public partial class App : Application
{
  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
  }

  public override void OnFrameworkInitializationCompleted()
  {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
      desktop.MainWindow = new MainWindow
      {
        DataContext = new MainWindowViewModel(),
      };
    }

    base.OnFrameworkInitializationCompleted();
  }
}