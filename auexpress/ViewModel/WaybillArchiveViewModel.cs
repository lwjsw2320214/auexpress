﻿using auexpress.model;
using auexpress.Service;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace auexpress.ViewModel
{
    public class WaybillArchiveViewModel : NotificationObject
    {

       private WaybillProcessingService waybillProcessingService = new WaybillProcessingService();
 
        private List<ExpressMenuItemViewModel> expressMenu;
        
        public List<ExpressMenuItemViewModel> ExpressMenu
        {
            get { return expressMenu; }
            set { 
                expressMenu = value;

                this.RaisePropertyChanged("ExpressMenu");
            }
        }

        private int pageCount; 

        public int PageCount
        {
            get { return pageCount; }
            set {
                pageCount = value;
                this.RaisePropertyChanged("PageCount");
            }
        }
         
        private int pageSize; 

        public int PageSize
        {
            get { return pageSize; }
            set { 
                pageSize = value;
                this.RaisePropertyChanged("PageSize");
            }
        }
          
          
        public DelegateCommand WaybillProcessingCommand { get; set; }

        public DelegateCommand HomeCommand { get; set; }

        public DelegateCommand PreviousCommand { get; set; }

         public DelegateCommand NextCommand { get; set; }

         public DelegateCommand LastCommand { get; set; }

         public DelegateCommand<string> SerchCommand { get; set; }
         

         public WaybillArchiveViewModel()
         { 
             HomePage();
            this.HomeCommand = new DelegateCommand(new Action(HomePage));
            this.PreviousCommand = new DelegateCommand(new Action(PreviousPage));
            this.NextCommand = new DelegateCommand(new Action(NextPage));
            this.LastCommand = new DelegateCommand(new Action(LastPage));
            this.SerchCommand = new DelegateCommand<string>(SerchShow);
              
        }

         #region 分页
         /// <summary>
        /// 首页
        /// </summary>
        private void HomePage()
        { 
            this.PageSize = 1;
             
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", 10);
            dc.Add("irid", 0);
            dc.Add("page", this.PageSize);
            dc.Add("batchId", AppGlobal.SmsBatchId);
            var Count = waybillProcessingService.GetPage(dc);
            this.ExpressMenu = new List<ExpressMenuItemViewModel>();
            if (Count.result)
            {
                foreach (var item in Count.obj)
                {

                    ExpressMenuItemViewModel mv = new ExpressMenuItemViewModel();

                    mv.Express = item;

                    this.ExpressMenu.Add(mv);
                }
            }

            this.PageCount = Count.pageCount;

        }

        /// <summary>
        /// 上一页
        /// </summary>
        private void PreviousPage()
        {

            if (1 >= this.PageSize)
            {
                this.PageSize = 1;
            }
            else if (this.PageSize > 1)
            {

                this.PageSize--;
            }
             
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", 10);
            dc.Add("irid", 0);
            dc.Add("page", this.PageSize);
            dc.Add("batchId", AppGlobal.SmsBatchId);
            var Count = waybillProcessingService.GetPage(dc);
            this.ExpressMenu = new List<ExpressMenuItemViewModel>();
            if (Count.result)
            {
                foreach (var item in Count.obj)
                {

                    ExpressMenuItemViewModel mv = new ExpressMenuItemViewModel();

                    mv.Express = item;

                    this.ExpressMenu.Add(mv);
                }
            }

            this.PageCount = Count.pageCount;

        }

        /// <summary>
        /// 下一页
        /// </summary>
        private void NextPage() {

            if (this.PageCount <= this.PageSize)
            {
                this.PageSize = this.PageCount;
            }
            else if(this.PageCount>this.PageSize) {

                this.PageSize++;
            }
             
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", 10);
            dc.Add("irid", 0);
            dc.Add("page", this.PageSize);
            dc.Add("batchId", AppGlobal.SmsBatchId);
            var Count = waybillProcessingService.GetPage(dc);
            this.ExpressMenu = new List<ExpressMenuItemViewModel>();
            if (Count.result)
            {
                foreach (var item in Count.obj)
                {

                    ExpressMenuItemViewModel mv = new ExpressMenuItemViewModel();

                    mv.Express = item;

                    this.ExpressMenu.Add(mv);
                }
            }

            this.PageCount = Count.pageCount;
              
        }

         /// <summary>
         /// 末页
         /// </summary>
        private void LastPage() {

            this.PageSize = this.PageCount;

            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", 10);
            dc.Add("irid", 0);
            dc.Add("page", this.PageSize);
            dc.Add("batchId", AppGlobal.SmsBatchId);
            var Count = waybillProcessingService.GetPage(dc);
            this.ExpressMenu = new List<ExpressMenuItemViewModel>();
            if (Count.result)
            {
                foreach (var item in Count.obj)
                {

                    ExpressMenuItemViewModel mv = new ExpressMenuItemViewModel();

                    mv.Express = item;

                    this.ExpressMenu.Add(mv);
                }
            }

            this.PageCount = Count.pageCount;
        }
        #endregion

        private void SerchShow(string serch) {

            MessageBox.Show(serch);

        }

    }
}