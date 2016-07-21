﻿using auexpress.Model;
using auexpress.Service;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auexpress.ViewModel
{

    public class ManageExpressViewModel : NotificationObject
    {
        private SmsBatchService smsBatchService = new SmsBatchService();

        public delegate void ShowAddSmsBatchDelegate();

        public event ShowAddSmsBatchDelegate ShowAddSmsBatchEvent;


        private List<ManageExpressMenuItemViewModel> manageExpressMenu;
        public List<ManageExpressMenuItemViewModel> ManageExpressMenu
        {
            get { return manageExpressMenu; }
            set { 
                manageExpressMenu = value;
                this.RaisePropertyChanged("ManageExpressMenu");
            }
        }

        private int pageCount;

        public int PageCount
        {
            get { return pageCount; }
            set
            {
                pageCount = value;
                this.RaisePropertyChanged("PageCount");
            }
        }

        private int pageSize;

        public int PageSize
        {
            get {
                if (this.pageSize == 0) { 
                return 1;
                }
                return pageSize; }
            set
            {
                pageSize = value;
                this.RaisePropertyChanged("PageSize");
            }
        }


        public DelegateCommand HomeCommand { get; set; }

        public DelegateCommand PreviousCommand { get; set; }

        public DelegateCommand NextCommand { get; set; }

        public DelegateCommand LastCommand { get; set; }
        public DelegateCommand AddCommand { get; set; }
 
        public ManageExpressViewModel() {

            HomePage();
            this.HomeCommand = new DelegateCommand(new Action(HomePage));
            this.PreviousCommand = new DelegateCommand(new Action(PreviousPage));
            this.NextCommand = new DelegateCommand(new Action(NextPage));
            this.LastCommand = new DelegateCommand(new Action(LastPage));
            this.AddCommand = new DelegateCommand(new Action(AddSmsBatch));
        }


        #region  分页按钮事件
        /// <summary>
        /// 首页
        /// </summary>
        private void HomePage()
        {
            this.PageSize = 1;

            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", 10); 
            dc.Add("page", this.PageSize);
            var count = smsBatchService.getList(dc);
            this.ManageExpressMenu = new List<ManageExpressMenuItemViewModel>();
            if (count.result) {
                foreach (var item in count.obj) {
                    ManageExpressMenuItemViewModel mem = new ManageExpressMenuItemViewModel();
                    mem.SmsBatch = item;
                    this.ManageExpressMenu.Add(mem);
                }
                this.PageCount = count.pageCount;
                this.pageSize = count.page;
            }

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
            dc.Add("page", this.PageSize);
            var count = smsBatchService.getList(dc);
            this.ManageExpressMenu = new List<ManageExpressMenuItemViewModel>();
            if (count.result)
            {
                foreach (var item in count.obj)
                {
                    ManageExpressMenuItemViewModel mem = new ManageExpressMenuItemViewModel();
                    mem.SmsBatch = item;
                    this.ManageExpressMenu.Add(mem);
                }
                this.PageCount = count.pageCount;
                this.pageSize = count.page;
            }
             
        }

        /// <summary>
        /// 下一页
        /// </summary>
        private void NextPage()
        {

            if (this.PageCount <= this.PageSize)
            {
                this.PageSize = this.PageCount;
            }
            else if (this.PageCount > this.PageSize)
            {

                this.PageSize++;
            }

            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", 10);
            dc.Add("page", this.PageSize);
            var count = smsBatchService.getList(dc);
            this.ManageExpressMenu = new List<ManageExpressMenuItemViewModel>();
            if (count.result)
            {
                foreach (var item in count.obj)
                {
                    ManageExpressMenuItemViewModel mem = new ManageExpressMenuItemViewModel();
                    mem.SmsBatch = item;
                    this.ManageExpressMenu.Add(mem);
                }
                this.PageCount = count.pageCount;
                this.pageSize = count.page;
            }

        }

        /// <summary>
        /// 末页
        /// </summary>
        private void LastPage()
        {

            this.PageSize = this.PageCount;

            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", 10);
            dc.Add("page", this.PageSize);
            var count = smsBatchService.getList(dc);
            this.ManageExpressMenu = new List<ManageExpressMenuItemViewModel>();
            if (count.result)
            {
                foreach (var item in count.obj)
                {
                    ManageExpressMenuItemViewModel mem = new ManageExpressMenuItemViewModel();
                    mem.SmsBatch = item;
                    this.ManageExpressMenu.Add(mem);
                }
                this.PageCount = count.pageCount;
                this.pageSize = count.page;
            }

        }

        #endregion


        public void TriggerAddSmsBatch() {

            if (ShowAddSmsBatchEvent != null) {

                ShowAddSmsBatchEvent();
            }
        }

        private void AddSmsBatch() {

            TriggerAddSmsBatch();
        }

        public void RefreshView()
        {
                Dictionary<string, object> dc = new Dictionary<string, object>();
                dc.Add("icid", 10);
                dc.Add("page", this.PageSize);
                var count = smsBatchService.getList(dc);
                this.ManageExpressMenu = new List<ManageExpressMenuItemViewModel>();
                if (count.result)
                {
                    foreach (var item in count.obj)
                    {
                        ManageExpressMenuItemViewModel mem = new ManageExpressMenuItemViewModel();
                        mem.SmsBatch = item;
                        this.ManageExpressMenu.Add(mem);
                    }
                    this.PageCount = count.pageCount;
                    this.pageSize = count.page;
                }

        }
    }
}