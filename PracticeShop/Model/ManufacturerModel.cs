using PracticeShop.DbEnti;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShop.Model
{
    public class ManufacturerModel : Manufacturer
    {
        public int ID { get; set; }
        public new string ManufacturerName { get; set; }

        public ObservableCollection<Manufacturer> ManufacturerList { get; set; }

    }
}
