using PracticeShop.DbEnti;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Data.Entity;
using PracticeShop.Model;

namespace PracticeShop.ViewModel
{
    public class MainWindowVM : BaseVM

    {

        private ObservableCollection<Goods> _goodsInfo;
        
        private ObservableCollection<Manufacturer> _manuInfo;
        private Goods _selectedGood;

        public ObservableCollection<Goods> Goods
        {
            get => _goodsInfo;
            set
            {
                _goodsInfo = value;
                OnPropertyChanged(nameof(Goods));

            }
        }

        public ObservableCollection<Manufacturer> Manufacturer
        {
            get => _manuInfo;
            set
            {
                _manuInfo = value;
                OnPropertyChanged(nameof(Manufacturer));

            }
        }

        public Goods SelectedGoods
        {
            get => _selectedGood;
            set
            {
                _selectedGood = value;
                OnPropertyChanged(nameof(SelectedGoods));
            }
        }

        public MainWindowVM()
        {
            RebindData();
            SetTimer();

        }

        public void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            RebindData();
        }




        public void RebindData()
        {

            Goods = new ObservableCollection<Goods>();
            LoadData();
        }




        private void SetTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        public void DeleteSelectItem()
        {
            if (!(SelectedGoods is null))
            {
                using (var db = new TradeEntities1())
                {

                    var result = MessageBox.Show("Вы действительно хотите удалить выбранный товар?" +
                        "Это действие невозможно отменить.", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            var entityForDelete = db.Goods.Where(elem => elem.Articul == SelectedGoods.Articul).FirstOrDefault();

                            db.Goods.Remove(entityForDelete);

                            db.SaveChanges();

                            LoadData();

                            MessageBox.Show("Рейс успешно удален", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }

                }
            }
        }

       


        public void LoadData()
        {
           

            var result = AppData.db.Goods.Include(e=>e.Manufacturer).ToList();

            result.ForEach(elem => Goods?.Add(elem));
        }


    }

}
