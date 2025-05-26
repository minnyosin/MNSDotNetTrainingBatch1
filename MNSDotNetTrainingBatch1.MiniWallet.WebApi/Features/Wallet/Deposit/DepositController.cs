using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MNSDotNetTrainingBatch1.MiniWallet.Database.AppDbContextModels;
using MNSDotNetTrainingBatch1.MiniWallet.WebApi.Features.Wallet.RegisterWallet;

namespace MNSDotNetTrainingBatch1.MiniWallet.WebApi.Features.Wallet.Deposit
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public DepositController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public IActionResult Execute(DepositRequestModel requestModel)
        {
            DepositResponseModel model;

            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new DepositResponseModel
                {
                    Message = "Mobile Number is required"
                };
                goto Result;
            }
            if (requestModel.Amount <= 0)
            {
                model = new DepositResponseModel
                {
                    Message = "Amount must be greater than 0"
                };
                goto Result;
            }
            var itemWallet = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
            if (itemWallet is null)
            {
                model = new DepositResponseModel
                {
                    Message = "Wallet User doesn't exist"
                };
                goto Result;
            }

            decimal oldBalance = itemWallet.Balance;
            decimal newBalance = itemWallet.Balance + requestModel.Amount;

            itemWallet.Balance = newBalance;
            _appDbContext.SaveChanges();

            model = new DepositResponseModel
            {
                IsSuccess = true,
                Message = $"Deposit Amount - {requestModel.Amount}",
                OldBalance = oldBalance,
                NewBalance = newBalance
            };

        Result:
            return Ok(model);
        }
    }
}   
