using RegisterApplications.Commands;
using RegisterApplications.Models;
using RegisterApplications.Repositories;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace RegisterApplications.ViewModels
{
    public class ChoiceCourierViewModel : ViewModel
    {
        private readonly ICouriersRepository _courierRepository;

        private ObservableCollection<Courier> _couriers;
        public Courier Courier { get; set; }
        public ICommand CloseWindowCommand { get; }

        public ObservableCollection<Courier> Couriers
        {
            get => _couriers;
            set => Set(ref _couriers, value);
        }

        public ChoiceCourierViewModel() 
        {
            _courierRepository = new CouriersRepository();
            Couriers = new ObservableCollection<Courier>(_courierRepository.GetAll());

            CloseWindowCommand = new LambdaCommand(CloseWindow, CanCloseWindow);
        }

        private bool CanCloseWindow(object? p)
        {
            return Courier != null;
        }
        private void CloseWindow(object? p)
        {
            Window window = p as Window;
            window.DialogResult = true;
            window.Close();
        }
    }
}
