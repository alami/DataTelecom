using Data.Services.CouponAPI.Models.Dto;

namespace Data.Services.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
