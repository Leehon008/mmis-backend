using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.SHE.Entities;
using MMIS.DomainLayer.SHE.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;


namespace MMIS.BusinessLogicLayer.SHE.Contract
{

    public class UploadFileLogic : IFileUploadLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppointmentsRepository _Repository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _context;
        private readonly IConfiguration _configuration;

        public UploadFileLogic(IMapper mapper, IUnitOfWork unitOfWork, IAppointmentsRepository Repository, IWebHostEnvironment hostingEnvironment, IHttpContextAccessor context, IConfiguration configuration)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _Repository = Repository;
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _configuration = configuration;
          

        }
       
        public async Task<string> UploadFile(IFormFile file,string module,string func)
        {
             
            if (file == null || file.Length == 0)
                return "no files selected";

           
            string WebrootPath = _hostingEnvironment.WebRootPath;
          
            string path = Path.Combine(WebrootPath ,module,func, file.FileName);
            
         
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine(module, func, file.FileName); ;
        }
    }
}