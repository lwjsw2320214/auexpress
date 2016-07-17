using auexpress.model;
using auexpress.Utils;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auexpress.ViewModel
{
    public class WaybillProcessingViewModel : NotificationObject
    {
        public delegate void EditEventDelegate();

        public event EditEventDelegate EditShow;

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

         public DelegateCommand EditCommand { get; set; }

        public WaybillProcessingViewModel() {

            LoadExpressMenu();
            this.HomeCommand = new DelegateCommand(new Action(HomePage));
            this.PreviousCommand = new DelegateCommand(new Action(PreviousPage));
            this.NextCommand = new DelegateCommand(new Action(NextPage));
            this.LastCommand = new DelegateCommand(new Action(LastPage));
            this.EditCommand = new DelegateCommand(new Action(Edit));

            //this.WaybillProcessingCommand = new DelegateCommand(new Action());
        }
         
        /// <summary>
        /// 初始化数据 
        /// </summary>
        private void LoadExpressMenu() {
            ContentNetWork network = new ContentNetWork();
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", 10);
            dc.Add("irid", 0);
            dc.Add("page", 1);
            var pageCount = network.getApi("http://127.0.0.1:8080/recPreInput", dc);
           var Count= pageCount.JsonToObject<RecPreInputPage>();
            this.ExpressMenu = new List<ExpressMenuItemViewModel>();
            if (Count.result) {
                foreach (var item in Count.obj)
                {

                    ExpressMenuItemViewModel mv = new ExpressMenuItemViewModel();

                    mv.Express = item;

                    this.ExpressMenu.Add(mv);
                }
              }

            this.PageCount = Count.pageCount;
            this.PageSize = Count.page;
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void HomePage()
        {

            this.PageSize = 1;

            ContentNetWork network = new ContentNetWork();
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", 10);
            dc.Add("irid", 0);
            dc.Add("page", this.PageSize);
            var pageCount = network.getApi("http://127.0.0.1:8080/recPreInput", dc);
            var Count = pageCount.JsonToObject<RecPreInputPage>();
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

            ContentNetWork network = new ContentNetWork();
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", 10);
            dc.Add("irid", 0);
            dc.Add("page", this.PageSize);
            var pageCount = network.getApi("http://127.0.0.1:8080/recPreInput", dc);
            var Count = pageCount.JsonToObject<RecPreInputPage>();
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
            
            ContentNetWork network = new ContentNetWork();
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", 10);
            dc.Add("irid", 0);
            dc.Add("page", this.PageSize);
            var pageCount = network.getApi("http://127.0.0.1:8080/recPreInput", dc);
            var Count = pageCount.JsonToObject<RecPreInputPage>();
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

            ContentNetWork network = new ContentNetWork();
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", 10);
            dc.Add("irid", 0);
            dc.Add("page", this.PageSize);
            var pageCount = network.getApi("http://127.0.0.1:8080/recPreInput", dc);
            var Count = pageCount.JsonToObject<RecPreInputPage>();
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
        /// 添加运单事件
        /// </summary>
        public void TriggerEditShow() {

            if (EditShow != null) {
                EditShow();
            }  
        }


        private void Edit() {

            TriggerEditShow();
        } 


    }
}
