using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entities;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]//save student information
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed,
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List(){
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id){
            var student = await dbContext.Students.FindAsync(Id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel){
            var student = await dbContext.Students.FindAsync(viewModel.Id);

            if(student is not null){
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Subscribed = viewModel.Subscribed;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List","Students");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel){
            var student = await dbContext.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == viewModel.Id);
            if(student is not null){
                dbContext.Students.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List","Students");
        }
    }
}