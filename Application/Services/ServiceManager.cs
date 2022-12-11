/////////////////////////////////
// generated ServiceManager.cs //
/////////////////////////////////
using Application.RepositoryInterfaces;
using Application.ServiceInterfaces;

namespace Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ISampleService> _lazySampleService;
        private readonly Lazy<IOrderStatusService> _lazyOrderStatusService;
        private readonly Lazy<IBookLanguageService> _lazyBookLanguageService;
        private readonly Lazy<IBookService> _lazyBookService;
        private readonly Lazy<IShippingMethodService> _lazyShippingMethodService;
        private readonly Lazy<IAddressStatusService> _lazyAddressStatusService;
        private readonly Lazy<ICustomerService> _lazyCustomerService;
        private readonly Lazy<IAddressService> _lazyAddressService;
        private readonly Lazy<ICountryService> _lazyCountryService;
        private readonly Lazy<IOrderLineService> _lazyOrderLineService;
        private readonly Lazy<IAuthorService> _lazyAuthorService;
        private readonly Lazy<ICustOrderService> _lazyCustOrderService;
        private readonly Lazy<IOrderHistoryService> _lazyOrderHistoryService;
        private readonly Lazy<ICustomerAddressService> _lazyCustomerAddressService;
        private readonly Lazy<IPublisherService> _lazyPublisherService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazySampleService = new Lazy<ISampleService>(() => new SampleService(repositoryManager));
            _lazyOrderStatusService = new Lazy<IOrderStatusService>(() => new OrderStatusService(repositoryManager));
            _lazyBookLanguageService = new Lazy<IBookLanguageService>(() => new BookLanguageService(repositoryManager));
            _lazyBookService = new Lazy<IBookService>(() => new BookService(repositoryManager));
            _lazyShippingMethodService = new Lazy<IShippingMethodService>(() => new ShippingMethodService(repositoryManager));
            _lazyAddressStatusService = new Lazy<IAddressStatusService>(() => new AddressStatusService(repositoryManager));
            _lazyCustomerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager));
            _lazyAddressService = new Lazy<IAddressService>(() => new AddressService(repositoryManager));
            _lazyCountryService = new Lazy<ICountryService>(() => new CountryService(repositoryManager));
            _lazyOrderLineService = new Lazy<IOrderLineService>(() => new OrderLineService(repositoryManager));
            _lazyAuthorService = new Lazy<IAuthorService>(() => new AuthorService(repositoryManager));
            _lazyCustOrderService = new Lazy<ICustOrderService>(() => new CustOrderService(repositoryManager));
            _lazyOrderHistoryService = new Lazy<IOrderHistoryService>(() => new OrderHistoryService(repositoryManager));
            _lazyCustomerAddressService = new Lazy<ICustomerAddressService>(() => new CustomerAddressService(repositoryManager));
            _lazyPublisherService = new Lazy<IPublisherService>(() => new PublisherService(repositoryManager));
        }
        public ISampleService SampleService => _lazySampleService.Value;
        public IOrderStatusService OrderStatusService => _lazyOrderStatusService.Value;
        public IBookLanguageService BookLanguageService => _lazyBookLanguageService.Value;
        public IBookService BookService => _lazyBookService.Value;
        public IShippingMethodService ShippingMethodService => _lazyShippingMethodService.Value;
        public IAddressStatusService AddressStatusService => _lazyAddressStatusService.Value;
        public ICustomerService CustomerService => _lazyCustomerService.Value;
        public IAddressService AddressService => _lazyAddressService.Value;
        public ICountryService CountryService => _lazyCountryService.Value;
        public IOrderLineService OrderLineService => _lazyOrderLineService.Value;
        public IAuthorService AuthorService => _lazyAuthorService.Value;
        public ICustOrderService CustOrderService => _lazyCustOrderService.Value;
        public IOrderHistoryService OrderHistoryService => _lazyOrderHistoryService.Value;
        public ICustomerAddressService CustomerAddressService => _lazyCustomerAddressService.Value;
        public IPublisherService PublisherService => _lazyPublisherService.Value;
    }
}
