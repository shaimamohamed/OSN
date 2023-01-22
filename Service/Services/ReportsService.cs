using Core.Entities;
using Core.Model;
using Data.DTO;
using Data.Inerfaces;
using Service.Inerfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IReportsRepository _reportsRepository;
        public ReportsService(IReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;//?? throw new ArgumentNullException(nameof(termRepository));
        }

        #region Actions
        public async Task<GeneralResponse<List<Report1DTO>>>  Report1()
        {
            var respnose = new GeneralResponse<List<Report1DTO>>();

            var result = _reportsRepository.Report1();

            if (result == null || result.Count <= 0)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<List<Report1DTO>>()
            {
                Success = true,
                Data = result
            };

            return respnose;

        }

        public async Task<GeneralResponse<List<Report2DTO>>> Report2()
        {
            var respnose = new GeneralResponse<List<Report2DTO>>();

            var result = _reportsRepository.Report2();

            if (result == null || result.Count <= 0)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<List<Report2DTO>>()
            {
                Success = true,
                Data = result
            };

            return respnose;

        }

        public async Task<GeneralResponse<List<Report3DTO>>> Report3()
        {
            var respnose = new GeneralResponse<List<Report3DTO>>();

            var result = _reportsRepository.Report3();

            if (result == null || result.Count <= 0)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<List<Report3DTO>>()
            {
                Success = true,
                Data = result
            };

            return respnose;

        }


        public async Task<GeneralResponse<List<Report4DTO>>> Report4()
        {

            var respnose = new GeneralResponse<List<Report4DTO>> ();

            var result = _reportsRepository.Report4();

            if (result == null || result.Count <= 0)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<List<Report4DTO>>()
            {
                Success = true,
                Data = result
            };

            return respnose;

        }

        #endregion
    }
}
