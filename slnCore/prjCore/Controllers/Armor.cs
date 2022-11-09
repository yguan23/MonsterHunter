using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using prjCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace prjCore.Controllers
{
    public class Armor : Controller
    {
        MonsterHunterContext db = new MonsterHunterContext();//導入資料庫
        public IActionResult Index()//將資料庫資料利用ToList方法顯示
        {
            var armors = db.Armor.ToList();
            return View(armors);
        }

        //public IActionResult Create()//建立create view
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Create(Models.Armor armor)//新增資料
        {
            db.Armor.Add(armor);
            db.SaveChanges();
            //return RedirectToAction("Index");//導回防具列表
            return View();
        }

        public IActionResult Edit(int id)//建立edit view
        {
            var armor = db.Armor.Where(m => m.Id == id).FirstOrDefault();
            return View(armor);
        }

        [HttpPost]
        public IActionResult Edit(Models.Armor armor)//修改數據
        {
            var modify = db.Armor.Where(m => m.Id == armor.Id).FirstOrDefault();//讀取修改數據
            modify.系列名稱 = armor.系列名稱;
            modify.腕甲 = armor.腕甲;
            modify.腰甲 = armor.腰甲;
            modify.護腿 = armor.護腿;
            modify.鎧甲 = armor.鎧甲;
            modify.頭盔 = armor.頭盔;
            db.SaveChanges();
            return RedirectToAction("Index");//導回防具列表
        }

        public IActionResult Delete(int id)//建立delete view
        {
            var armor = db.Armor.Where(m => m.Id == id).FirstOrDefault();
            return View(armor);//導回防具列表
        }

        [HttpPost]
        public IActionResult Delete(Models.Armor armor)//刪除數據
        {
            var result = db.Armor.Where(m => m.Id == armor.Id).FirstOrDefault();//讀取欲刪除之資料行
            db.Armor.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        //查詢方法
        public string ShowQuery(IFormCollection fc,string keyword)
        {
            MonsterHunterContext db = new MonsterHunterContext();//導入資料庫
            string show = "";
            var result = db.Armor.Where(i => i.系列名稱.Contains(keyword));//比對系列名稱欄位
            if (result.FirstOrDefault() == null)//如果找不到資料的話顯示查無此資料
            {
                show += "查無「"+keyword+ "」";
            }
            foreach (var i in result)//依序列出搜尋結果
            {
                show += $"系列名稱:{i.系列名稱}\n";
                show += $"頭盔:{i.頭盔}\n";
                show += $"鎧甲:{i.鎧甲}\n";
                show += $"腕甲:{i.腕甲}\n";
                show += $"腰甲:{i.腰甲}\n";
                show += $"護腿:{i.護腿}\n";
                show += "-----------------------------\n";

            }
            return show;

        }

        
        
    }
}
