using PAIN_wpf.Model;
using System.Windows;

namespace PAIN_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MVVM.IWindowService WindowService { get; } = new MVVM.WindowService();
        private SongLibraryModel songLibraryModel { get; } = new SongLibraryModel();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ViewModel.SongLibraryViewModel songLibraryViewModel = new ViewModel.SongLibraryViewModel(songLibraryModel);
            WindowService.Show(songLibraryViewModel); 
        }
    }
}
