using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjCore.Controllers
{
    public class Weapon : Controller
    {
        MonsterHunterContext db = new MonsterHunterContext();//導入資料庫


        public IActionResult Index()//將資料庫資料利用ToList方法顯示
        {
            var weapons = db.Weapon.ToList();
            return View(weapons);
        }
        public IActionResult Create()//建立create view
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Weapon weapon)//新增資料
        {
            db.Weapon.Add(weapon);
            db.SaveChanges();
            return RedirectToAction("Index");//導回防具列表
        }

        public IActionResult Edit(int id)//建立edit view
        {
            var weapon = db.Weapon.Where(m => m.Id == id).FirstOrDefault();
            return View(weapon);
        }

        [HttpPost]
        public IActionResult Edit(Models.Weapon weapon)//修改數據
        {
            var modify = db.Weapon.Where(m => m.Id == weapon.Id).FirstOrDefault();//讀取修改數據
            modify.系列名稱 = weapon.系列名稱;
            modify.輕弩 = weapon.輕弩;
            modify.重弩 = weapon.重弩;
            modify.銃槍 = weapon.銃槍;
            modify.長槍 = weapon.長槍;
            modify.雙劍 = weapon.雙劍;
            modify.充能斧 = weapon.充能斧;
            modify.單手劍 = weapon.單手劍;
            modify.大劍 = weapon.大劍;
            modify.大錘 = weapon.大錘;
            modify.太刀 = weapon.太刀;
            modify.弓 = weapon.弓;
            modify.操蟲棍 = weapon.操蟲棍;
            modify.斬擊斧 = weapon.斬擊斧;
            modify.狩獵笛 = weapon.狩獵笛;
            db.SaveChanges();
            return RedirectToAction("Index");//導回防具列表
        }

        public IActionResult Delete(int id)//建立delete view
        {
            var weapon = db.Weapon.Where(m => m.Id == id).FirstOrDefault();
            return View(weapon);//導回防具列表
        }

        [HttpPost]
        public IActionResult Delete(Models.Weapon weapon)//刪除數據
        {
            var result = db.Weapon.Where(m => m.Id == weapon.Id).FirstOrDefault();//讀取欲刪除之資料行
            db.Weapon.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        //查詢方法
        public string ShowQuery(IFormCollection fc,string keyword)
        {
            MonsterHunterContext db = new MonsterHunterContext();//導入資料庫
            string show = "";
            var result = db.Weapon.Where(i => i.系列名稱.Contains(keyword));//比對系列名稱欄位
            if (result.FirstOrDefault() == null)//如果找不到資料的話顯示查無此資料
            {
                show += "查無「" + keyword + "」";
            }
            foreach (var i in result)//依序列出搜尋結果
            {
                show += $"名稱:{i.系列名稱}\n";
                show += $"大劍:{i.大劍}\n";
                show += $"單手劍:{i.單手劍}\n";
                show += $"名稱:{i.大錘}\n";
                show += $"大錘:{i.長槍}\n";
                show += $"斬擊斧:{i.斬擊斧}\n";
                show += $"操蟲棍:{i.操蟲棍}\n";
                show += $"輕弩:{i.輕弩}\n";
                show += $"太刀:{i.太刀}\n";
                show += $"雙劍:{i.雙劍}\n";
                show += $"狩獵笛:{i.狩獵笛}\n";
                show += $"銃槍:{i.銃槍}\n";
                show += $"充能斧:{i.充能斧}\n";
                show += $"弓:{i.弓}\n";
                show += $"重弩:{i.重弩}\n";
                show += "-----------------------------\n";

            }
            return show;
        }
    }
}