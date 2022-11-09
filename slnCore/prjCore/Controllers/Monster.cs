using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjCore.Controllers
{
    public class Monster : Controller
    {
        MonsterHunterContext db = new MonsterHunterContext();//導入資料庫
        public IActionResult Index()//將資料庫資料利用ToList方法顯示
        {
            var monsters = db.Monster.ToList();
            return View(monsters);
        }

        public IActionResult Create()//建立create view
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Monster monster)//新增資料
        {
            db.Monster.Add(monster);
            db.SaveChanges();
            return RedirectToAction("Index");//導回防具列表
        }

        public IActionResult Edit(int id)//建立edit view
        {
            var monster = db.Monster.Where(m => m.Id == id).FirstOrDefault();
            return View(monster);
        }

        [HttpPost]
        public IActionResult Edit(Models.Monster monster)//修改數據
        {
            var modify = db.Monster.Where(m => m.Id == monster.Id).FirstOrDefault();//讀取修改數據
            modify.名稱 = monster.名稱;
            modify.弱點屬性 = monster.弱點屬性;
            modify.弱點武器 = monster.弱點武器;
            modify.弱點部位 = monster.弱點部位;
            modify.種類 = monster.種類;
            db.SaveChanges();
            return RedirectToAction("Index");//導回防具列表
        }

        public IActionResult Delete(int id)//建立delete view
        {
            var monster = db.Monster.Where(m => m.Id == id).FirstOrDefault();
            return View(monster);//導回防具列表
        }

        [HttpPost]
        public IActionResult Delete(Models.Monster monster)//刪除數據
        {
            var result = db.Monster.Where(m => m.Id == monster.Id).FirstOrDefault();//讀取欲刪除之資料行
            db.Monster.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        //查詢方法
        public string ShowQuery(IFormCollection fc,string keyword)
        {
            MonsterHunterContext db = new MonsterHunterContext();//導入資料庫
            string show = "";
            var result = db.Monster.Where(i => i.名稱.Contains(keyword));//比對系列名稱欄位
            if (result.FirstOrDefault() == null)//如果找不到資料的話顯示查無此資料
            {
                show += "查無「" + keyword + "」";
            }
            foreach (var i in result)//依序列出搜尋結果
            {
                show += $"名稱:{i.名稱}\n";
                show += $"種類:{i.種類}\n";
                show += $"弱點武器:{i.弱點武器}\n";
                show += $"弱點部位:{i.弱點部位}\n";
                show += $"弱點屬性:{i.弱點屬性}\n";
                show += "-----------------------------\n";

            }
            return show;
        }
    }
}
