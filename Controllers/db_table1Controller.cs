using Microsoft.AspNetCore.Mvc;
using Product.Models;
using System.Drawing.Text;

namespace Product.Controllers
{
    public class db_table1Controller : Controller
    {
        private readonly Category _Db;

        public db_table1Controller(Category Db) 
        {
            _Db = Db;
        }
        public IActionResult db_table1List()
        {

           
            try
            {

                var stdList = from a in _Db.db_table1
                              join b in _Db.Table2
                              on a.ProductId equals b.CategoryId
                              into Dep
                              from b in Dep.DefaultIfEmpty()

                              select new db_table1
                              {
                                  ProductId = a.ProductId,
                                  ProductName = a.ProductName,
                                  CategoryId = a.CategoryId,

                                  Table2=b==null?"":b.Table2
                                  
                               };

                return View(stdList);
            }
            catch (Exception ex) 
            {
                return View();
            }

            return View();
        }

        public IActionResult Create( db_table1 obj) 
        {
            loadDDl();
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(db_table1 obj)

           
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    if (obj.CategoryId == 0)
                    {

                        _Db.db_table1.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }
                    return RedirectToAction("db_table1List");
                }
                return View();
            }
            catch (Exception ex)
            { 

                return RedirectToAction("db_table1List");
            }
        }



        public async Task<IActionResult> Deletestd(int CategoryId)
        {
            try
            {
                var std=_Db.db_table1.FindAsync(CategoryId);
                if(std!=null) 
                {
                    _Db.db_table1.Remove(std);
                    await _Db.SaveChangesAsync();
                }
                return RedirectToAction("db_test1List");

            }
            catch (Exception ex) 
            {
                return RedirectToAction("db_test1List");
            }
        }

        private void loadDDl()
        {
            try
            {
                List<Table2> depList=new List<Table2>();
                depList=_Db.Table2.ToList();

                

                ViewBag.DepList = depList;
                
            }

            catch (Exception ex) 
            {
               
            }
        }
    }
}
