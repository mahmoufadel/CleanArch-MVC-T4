/////////////////////////////////////
// generated IRepositoryManager.cs //
/////////////////////////////////////
namespace Application.RepositoryInterfaces
{
    public interface IRepositoryManager
    {
        ISampleRepository SampleRepository { get; }
        IOrderStatusRepository OrderStatusRepository { get; }
        IBookLanguageRepository BookLanguageRepository { get; }
        IBookRepository BookRepository { get; }
        IShippingMethodRepository ShippingMethodRepository { get; }
        IAddressStatusRepository AddressStatusRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IAddressRepository AddressRepository { get; }
        ICountryRepository CountryRepository { get; }
        IOrderLineRepository OrderLineRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        ICustOrderRepository CustOrderRepository { get; }
        IOrderHistoryRepository OrderHistoryRepository { get; }
        ICustomerAddressRepository CustomerAddressRepository { get; }
        IPublisherRepository PublisherRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
