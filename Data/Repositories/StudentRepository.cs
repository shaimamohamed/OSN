using Core.Entities;
using Data.DataBase;
using Data.Inerfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AssessmentProjectDbContext _db;

        public StudentRepository(AssessmentProjectDbContext db)
        {
            _db = db;
        }

        #region Studet Actions
        public List<Student> GetALLStudents()
        {
            return  _db.students.Include("Parents").ToList();
            //return _db.students.ToList() ?? new List<Student>();
            //return _db.students.AsQueryable<Student>() ?? new Queryable<Student>();
            
        }
        public Student GetStudentById(int Id)
        {

            return _db.students.SingleOrDefault(a => a.ID == Id) ?? new Student();

        }
        public Student CreateStudent(Student student)
        {

            Student studentitem = new Student();
            var isSavedSuccessfully = false;

            _db.students.Add(student);
            _db.SaveChanges();

            studentitem = _db.students.SingleOrDefault(a => a.ID == student.ID);

            return studentitem;
        }
        public Student UpdateStudent(Student student)
        {

            Student studentitem = new Student();
            var isSavedSuccessfully = false;
            _db.students.Update(student);
            _db.SaveChanges();

            studentitem = GetStudentById(student.ID);

            return studentitem;
        }
        public Student DeleteStudent(int Id)
        {
            Student student = new Student();
            student = GetStudentById(Id);
            var isSavedSuccessfully = false;
            _db.students.Remove(student);
            _db.SaveChanges();


            return student;
        }
        #endregion

        #region Parents Actions
        public List<Parent> GetALLParents()
        {

            return _db.Parents.ToList() ?? new List<Parent>();

        }
        public Parent GetParentById(int Id)
        {

            return _db.Parents.SingleOrDefault(a => a.ID == Id) ?? new Parent();

        }
        public Parent CreateParent(Parent parent)
        {

            Parent parentitem = new Parent();
            var isSavedSuccessfully = false;

            _db.Parents.Add(parent);
            _db.SaveChanges();

            parentitem = _db.Parents.SingleOrDefault(a => a.ID == parent.ID);

            return parentitem;
        }
        public Parent UpdateParent(Parent parent)
        {

            Parent parentitem = new Parent();
            var isSavedSuccessfully = false;
            _db.Parents.Update(parent);
            _db.SaveChanges();

            parentitem = GetParentById(parent.ID);

            return parentitem;
        }
        public Parent DeleteParent(int Id)
        {
            Parent parent = new Parent();
            parent = GetParentById(Id);
            var isSavedSuccessfully = false;
            _db.Parents.Remove(parent);
            _db.SaveChanges();


            return parent;
        }
        #endregion
    }
}
