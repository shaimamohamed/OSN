using Core.Model;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Inerfaces
{
    public interface IReportsService
    {
          Task<GeneralResponse<List<Report1DTO>>> Report1();

          Task<GeneralResponse<List<Report2DTO>>> Report2();

          Task<GeneralResponse<List<Report3DTO>>> Report3();
         Task<GeneralResponse<List<Report4DTO>>> Report4();

    }
}
