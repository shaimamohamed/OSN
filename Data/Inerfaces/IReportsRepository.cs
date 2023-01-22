using Core.Entities;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Inerfaces
{
    public interface IReportsRepository
    {
        List<Report1DTO> Report1();
        List<Report2DTO> Report2();
        List<Report3DTO> Report3();
        List<Report4DTO> Report4();

    }
}
