////////////////////////////////////
// generated RepositoryManager.cs //
////////////////////////////////////
using Application.RepositoryInterfaces;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ISampleRepository> _lazySampleRepository;
        private readonly Lazy<IOrderStatusRepository> _lazyOrderStatusRepository;
        private readonly Lazy<IBookLanguageRepository> _lazyBookLanguageRepository;
        private readonly Lazy<IBookRepository> _lazyBookRepository;
        private readonly Lazy<IShippingMethodRepository> _lazyShippingMethodRepository;
        private readonly Lazy<IAddressStatusRepository> _lazyAddressStatusRepository;
        private readonly Lazy<ICustomerRepository> _lazyCustomerRepository;
        private readonly Lazy<IAddressRepository> _lazyAddressRepository;
        private readonly Lazy<ICountryRepository> _lazyCountryRepository;
        private readonly Lazy<IOrderLineRepository> _lazyOrderLineRepository;
        private readonly Lazy<IAuthorRepository> _lazyAuthorRepository;
        private readonly Lazy<ICustOrderRepository> _lazyCustOrderRepository;
        private readonly Lazy<IOrderHistoryRepository> _lazyOrderHistoryRepository;
        private readonly Lazy<ICustomerAddressRepository> _lazyCustomerAddressRepository;
        private readonly Lazy<IPublisherRepository> _lazyPublisherRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(ApplicationDbContext context)
        {
            _lazySampleRepository = new Lazy<ISampleRepository>(() => new SampleRepository(context));
            _lazyOrderStatusRepository = new Lazy<IOrderStatusRepository>(() => new OrderStatusRepository(context));
            _lazyBookLanguageRepository = new Lazy<IBookLanguageRepository>(() => new BookLanguageRepository(context));
            _lazyBookRepository = new Lazy<IBookRepository>(() => new BookRepository(context));
            _lazyShippingMethodRepository = new Lazy<IShippingMethodRepository>(() => new ShippingMethodRepository(context));
            _lazyAddressStatusRepository = new Lazy<IAddressStatusRepository>(() => new AddressStatusRepository(context));
            _lazyCustomerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(context));
            _lazyAddressRepository = new Lazy<IAddressRepository>(() => new AddressRepository(context));
            _lazyCountryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(context));
            _lazyOrderLineRepository = new Lazy<IOrderLineRepository>(() => new OrderLineRepository(context));
            _lazyAuthorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(context));
            _lazyCustOrderRepository = new Lazy<ICustOrderRepository>(() => new CustOrderRepository(context));
            _lazyOrderHistoryRepository = new Lazy<IOrderHistoryRepository>(() => new OrderHistoryRepository(context));
            _lazyCustomerAddressRepository = new Lazy<ICustomerAddressRepository>(() => new CustomerAddressRepository(context));
            _lazyPublisherRepository = new Lazy<IPublisherRepository>(() => new PublisherRepository(context));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
        }
        public ISampleRepository SampleRepository => _lazySampleRepository.Value;
        public IOrderStatusRepository OrderStatusRepository => _lazyOrderStatusRepository.Value;
        public IBookLanguageRepository BookLanguageRepository => _lazyBookLanguageRepository.Value;
        public IBookRepository BookRepository => _lazyBookRepository.Value;
        public IShippingMethodRepository ShippingMethodRepository => _lazyShippingMethodRepository.Value;
        public IAddressStatusRepository AddressStatusRepository => _lazyAddressStatusRepository.Value;
        public ICustomerRepository CustomerRepository => _lazyCustomerRepository.Value;
        public IAddressRepository AddressRepository => _lazyAddressRepository.Value;
        public ICountryRepository CountryRepository => _lazyCountryRepository.Value;
        public IOrderLineRepository OrderLineRepository => _lazyOrderLineRepository.Value;
        public IAuthorRepository AuthorRepository => _lazyAuthorRepository.Value;
        public ICustOrderRepository CustOrderRepository => _lazyCustOrderRepository.Value;
        public IOrderHistoryRepository OrderHistoryRepository => _lazyOrderHistoryRepository.Value;
        public ICustomerAddressRepository CustomerAddressRepository => _lazyCustomerAddressRepository.Value;
        public IPublisherRepository PublisherRepository => _lazyPublisherRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
