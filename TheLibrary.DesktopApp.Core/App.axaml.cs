using System;
using System.Collections.Generic;
using System.Configuration;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DynamicData.Binding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TheLibrary.CardDatabase;
using TheLibrary.CardDatabase.Models;
using TheLibrary.CardDatabase.Repositories;
using TheLibrary.DesktopApp.Core.Services;
using TheLibrary.DesktopApp.Core.ViewModels;
using TheLibrary.DesktopApp.Core.Views;

namespace TheLibrary.DesktopApp.Core;

public partial class App : Application
{
  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
    
    IConfiguration config = BuildConfiguration();
    CardDbInitializeService cardDbInitializeService = new CardDbInitializeService(config);
  }

  private IConfiguration BuildConfiguration()
  {
    var configurationBuilder = new ConfigurationBuilder()
      .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
      .AddJsonFile("appsettings.json", false, true);

    return configurationBuilder.Build();
  }


  public override void OnFrameworkInitializationCompleted()
  {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
      desktop.MainWindow = new MainWindow
      {
        DataContext = new MainWindowViewModel(new ObservableCollectionExtended<CardDbViewModel>()),
      };
    }

    base.OnFrameworkInitializationCompleted();
  }
}