using auexpress.Service;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace auexpress.ViewModel
{
    public class EditInfoViewModel : NotificationObject 
    {

        public delegate void AddUIdelegate();
        public event AddUIdelegate AddUIEvent;

        private ExpressService expressService = new ExpressService();

        private List<EditMenuItemViewModel> editInfoMenu;
        public List<EditMenuItemViewModel> EditInfoMenu
        {
            get { return editInfoMenu; }
            set {
                editInfoMenu = value;
                this.RaisePropertyChanged("EditInfoMenu");
            }
        }

        public DelegateCommand AddUICommand { get; set; }


        public EditInfoViewModel() {

            LoadExpressType();
            this.AddUICommand = new DelegateCommand(new Action(AddUI));

        }


        private void LoadExpressType() {

            try{
            var count = expressService.getExpressTypeList();

            this.EditInfoMenu = new List<EditMenuItemViewModel>();

            if (count.result) {

                foreach (var item in count.obj) {

                    EditMenuItemViewModel editItem = new EditMenuItemViewModel();

                    editItem.ExpressType = item;

                    this.editInfoMenu.Add(editItem); 
                }

            }
            }
            catch
            {

                MessageBox.Show("网络错误。请退出软件重新连接");
                return;
            }

        }

        public void TriggerAddUI() {

            if (AddUIEvent != null) { 
             
                AddUIEvent();
            }

        }

        private void AddUI() {

            TriggerAddUI();
        }
   
    }
}
