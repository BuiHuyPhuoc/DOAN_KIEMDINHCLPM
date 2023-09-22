﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNPM_DOAN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.UI.WebControls;

    public partial class TODO
    {
        private CNPM_DOANEntities db = new CNPM_DOANEntities();
        public string IDToDo { get; set; }
        public string NDToDo { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayHoanThanh { get; set; }
        public Nullable<System.DateTime> HanChot { get; set; }
        public string TrangThai { get; set; }
        public string IDNguoiDung { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
        public TODO themMoiTODO(string NDTODO, string id)
        {
            this.NDToDo = NDTODO;
            this.IDNguoiDung = id;
            var timenow = DateTime.Now;
            this.NgayBatDau = timenow;
            this.NgayHoanThanh = null;
            //DateTime.ParseExact($"{timenow.Month}/{timenow.Day}/{timenow.Year} {11 - timenow.Hour}:{59 - timenow.Minute}:{59 - timenow.Second} PM", "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            //this.HanChot = timenow.AddDays(1).AddSeconds(-1);
            this.HanChot = timenow.AddDays(0).AddMonths(0).AddYears(0).AddHours(23 - timenow.Hour).AddMinutes(59 - timenow.Minute).AddSeconds(59 - timenow.Second);
            this.TrangThai = "Còn hạn";
            return this;
        }
        public void submitTodo(string IDToDo, string id)
        {
            var data = db.TODOes.Find(IDToDo);
            data.TrangThai = "Đã hoàn thành";
            data.NgayHoanThanh = DateTime.Now;
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void updateTrangThai(string IDToDo, string id)
        {
            var data = db.TODOes.Find(IDToDo);
            data.TrangThai = "Qúa hạn";
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void updateTodo(string IDToDo, string newNDtodo)
        {
            var data = db.TODOes.Find(IDToDo);
            data.NDToDo = newNDtodo;
            TODO tODO = data;
            db.Entry(tODO).State = EntityState.Modified;
            db.SaveChanges();
        }
        public bool checkUpdate(TODO todo)
        {
            if (todo.HanChot < DateTime.Now) return false;
            else return true;
        }
    }
}