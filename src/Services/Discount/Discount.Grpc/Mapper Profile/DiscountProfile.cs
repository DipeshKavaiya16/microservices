using AutoMapper;
using Discount.DataAccess.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Mapper_Profile
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
