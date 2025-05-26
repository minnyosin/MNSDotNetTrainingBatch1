namespace MNSDotNetTrainingBatch1.MiniWallet.WebApi.Features.Wallet.RegisterWallet
{
    public class RegisterWalletResponseModel : ResponseModel
    {
        public int WalletId { get; set; }
        public string WalletUsername { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
    }
}
