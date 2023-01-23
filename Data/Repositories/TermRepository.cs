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
    public class TermRepository : ITermRepository
    {
        private readonly AssessmentProjectDbContext _db;

        public TermRepository(AssessmentProjectDbContext db)
        {
            _db = db;
        }

        #region Actions 
        
        public List<Term> GetALLTerms()
        {

            return _db.Terms.ToList() ?? new List<Term>();

        }
        public Term GetTermById(int Id)
        {

            return _db.Terms.SingleOrDefault(a => a.ID == Id) ?? new Term();

        }
        public Term CreateTerm(Term term)
        {

            Term termitem = new Term();
            var isSavedSuccessfully = false;

            _db.Terms.Add(term);
            _db.SaveChanges();

            termitem = _db.Terms.SingleOrDefault(a => a.ID == term.ID);

            return termitem;
        }
        public Term UpdateTerm(Term term)
        {

            Term termitem = new Term();
            var isSavedSuccessfully = false;
            _db.Terms.Update(term);
            _db.SaveChanges();

            termitem = GetTermById(term.ID);

            return termitem;
        }
        public Term DeleteTerm(int Id)
        {
            Term term = new Term();
            term = GetTermById(Id);
            var isSavedSuccessfully = false;
            _db.Terms.Remove(term);
            _db.SaveChanges();


            return term;
        }

        #endregion
    }
}
