﻿using auexpress.Service;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auexpress.ViewModel
{
    public class EditInfoViewModel : NotificationObject 
    {

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




        public EditInfoViewModel() {

            LoadExpressType();

        }


        private void LoadExpressType() {

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
   
    }
}
