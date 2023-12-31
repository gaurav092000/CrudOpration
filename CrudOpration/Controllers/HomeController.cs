﻿using CrudOpration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Data.Entity;

namespace CrudOpration.Controllers
{
    public class HomeController : Controller
    {
        CrudContext cr = new CrudContext();
        public ActionResult Index()
        {

           // List<Category> categoryList= cr.categories.ToList();
           // TempData["categorytbl"] = new SelectList(categoryList,"CategoryId","CategoryName");
           // TempData["categorytbl"] = new SelectList(categoryList,"CategoryId","CategoryName");
           
           //var cat = (List<Category>)TempData["categorytbl"];
            return View();
        }

        public ActionResult Category()
        {

            var data = cr.Categories.Include(x =>x.Products).ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Category c)
        {
            if (ModelState.IsValid == true)
            {
                c.Status = true;
                cr.Categories.Add(c);
                int n = cr.SaveChanges();
                if (n > 0)
                {
                    TempData["Create"] = "<script>alert('DATA SAVE SUCCESSFULLY')</script>";
                    return RedirectToAction("Category");
                }
                else
                {
                    TempData["Create"] = "<script>alert('DATA NOT SAVE SUCCESSFULLY')</script>";
                }

            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = cr.Categories.Where(model => model.CategoryId == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]

        public ActionResult Edit(Category cc)
        {
            if (ModelState.IsValid == true)
            {
                cr.Entry(cc).State = EntityState.Modified;
                int a = cr.SaveChanges();
                if (a > 0)
                {
                    TempData["Edit"] = "<script>alert('Data Edit Successfully')</script>";
                    return RedirectToAction("Category");
                }
                else
                {
                    TempData["Edit"] = "<script>alert('Data edit  not Successfully')</script>";
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var categoryrow = cr.Categories.Where(model => model.CategoryId == id).FirstOrDefault();
                if (categoryrow != null)
                {
                    cr.Entry(categoryrow).State = EntityState.Deleted;
                    int a = cr.SaveChanges();
                    if (a > 0)
                    {
                        TempData["Delete"] = "<script>alert('Are You Sure ')</script>";
                    }
                    else
                    {
                        TempData["Delete"] = "<script>alert('Data  Not Delete')</script>";
                    }
                }
            }
            return RedirectToAction("Category");

        }

        public ActionResult Details(int id)
        {
            var DetailsId = cr.Categories.Where(model => model.CategoryId == id).FirstOrDefault();
            return View(DetailsId);

        }


        public ActionResult Product()
        {
            var datap = cr.Products
                .Include(x=>x.Category)
                .Where(x => x.Category.Status == true).ToList();
            return View(datap);
        }

        public ActionResult Createe()
        {
            var categories = cr.Categories.Where(x => x.Status == true).ToList();
            TempData["CategoryList"] = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Createe(Product p)
        {
            if (ModelState.IsValid==true)
            {
               cr.Products.Add(p);
                int a= cr.SaveChanges();
                if(a > 0)
                {
                    TempData["procreate"] = "<script>alert('Data Inserted in Product')</script>";
                    return RedirectToAction("Product");
                }
                else
                {
                    TempData["procreate"] = "<script>alert('Data Not Inserted in Product')</script>";
                }
            }
          
            return View();
        }
        [HttpGet]
        public ActionResult Editt(int id)
        {
            var rowp = cr.Products.Where(model => model.ProductId==id).FirstOrDefault();
            return View (rowp);
        }
        [HttpPost]
        public ActionResult Editt(Product pp)
        {
            if (ModelState.IsValid==true) 
            {
                cr.Entry(pp).State=EntityState.Modified;
                int a= cr.SaveChanges();
                if (a > 0)
                {
                    TempData["Edit"] = "<script>alert('Data Edit Successfully')</script>";
                    return RedirectToAction("Product");
                }
                else
                {
                    TempData["Edit"] = "<script>alert('Data edit  not Successfully')</script>";
                }
            }
            return View();
        }

        public ActionResult Detailss(int id)
        {
            var DetailsIdd = cr.Products.Where(model => model.ProductId == id).FirstOrDefault();
            return View(DetailsIdd);

        }

        public ActionResult Deletee(int id)
        {
            if (id > 0)
            {
                var productrow = cr.Products.Where(model => model.ProductId == id).FirstOrDefault();
                if (productrow != null)
                {
                    cr.Entry(productrow).State = EntityState.Deleted;
                    int a = cr.SaveChanges();
                    if (a > 0)
                    {
                        TempData["Delete"] = "<script>alert('Are You Sure ')</script>";
                        return RedirectToAction("Product");
                    }
                    else
                    {
                        TempData["Delete"] = "<script>alert('Data  Not Delete')</script>";
                    }
                }
            }
            return RedirectToAction("Product");

        }




    }

}
   

 
