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
    public class MarksRepository : IMarksRepository
    {
        private readonly AssessmentProjectDbContext _db;

        public MarksRepository(AssessmentProjectDbContext db)
        {
            _db = db;
        }

        #region Actions
        public List<Marks> GetALLMarks()
        {

            return _db.Marks.ToList() ?? new List<Marks>();

        }
        public Marks GetMarksById(int Id)
        {

            return _db.Marks.SingleOrDefault(a => a.ID == Id) ?? new Marks();

        }
        public Marks CreateMarks(Marks marks)
        {

            Marks markitem = new Marks();
            var isSavedSuccessfully = false;

            _db.Marks.Add(marks);
            _db.SaveChanges();

            markitem = _db.Marks.SingleOrDefault(a => a.ID == marks.ID);

            return markitem;
        }
        public Marks UpdateMarks(Marks marks)
        {

            Marks markitem = new Marks();
            var isSavedSuccessfully = false;
            _db.Marks.Update(marks);
            _db.SaveChanges();

            markitem = GetMarksById(marks.ID);

            return markitem;
        }
        public Marks DeleteMarks(int Id)
        {
            Marks mark = new Marks();
            mark = GetMarksById(Id);
            var isSavedSuccessfully = false;
            _db.Marks.Remove(mark);
            _db.SaveChanges();


            return mark;
        }
        #endregion

    }
}
