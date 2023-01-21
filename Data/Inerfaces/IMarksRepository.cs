using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Inerfaces
{
    public interface IMarksRepository
    {
        List<Marks> GetALLMarks();
        Marks GetMarksById(int Id);
        Marks CreateMarks(Marks marks);
        Marks UpdateMarks(Marks marks);
        Marks DeleteMarks(int Id);
    }
}
