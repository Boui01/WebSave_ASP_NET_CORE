using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tutorail_3_make_Model.Data;
using Tutorail_3_make_Model.Models;

namespace Tutorail_3_make_Model.Controllers
{
    public class WebController(ApplicationDBContext db) : Controller
    {
        private readonly ApplicationDBContext _db = db;

        public IActionResult Index()
        {
            // ---------- เรียงลำดับข้อมูลติด Mark ----------------
            IEnumerable<Web> WebList = _db.Webs.OrderByDescending( Data => Data.mark); // Type bool จะต้องเรียงใช้ Descending
            return View(WebList);
        }

        // GET นำมาใช้แสดงผลอย่างเดียว ส่งผ่าน URL
        // POST นำมาใช้สร้างหรือนำมาใช้ใน Controller 


        // ---------------------------------------- Create ------------------------------------------------
        public IActionResult create()
        {
            return View();
        }
        [HttpPost] // ข้อมูลที่ส่งผ่าน method Post มาจะเข้า Function นี้
        [ValidateAntiForgeryToken]
        public IActionResult create( Web obj) 
        {
            if( ModelState.IsValid)
            {
                obj.create_at = DateTime.Now;
                obj.update_at = DateTime.Now;

                _db.Webs.Add(obj); // Webs ใช้จากชื่อ class Application context ที่สร้าง 
                _db.SaveChanges(); // บันทึกการส่งข้อมูล
                return RedirectToAction("index");
            }
            return View(obj);
        }
        // ---------------------------------------- Edit ------------------------------------------------
        public IActionResult Edit( int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Webs.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Web obj) 
        {
            if (ModelState.IsValid)
            {
                obj.update_at = DateTime.Now;

                _db.Webs.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(obj);

        }

        // ---------------------------------------- Make Fav ---------------------------------------------
        public IActionResult updateMark(int id)
        {

                var obj = _db.Webs.Find(id);

                obj.mark = obj.mark ? false : true;

                obj.update_at = DateTime.Now;
                _db.Webs.Update(obj);
                _db.SaveChanges();
            
            return RedirectToAction("index");

        }

        // ---------------------------------------- Delete ------------------------------------------------
        public IActionResult Delete(int id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }

            var obj = _db.Webs.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Webs.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("index");
        }



        // ---------------------------------------- Find ------------------------------------------------
        public IActionResult Find()
        {
            IEnumerable<Web> webList = _db.Webs.ToList(); 
            return View(webList);
        }

        [HttpPost]
        public IActionResult Find(String web)
        {
            // ถ้าไม่กรอกอะไรเลย ให้แสดงทั้งหมด
            var all = _db.Webs.ToList();

            // ------------ เช็คข้อมูลว่าง -----------------
            if (string.IsNullOrWhiteSpace(web))
            {
 
                return View(all);
            }

            // ------------ ดึงข้อมูลเฉพาะ ----------------
            var obj = _db.Webs
                    .Where(data => data.nameLink.Contains(web)) // ให้ใช้ Contains เพื่อค้นหาคล้ายกัน
                    .ToList();


            if (obj.Count() == 0)
            {
                IEnumerable<Web> empty = Enumerable.Empty<Web>(); // Enumrable สร้าง List | empty ให้ว่างเปล่า | <> Type ของ List 
                return View(empty);
            }

            return View(obj); // ใช้ View "Index" ที่มีโค้ดแสดงตาราง

        }
        
    }
}
