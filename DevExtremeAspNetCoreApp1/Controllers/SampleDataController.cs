using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DevExtremeAspNetCoreApp1.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DevExtremeAspNetCoreApp1.Controllers {

    [Route("api/[controller]")]
    public class SampleDataController : Controller {
        private AppDbContext dbContext;
        public SampleDataController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //[HttpGet]
        //public object Get(DataSourceLoadOptions loadOptions) {
        //    return DataSourceLoader.Load(SampleData.Orders, loadOptions);
        //}
        [HttpGet]
        //public async Task<IActionResult> Student(DataSourceLoadOptions loadOptions)
        //{
        //    var std = dbContext.Students.Select(i => new
        //    {
        //        i.ID,
        //        i.Name,
        //        i.Gender,
        //        i.Email,
        //        i.Mobile,
        //        i.Address,
        //        i.Fee,
        //        i.IsDeleted
        //    }).Where(e=>e.IsDeleted==false);
        //    return Json(await DataSourceLoader.LoadAsync(std, loadOptions));
        //}
        public object Student(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(dbContext.Students, loadOptions);
        }

        [HttpPost]
        public IActionResult Insert(string values)
        {
            var newOrder = new Student();
            JsonConvert.PopulateObject(values, newOrder);

            if (!TryValidateModel(newOrder))
                return BadRequest();

            dbContext.Students.Add(newOrder);
            dbContext.SaveChanges();

            return Ok(newOrder);
        }
        [HttpPut]
        public IActionResult Update(int key, string values)
        {
            var student = dbContext.Students.First(a => a.ID == key);
            JsonConvert.PopulateObject(values, student);

            if (!TryValidateModel(student))
                return BadRequest();
            dbContext.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public void Delete(int Key)
        {
            var student = dbContext.Students.First(a => a.ID == Key);
            student.IsDeleted = true;
            dbContext.Students.Update(student);
            dbContext.SaveChanges();
        }
        //[HttpGet]
        //public object GetSkill(DataSourceLoadOptions loadOptions)
        //{
        //    return DataSourceLoader.Load(dbContext.Skills, loadOptions);
        //}

    }
}