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
                item.Parents = _db.students.Include(p => p.Parents).FirstOrDefault(s => s.ID == item.StudentID)?.Parents?.ToList();
                //item.Parents = parent.ToList();
                
                result.Add(item);
            }

            return result;
        }

        public List<Report2DTO> Report2()
        {
            ////var x = _db.Marks.Include("Student").Include("Subject")
            //var a = _db.Marks.Include(a => a.Student).Include(b => b.Subject).Include(c => c.Student.Parents)
            //    .Where(f => f.Mark > 90)
            //    .GroupBy(s => new { s.TermId, s.SubjectId, SubjectName = s.Subject.Name, s.StudentId })
            //    .Select(r => new Report4DTO
            //    {
            //        TermID = r.Key.TermId,
            //        SubjectID = r.Key.SubjectId,
            //        SubjectName = r.Key.SubjectName,
            //        StudentID = r.Key.StudentId
            //    }).ToList();

            //var b = a?
            //    .GroupBy(s => new { s.TermID, s.SubjectID })
            //    .Where(g => g.Count() >= 2)
            //    .Select(r => r.ToList()).ToList();
                


            var x = _db.Marks.Include(a => a.Student).Include(b => b.Subject).Include(c => c.Student.Parents)
                .Where(f => f.Mark > 90)
                .GroupBy(s => new { s.TermId, s.SubjectId , SubjectName = s.Subject.Name, s.StudentId })
                //.Where(g => g.Count() >= 2)
                .Select(r => new Report4DTO
                {
                    TermID = r.Key.TermId,
                    SubjectID = r.Key.SubjectId,
                    SubjectName = r.Key.SubjectName,
                    StudentID = r.Key.StudentId
                }).ToList();
            //}).Include(s => s.Subjects).Include(s => s.parents).ToList();

            var z = x?.GroupBy(a => new {a.TermID , a.SubjectID})
                     ?.Where(g => g.Count() >= 2)
                     ?.Select(a => new Report4DTO { TermID = a.Key.TermID, SubjectID = a.Key.SubjectID , Students = a?.ToList()?.Select(b => _db.students.Include(p => p.Parents)?.FirstOrDefault(s => s.ID == b.StudentID))?.ToList()});

            List<Report4DTO> result = new List<Report4DTO>();

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
                item.Parents = _db.students.Include(p => p.Parents).FirstOrDefault(s => s.ID == item.StudentID)?.Parents?.ToList();
                //item.Parents = parent.ToList();

                result.Add(item);
            }

            return null;
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
