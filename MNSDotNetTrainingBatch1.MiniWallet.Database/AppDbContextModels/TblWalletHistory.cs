using System;
using System.Collections.Generic;

namespace MNSDotNetTrainingBatch1.MiniWallet.Database.AppDbContextModels;

public partial class TblWalletHistory
{
    public int WalletHistoryId { get; set; }

    public string MobileNo { get; set; } = null!;

    public string TransactionType { get; set; } = null!;

    public decimal Amount { get; set; }
}
