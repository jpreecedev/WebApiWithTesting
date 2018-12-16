using System.Collections.Generic;
using System.Linq;
using WebApiWithTesting.Domain.Entities;
using WebApiWithTesting.Domain.ViewModels;

namespace WebApiWithTesting.Domain.Converters
{
    public class HouseConverter : IConverter<House, HouseViewModel>
    {
        public HouseViewModel Convert(House entity)
        {
            return new HouseViewModel
            {
                HouseId = entity.HouseId,
                Address1 = entity.Address1,
                Postcode = entity.Postcode,
            };
        }

        public House FromViewModel(HouseViewModel viewModel)
        {
            return new House
            {
                HouseId = viewModel.HouseId,
                Address1 = viewModel.Address1,
                Postcode = viewModel.Postcode
            };
        }

        public House Update(House entity, HouseViewModel viewModel)
        {
            entity.Address1 = viewModel.Address1;
            entity.Postcode = viewModel.Postcode;
            return entity;
        }

        public ICollection<HouseViewModel> Convert(IEnumerable<House> entities)
        {
            return entities.Select(entity => new HouseViewModel
            {
                HouseId = entity.HouseId,
                Address1 = entity.Address1,
                Postcode = entity.Postcode
            }).ToList();
        }
    }
}