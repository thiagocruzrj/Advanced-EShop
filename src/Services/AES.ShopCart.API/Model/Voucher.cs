namespace AES.ShopCart.API.Model
{
    public class Voucher
    {
        public string Code { get; set; }
        public decimal? Percent { get; set; }
        public decimal? DiscountValue { get; set; }
        public DiscountTypeVoucher DiscountType { get; set; }
    }
}