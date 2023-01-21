using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Inerfaces
{
    public interface ISubjectRepository
    {
        List<Subject> GetALLSubjects();
        Subject GetSubjectById(int Id);
        Subject CreateSubject(Subject subject);
        Subject UpdateSubject(Subject subject);
        Subject DeleteSubject(int Id);
    }
}
