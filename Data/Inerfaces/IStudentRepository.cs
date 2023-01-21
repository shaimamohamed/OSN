using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Inerfaces
{
    public interface IStudentRepository
    {
        List<Student> GetALLStudents();
        Student GetStudentById(int Id);
        Student CreateStudent(Student student);
        Student UpdateStudent(Student student);
        Student DeleteStudent(int Id);

        List<Parent> GetALLParents();
        Parent GetParentById(int Id);
        Parent CreateParent(Parent parent);
        Parent UpdateParent(Parent parent);
        Parent DeleteParent(int Id);

    }
}
