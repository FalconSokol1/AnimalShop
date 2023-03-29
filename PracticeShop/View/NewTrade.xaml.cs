using PracticeShop.DbEnti;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PracticeShop.View
{
    /// <summary>
    /// Логика взаимодействия для NewTrade.xaml
    /// </summary>
    public partial class NewTrade : Window
    {
        private Goods _goodsInfo;

        public NewTrade(Goods goods)
        {
            

            if (goods != null)
            {
                _goodsInfo = goods = new Goods();
            }
            else
            {
                _goodsInfo = goods;
            }

        }



        private void BtnOk(object sender, RoutedEventArgs e)
        {

            using (var db = new TradeEntities1())
            {
                try
                {
                    var validateResult = ValidateEntity();

                    if (validateResult.Length > 0)
                    {
                        MessageBox.Show(validateResult.ToString(), "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    db.Goods.AddOrUpdate(_goodsInfo);

                    db.SaveChanges();

                    MessageBox.Show("Товар добавлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                    (Owner as MainWindow)?.RefreshData();

                    Owner.Focus();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }


        }
        private StringBuilder ValidateEntity()
        {
            var errors = new StringBuilder();

            if (_goodsInfo != null)
            {
                if (string.IsNullOrEmpty(_goodsInfo.Articul.ToString()))
                {
                    errors.AppendLine("Поле наименование 'Articul' не может быть пустым!");
                }

                if (string.IsNullOrEmpty(_goodsInfo.ProductName))
                {
                    errors.AppendLine("Поле наименование 'ProductName' не может быть пустым!");
                }

                if (string.IsNullOrEmpty(_goodsInfo.Price.ToString()))
                {
                    errors.AppendLine("Поле наименование 'Место отправления' не может быть пустым!");
                }

                if (string.IsNullOrEmpty(_goodsInfo.MaxDiscount.ToString()))
                {
                    errors.AppendLine("Поле наименование'MaxDiscount' не может быть пустым!");
                }

                if (string.IsNullOrEmpty(_goodsInfo.CurrentDiscount.ToString()))
                {
                    errors.AppendLine("Поле наименование 'CurrentDiscount' не может быть пустым!");
                }

                if (string.IsNullOrEmpty(_goodsInfo.StorageAmount.ToString()))
                {
                    errors.AppendLine("Поле наименование 'StorageAmount' не может быть пустым!");
                }
                if (string.IsNullOrEmpty(_goodsInfo.Description))
                {
                    errors.AppendLine("Поле наименование 'Description' не может быть пустым!");
                }

            }

            return errors;
        }


    }

}
