namespace AES.ShopCart.API.Model
{
    public class Voucher
    {
        public string Code { get; set; }
        public decimal? Percent { get; set; }
        public decimal? DiscountValue { get; set; }
        public VoucherDiscountType DiscountType { get; set; }
    }

    public enum VoucherDiscountType
    {
        Percent = 0,
        Value = 1
    }
}