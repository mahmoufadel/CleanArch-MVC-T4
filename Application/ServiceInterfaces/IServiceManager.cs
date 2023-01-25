//////////////////////////////////
// generated IServiceManager.cs //
//////////////////////////////////
namespace Application.ServiceInterfaces
{
    public interface IServiceManager
    {
        IOrderStatusService OrderStatusService { get; }
        IBookLanguageService BookLanguageService { get; }
        IBookService BookService { get; }
        IShippingMethodService ShippingMethodService { get; }
        IAddressStatusService AddressStatusService { get; }
        ICustomerService CustomerService { get; }
        IAddressService AddressService { get; }
        ICountryService CountryService { get; }
        ISampleService SampleService { get; }
        IOrderLineService OrderLineService { get; }
        IAuthorService AuthorService { get; }
        ICustOrderService CustOrderService { get; }
        IOrderHistoryService OrderHistoryService { get; }
        ICustomerAddressService CustomerAddressService { get; }
        IPublisherService PublisherService { get; }
        IExpenseTypeService ExpenseTypeService { get; }
        IValuetypeService ValuetypeService { get; }
        IExpenseAssigneeService ExpenseAssigneeService { get; }
        IExpenseService ExpenseService { get; }
        IExpenseSubtypeService ExpenseSubtypeService { get; }
        ICollectionTypeService CollectionTypeService { get; }
    }
}
