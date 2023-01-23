using Core.Entities;
using Data.DataBase;
using Data.Inerfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AssessmentProjectDbContext _db;

        public SubjectRepository(AssessmentProjectDbContext db)
        {
            _db = db;
        }

        #region Actions
        public List<Subject> GetALLSubjects()
        {

            return _db.Subjects.ToList() ?? new List<Subject>();

        }
        public Subject GetSubjectById(int Id)
        {

            return _db.Subjects.SingleOrDefault(a => a.ID == Id) ?? new Subject();

        }
        public Subject CreateSubject(Subject subject)
        {

            Subject subjectitem = new Subject();
            var isSavedSuccessfully = false;

            _db.Subjects.Add(subject);
            _db.SaveChanges();

            subjectitem = _db.Subjects.SingleOrDefault(a => a.ID == subject.ID);

            return subjectitem;
        }
        public Subject UpdateSubject(Subject subject)
        {

            Subject subjectitem = new Subject();
            var isSavedSuccessfully = false;
            _db.Subjects.Update(subject);
            _db.SaveChanges();

            subjectitem = GetSubjectById(subject.ID);

            return subjectitem;
        }
        public Subject DeleteSubject(int Id)
        {
            Subject subject = new Subject();
            subject = GetSubjectById(Id);
            var isSavedSuccessfully = false;
            _db.Subjects.Remove(subject);
            _db.SaveChanges();


            return subject;
        }
        #endregion

    }
}
