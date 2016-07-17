using auexpress.model;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auexpress.ViewModel
{
    public class ExpressMenuItemViewModel : NotificationObject
    { 
        public Express Express { get; set; }
  
    }
}
