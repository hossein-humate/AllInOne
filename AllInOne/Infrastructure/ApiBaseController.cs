using DataAccess.DbContext;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork;
using Utility;

namespace AllInOne.Infrastructure
{
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public ApiBaseController()
        {
        }

        public ApiBaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected virtual IUnitOfWork UnitOfWork => _unitOfWork ?? (_unitOfWork =
                new UnitOfWork.UnitOfWork(DatabaseContext.Create(GlobalParameter.Connection)));
    }
}