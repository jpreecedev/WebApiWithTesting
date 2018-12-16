using System.Collections.Generic;

namespace WebApiWithTesting.Domain.Converters
{
    public interface IConverter<T, TViewModel>
    {
        TViewModel Convert(T entity);

        T FromViewModel(TViewModel viewModel);

        T Update(T entity, TViewModel viewModel);

        ICollection<TViewModel> Convert(IEnumerable<T> entities);
    }
}