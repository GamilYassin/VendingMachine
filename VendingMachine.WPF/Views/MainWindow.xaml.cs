using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VendingMachine.DataAccess.Repositories;
using VendingMachine.DataAccess.Tables;
using VendingMachine.Domain.Models;
using VendingMachine.Services.Utils;

namespace VendingMachine.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInsertVendingMachine_Click(object sender, RoutedEventArgs e)
        {
            PreFillVendingMachines();
        }

        private void PreFillVendingMachines()
        {
            VendingMachineTableRecord vmRecord1 = new VendingMachineTableRecord() {
                Id = 1,
                BalanceText = Balance.TwentyDollar.Encode(),
                Frequency = 60,
                GrandBalance = Balance.TwentyDollar.ToString(),
                LastMaintDate= DateTime.Now,
                Manufacturer="GE",
                Model="VM-x-1",
                StartDate= DateTime.Now,
                State=VendingMachineStateEnum.Operational.DisplayName,
            };

            VendingMachineTableRecord vmRecord2 = new VendingMachineTableRecord()
            {
                Id = 2,
                BalanceText = Balance.TenDollar.Encode(),
                Frequency = 45,
                GrandBalance = Balance.TenDollar.ToString(),
                LastMaintDate = DateTime.Today,
                Manufacturer = "BH",
                Model = "VM-x-2",
                StartDate = DateTime.Today,
                State = VendingMachineStateEnum.Defect.DisplayName,
            };

            VendingMachineTableRecord vmRecord3 = new VendingMachineTableRecord()
            {
                Id = 3,
                BalanceText = Balance.FiveDollar.Encode(),
                Frequency = 50,
                GrandBalance = Balance.FiveDollar.ToString(),
                LastMaintDate = DateTime.Today,
                Manufacturer = "Siemens",
                Model = "VM-x-3",
                StartDate = DateTime.Today,
                State = VendingMachineStateEnum.Operational.DisplayName,
            };

            VendingMachineTableRecord vmRecord4 = new VendingMachineTableRecord()
            {
                Id = 10,
                BalanceText = Balance.Cent.Encode(),
                Frequency = 90,
                GrandBalance = Balance.Cent.ToString(),
                LastMaintDate = DateTime.Today,
                Manufacturer = "HMI",
                Model = "VM-x-100",
                StartDate = DateTime.Today,
                State = VendingMachineStateEnum.OnMaintenance.DisplayName,
            };

            VendingMachineRepository vmRepo = new VendingMachineRepository();
            //vmRepo.AddModel(vmRecord1);
            //vmRepo.AddModel(vmRecord2);
            //vmRepo.AddModel(vmRecord3);
            //vmRepo.AddModel(vmRecord4, true);
        }
    }
}
