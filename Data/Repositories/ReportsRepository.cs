using Core.Entities;
using Data.DataBase;
using Data.DTO;
using Data.Inerfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Data.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly AssessmentProjectDbContext _db;

        public ReportsRepository(AssessmentProjectDbContext db)
        {
            _db = db;
        }

        #region Studet Actions
        public List<Report1DTO> Report1()
        {
            //var x = _db.Marks.Include("Student").Include("Subject")
            var x = _db.Marks.Include(a=>a.Student).Include(b=>b.Subject).Include(c => c.Student.Parents)
                .Where(f => f.Mark > 90)
                .GroupBy(s => new { s.TermId, s.StudentId , s.Student.Gender , s.Student.Name})
                .Where(g => g.Count() > 3)
                .Select(r => new Report1DTO { StudentID = r.Key.StudentId
                , Gender = r.Key.Gender,
                StudentName = r.Key.Name
                }).ToList();
                //}).Include(s => s.Subjects).Include(s => s.parents).ToList();

              List<Report1DTO> result = new List<Report1DTO>();
        
            foreach (var item in x)
            {
                //var temp = new Report1DTO
                //{
                //StudentID = item.StudentID,
                //StudentName = item.StudentName,
                //    Gender = item.Gender,
                //DOB = item.DOB,
                //Email = item.Email,
                //mobile = item.mobile,
                //CurrentTermName = item.CurrentTermName,
                //parents = item.parents,
                //Term = item.Term,
                //Subjects = item.Subjects,
                //Marks = item.Marks

                //};
                //result.Add(temp);
                var parent = _db.students.Where(s => s.ID == item.StudentID).Include(p=>p.Parents).Select(p => p.Parents.FirstOrDefault());
                item.parents = parent.FirstOrDefault();
                
                result.Add(item);
            }

            return result;
        }

        public List<Report2DTO> Report2()
        {

            List<Report2DTO> result = new List<Report2DTO>();
            //var x = _db.students.Include("Parents").Where(f=> f.CurrentTermID==1).ToList();
            var x = _db.Marks.Include("Student").Include("Subject").Where(f => f.StudentId == f.StudentId && f.Mark > 90).GroupBy(s => s.StudentId).ToList();
            return result;
        }
        public List<Report3DTO> Report3()
        {

            List<Report3DTO> result = new List<Report3DTO>();
            //var x = _db.students.Include("Parents").Where(f=> f.CurrentTermID==1).ToList();
            var x = _db.Marks.Include("Student").Include("Subject").Where(f => f.StudentId == f.StudentId && f.Mark > 90).GroupBy(s => s.StudentId).ToList();
            return result;
        }
        public List<Report4DTO> Report4()
        {

            List<Report4DTO> result = new List<Report4DTO>();
            //var x = _db.students.Include("Parents").Where(f=> f.CurrentTermID==1).ToList();
            //var x = _db.Marks.Include("Student").Include("Subject").Where(f => f.StudentId == f.StudentId && f.Mark > 90).GroupBy(s => s.StudentId).ToList();
            //if (x != null && x.Count > 0) {
            //    foreach (var item in x)
            //    {
            //        var xx = new Report4DTO
            //        {
            //        SubjectID = 1,
            //         SubjectName = "",
            //          score = 0 ,
            //          isAbsent = false,
            //            studentCount = item.Count(),
            //           Marks = null
            //        };
            //        result.Add(xx);
            //    }
            //}
            return result;
        }

        #endregion

    }
}
