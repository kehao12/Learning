using Learning.Data.Infrastructure;
using Learning.Data.Repositories;
using Learning.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Learning.Service
{
    public interface ICommonService
    {
       
        IEnumerable<Slide> GetSlides();
    }
    public class CommonService : ICommonService
    {
      
        IUnitOfWork _unitOfWork;
        ISlideRepository _slideRepository;
        public CommonService(IUnitOfWork unitOfWork,ISlideRepository slideRepository)
        {
            
            _unitOfWork = unitOfWork;
            _slideRepository = slideRepository;
        }
        

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x=>x.Status);
        }
    }
}
