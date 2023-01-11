using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UserControlLoadRunTimeInWindow.ViewModel;
internal partial class MainViewModel : ObservableObject
{
    private IList<ObservableObject> ViewModelList;

    private ObservableObject _CurrentView;
    public ObservableObject CurrentView
    {
        get
        {
            return _CurrentView;
        }
        set
        {
            _CurrentView = value;
            OnPropertyChanged(nameof(CurrentView));
        }
    }

    public MainViewModel()
    {
        ViewModelList = new List<ObservableObject>()
        {
            new HomeViewModel(),
            new SettingViewModel()
        };
        _CurrentView = ViewModelList[0];
    }

    [RelayCommand]
    private void ClickHome()
    {
        CurrentView = ViewModelList.First(item => item is HomeViewModel);
    }

    [RelayCommand]
    private void ClickSetting()
    {
        CurrentView = ViewModelList.First(item => item is SettingViewModel);
    }
}
