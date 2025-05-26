using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MNSDotNetTrainingBatch1.MiniWallet.Database.AppDbContextModels;

namespace MNSDotNetTrainingBatch1.MiniWallet.WebApi.Features.Wallet.RegisterWallet
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterWalletController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public RegisterWalletController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public IActionResult Execute(RegisterWalletRequestModel requestModel)
        {
            RegisterWalletResponseModel model;

            #region Check Required Fields
            if (string.IsNullOrEmpty(requestModel.WalletUsername))
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Wallet Username is required"
                };
                goto Result;
            }
            if (string.IsNullOrEmpty(requestModel.FullName))
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Full Name is required"
                };
                goto Result;
            }
            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Mobile Number is required"
                };
                goto Result;
            }
            #endregion

            #region Check Duplicate Record

            var itemWallet = _appDbContext.TblWallets.FirstOrDefault(x => x.WallerUsername == requestModel.WalletUsername);

            if(itemWallet is not null)
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Wallet Username already registered"
                };
                goto Result;
            }

            itemWallet = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);

            if (itemWallet is not null)
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Mobile No already registered"
                };
                goto Result;
            }


            #endregion

            #region Register Wallet
            TblWallet item = new TblWallet()
            {
                Balance = 0,
                FullName = requestModel.FullName,
                MobileNo = requestModel.MobileNo,
                WallerUsername = requestModel.WalletUsername

            };
            _appDbContext.TblWallets.Add(item);
            _appDbContext.SaveChanges();
            #endregion

            model = new RegisterWalletResponseModel()
            {
                FullName = requestModel.FullName,
                MobileNo = requestModel.MobileNo,
                IsSuccess = true,
                WalletUsername = requestModel.WalletUsername,
                Message = "Success",
                WalletId = item.WalletId,
            };

        Result:
            return Ok(model);
        }
    }
}
