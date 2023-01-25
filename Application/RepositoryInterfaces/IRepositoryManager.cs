/////////////////////////////////////
// generated IRepositoryManager.cs //
/////////////////////////////////////
namespace Application.RepositoryInterfaces
{
    public interface IRepositoryManager
    {
        IOrderStatusRepository OrderStatusRepository { get; }
        IBookLanguageRepository BookLanguageRepository { get; }
        IBookRepository BookRepository { get; }
        IShippingMethodRepository ShippingMethodRepository { get; }
        IAddressStatusRepository AddressStatusRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IAddressRepository AddressRepository { get; }
        ICountryRepository CountryRepository { get; }
        ISampleRepository SampleRepository { get; }
        IOrderLineRepository OrderLineRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        ICustOrderRepository CustOrderRepository { get; }
        IOrderHistoryRepository OrderHistoryRepository { get; }
        ICustomerAddressRepository CustomerAddressRepository { get; }
        IPublisherRepository PublisherRepository { get; }
        IExpenseTypeRepository ExpenseTypeRepository { get; }
        IValuetypeRepository ValuetypeRepository { get; }
        IExpenseAssigneeRepository ExpenseAssigneeRepository { get; }
        IExpenseRepository ExpenseRepository { get; }
        IExpenseSubtypeRepository ExpenseSubtypeRepository { get; }
        ICollectionTypeRepository CollectionTypeRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
