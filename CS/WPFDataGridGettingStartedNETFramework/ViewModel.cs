using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace WPFDataGridGettingStartedNETFramework {
    public class ViewModel : ViewModelBase {

        NorthwindEntities northwindDBContext;
        public ViewModel() {
            if (IsInDesignMode) {
                Orders = new ObservableCollection<Order>();
                Shippers = new ObservableCollection<Shipper>();
            }
            else {
                northwindDBContext = new NorthwindEntities();

                northwindDBContext.Orders.Load();
                Orders = northwindDBContext.Orders.Local;

                northwindDBContext.Shippers.Load();
                Shippers = northwindDBContext.Shippers.Local;
            }
            ValidateAndSaveCommand = new DelegateCommand(ValidateAndSave);
        }
        public ObservableCollection<Order> Orders {
            get => GetValue<ObservableCollection<Order>>();
            private set => SetValue(value);
        }
        public ObservableCollection<Shipper> Shippers {
            get => GetValue<ObservableCollection<Shipper>>();
            private set => SetValue(value);
        }
        public DelegateCommand ValidateAndSaveCommand { get; }
        void ValidateAndSave() {
            northwindDBContext.SaveChanges();
        }
    }
}
