using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace WPFDataGridGettingStartedNETFramework {
    public class ViewModel : ViewModelBase {
        NorthwindEntities northwindDBContext;

        public ObservableCollection<Order> Orders {
            get => GetValue<ObservableCollection<Order>>();
            private set => SetValue(value);
        }
        public ObservableCollection<Shipper> Shippers {
            get => GetValue<ObservableCollection<Shipper>>();
            private set => SetValue(value);
        }

        public ViewModel() {
            northwindDBContext = new NorthwindEntities();

            if(IsInDesignMode) {
                Orders = new ObservableCollection<Order>();
                Shippers = new ObservableCollection<Shipper>();
            } else {
                northwindDBContext.Orders.Load();
                Orders = northwindDBContext.Orders.Local;

                northwindDBContext.Shippers.Load();
                Shippers = northwindDBContext.Shippers.Local;
            }
        }

        [Command]
        public void ValidateAndSave(RowValidationArgs args) {
            northwindDBContext.SaveChanges();
        }
    }
}
