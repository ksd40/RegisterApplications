using RegisterApplications.Commands;
using RegisterApplications.Models;
using RegisterApplications.Extensions;
using RegisterApplications.Repositories;
using RegisterApplications.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace RegisterApplications.ViewModels
{
    internal class RegisterAppViewModel : ViewModel
    {
        private string _filter;
        private BidViewModel _selectedBid;
        private readonly IBidsRepository _bidRepository;
        private ObservableCollection<BidViewModel> _bids;

        public CollectionViewSource BidFilter { get; set; }
        public ICommand AddBidCommand { get; }
        public ICommand DeleteBidCommand { get; }
        public ICommand EditBidCommand { get; }
        public ICommand SubmitBidCommand { get; }
        public ICommand CompleteBidCommand { get; }
        public ICommand CancelBidCommand { get; }

        public BidViewModel SelectedBid 
        { 
            get => _selectedBid; 
            set => Set(ref _selectedBid, value); 
        }

        public ObservableCollection<BidViewModel> Bids
        {
            get => _bids;
            set => Set(ref _bids, value);
        }
        public string Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                OnFilterChanged();
            }
        }
        public ICollectionView BidView
        {
            get { return BidFilter.View; }
        }

        public RegisterAppViewModel()
        {
            _bidRepository = new BidsRepository();
            _bids = new ObservableCollection<BidViewModel>(_bidRepository.GetAll().Select(bid => bid.ToViewModel()));

            BidFilter = new CollectionViewSource
            {
                Source = Bids
            };
            BidFilter.Filter += ApplyFilter;

            AddBidCommand = new LambdaCommand(AddBid, CanAddBid);
            DeleteBidCommand = new LambdaCommand(DeleteBid, CanDeleteBid);
            EditBidCommand = new LambdaCommand(EditBid, CanEditBid);
            SubmitBidCommand = new LambdaCommand(SubmitBid, CanSubmitBid);
            CompleteBidCommand = new LambdaCommand(CompleteBid, CanCompleteBid);
            CancelBidCommand = new LambdaCommand(CancelBid, CanCancelBid);
        }

        private bool CanAddBid(object? p) => true;
        private void AddBid(object? p)
        {
            var addBidViewModel = new AddBidViewModel();
            var addBidWindow = new AddBidWindow(addBidViewModel);
            var dialogResult = addBidWindow.ShowDialog();

            var newBid = addBidViewModel.CreateBid();
            if (dialogResult.Value)
            {
                var bid = _bidRepository.Add(newBid.ToBid());
                Bids.Add(bid.ToViewModel());
                MessageBox.Show("Заявка успешно добавлена!");
            }
        }

        private bool CanDeleteBid(object? p)
        {
            return SelectedBid != null 
                   && (SelectedBid.Status == Status.New || SelectedBid.Status == Status.Done);
        }

        private void DeleteBid(object? p)
        {
            _bidRepository.Delete(SelectedBid.ToBid());
            Bids.Remove(SelectedBid);
            MessageBox.Show("Заявка успешно удалена!");
        }

        private bool CanEditBid(object? p)
        {
            return SelectedBid != null && SelectedBid.Status == Status.New;
        }

        private void EditBid(object? p)
        {
            var editBidViewModel = new EditBidViewModel(SelectedBid);
            var editBidWindow = new EditBidWindow(editBidViewModel);
            var dialogResult = editBidWindow.ShowDialog();

            if (dialogResult.Value)
            {
                _bidRepository.Update(SelectedBid.ToBid());
                MessageBox.Show("Заявка отредактирована!");
            }
        }

        private bool CanSubmitBid(object? p)
        {
            return SelectedBid != null && (SelectedBid.Status == Status.New);
        }
        private void SubmitBid(object? p)
        {
            var choiceCourierViewModel = new ChoiceCourierViewModel();
            var editBidWindow = new ChoiceCourierWindow(choiceCourierViewModel);
            var dialogResult = editBidWindow.ShowDialog();

            if (dialogResult.Value)
            {
                SelectedBid.CourierId = choiceCourierViewModel.Courier.Id;
                SelectedBid.Courier = choiceCourierViewModel.Courier;
                SelectedBid.Status = Status.InProgress;
                _bidRepository.Update(SelectedBid.ToBid());
                MessageBox.Show("Заявка отправлена на выполнение!");
            }
            
        }

        private bool CanCompleteBid(object? p)
        {
            return SelectedBid != null && (SelectedBid.Status == Status.InProgress);
        }
        private void CompleteBid(object? p)
        {
            SelectedBid.Status = Status.Done;
            _bidRepository.Update(SelectedBid.ToBid());
            MessageBox.Show("Заявка успешно выполнена!");
        }

        private bool CanCancelBid(object? p)
        {
            return SelectedBid != null && (SelectedBid.Status == Status.InProgress);
        }
        private void CancelBid(object? p)
        {
            var addCommentViewModel = new AddCommentViewModel();
            var editBidWindow = new AddCommentWindow(addCommentViewModel);
            var dialogResult = editBidWindow.ShowDialog();

            if (dialogResult.Value)
            {
                SelectedBid.Comment = addCommentViewModel.Comment;
                SelectedBid.Status = Status.Canceled;
                _bidRepository.Update(SelectedBid.ToBid());
                MessageBox.Show("Заявка отменена!");
            }
        }

        private void OnFilterChanged()
        {
            BidFilter.View.Refresh();
        }

        private void ApplyFilter(object sender, FilterEventArgs e)
        {
            BidViewModel field = (BidViewModel)e.Item;

            if (string.IsNullOrWhiteSpace(Filter) || Filter.Length == 0)
            {
                e.Accepted = true;
            }   
            else
            {
                e.Accepted = field.Name.ToLower().Contains(Filter.ToLower()) 
                                || field.Sender.ToLower().Contains(Filter.ToLower()) 
                                || field.Recipient.ToLower().Contains(Filter.ToLower()) 
                                || field.Cargo.ToLower().Contains(Filter.ToLower()) 
                                || field.Status.ToString().ToLower().Contains(Filter.ToLower());
            }
        }  
    }
}
