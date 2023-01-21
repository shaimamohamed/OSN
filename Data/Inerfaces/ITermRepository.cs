using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Inerfaces
{
    public interface ITermRepository
    {
        List<Term> GetALLTerms();
        Term GetTermById(int Id);
        Term CreateTerm(Term product);
        Term UpdateTerm(Term product);
        Term DeleteTerm(int Id);
    }
}
