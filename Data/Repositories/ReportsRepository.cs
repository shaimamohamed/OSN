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

            var x = _db.Marks.Include(a => a.Student).Include(b => b.Subject).Include(c => c.Student.Parents)
                .Where(f => f.Mark > 90)
                .GroupBy(s => new { s.TermId, s.StudentId, s.Student.Gender, s.Student.Name })
                .Where(g => g.Count() >= 3)
                .Select(r => new Report1DTO
                {
                    StudentID = r.Key.StudentId
                ,
                    Gender = r.Key.Gender,
                    StudentName = r.Key.Name
                }).ToList();

            List<Report1DTO> result = new List<Report1DTO>();

            foreach (var item in x)
            {

                item.Student = _db.students.Include(p => p.Parents).FirstOrDefault(s => s.ID == item.StudentID);

                result.Add(item);
            }

            return result;
        }

        public List<Report2DTO> Report2()
        {

            var res = _db.Marks.Include(a => a.Student).Include(b => b.Subject).Include(c => c.Student.Parents)
                .Where(f => f.Mark < 10)
                .GroupBy(s => new { s.TermId, s.SubjectId, SubjectName = s.Subject.Name, s.StudentId })
                .Select(r => new Report2DTO
                {
                    TermID = r.Key.TermId,
                    SubjectID = r.Key.SubjectId,
                    SubjectName = r.Key.SubjectName,
                    StudentID = r.Key.StudentId
                }).ToList();

            var temp = res?.GroupBy(a => new { a.TermID, a.SubjectID,a.SubjectName })
                     ?.Where(g => g.Count() >= 2)
                     ?.Select(a => new Report2DTO { TermID = a.Key.TermID,
                         SubjectID = a.Key.SubjectID //, SubjectName = a.Key.SubjectName , 
                        ,SubjectName = a?.ToList()?.Select(b => _db.Subjects
                       ?.FirstOrDefault(s => s.ID == b.SubjectID))?.FirstOrDefault().Name,
                         Students = a?.ToList()?.Select(b => _db.students.Include(p => p.Parents)?
                         .FirstOrDefault(s => s.ID == b.StudentID))?.ToList() }).ToList();

            List<Report2DTO> result = new List<Report2DTO>();

            foreach (var item in temp)
            {
                item.studentCount = item.Students.Count();
                result.Add(item);
            }

            return result;
        }
        public List<Report3DTO> Report3()
        {
            var res = _db.Marks.Include(a => a.Student).Include(b => b.Subject).Include(c => c.Student.Parents)
                .Where(f => f.Mark < 10)
                .GroupBy(s => new { s.TermId, s.SubjectId, SubjectName = s.Subject.Name, s.StudentId })
                .Select(r => new Report3DTO
                {
                    TermID = r.Key.TermId,
                    SubjectID = r.Key.SubjectId,
                    SubjectName = r.Key.SubjectName,
                    StudentID = r.Key.StudentId
                }).ToList();

            var temp = res?.GroupBy(a => new { a.TermID, a.SubjectID })
                     ?.Where(g => g.Count() >= 2)
                     ?.Select(a => new Report3DTO { TermID = a.Key.TermID,
                         SubjectID = a.Key.SubjectID, 
                        SubjectName = a?.ToList()?.Select(b => _db.Subjects
                       ?.FirstOrDefault(s => s.ID == b.SubjectID))?.FirstOrDefault().Name,
                         Students = a?.ToList()?.Select(b => _db.students.Include(p => p.Parents)
                         ?.FirstOrDefault(s => s.ID == b.StudentID))?.ToList() });

            List<Report3DTO> result = new List<Report3DTO>();

            foreach (var item in temp)
            {
                item.studentCount = item.Students.Count();
                result.Add(item);
            }

            return result;
        }
        public List<Report4DTO> Report4()
        {
            var res = _db.Marks.Include(a => a.Student).Include(b => b.Subject).Include(c => c.Student.Parents)
            .Where(f => f.Mark == 0 || f.IsAbsent == false)
            .GroupBy(s => new { s.TermId, s.SubjectId, SubjectName = s.Subject.Name, s.StudentId })
            .Select(r => new Report4DTO
            {
                TermID = r.Key.TermId,
                SubjectID = r.Key.SubjectId,
                SubjectName = r.Key.SubjectName,
                StudentID = r.Key.StudentId
            }).ToList();

            var temp = res?.GroupBy(a => new { a.TermID, a.SubjectID })
                     // ?.Where(g => g.Count() >= 2)
                     ?.Select(a => new Report4DTO
                     {
                         TermID = a.Key.TermID,
                         SubjectID = a.Key.SubjectID,
                         SubjectName = a?.ToList()?.Select(b => _db.Subjects
                       ?.FirstOrDefault(s => s.ID == b.SubjectID))?.FirstOrDefault().Name,
                         Students = a?.ToList()?.Select(b => _db.students.Include(p => p.Parents)
                         ?.FirstOrDefault(s => s.ID == b.StudentID))?.ToList()
                     });


            List<Report4DTO> result = new List<Report4DTO>();

            foreach (var item in temp)
            {
               item.studentCount = item.Students.Count();

                result.Add(item);
            }

            return result;
        }

        #endregion

    }
}
