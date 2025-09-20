using StudentsManager.Application.Common.Interfaces.Repositories;
using StudentsManager.Application.Common.Interfaces.Transactions;
using StudentsManager.Application.Common.Interfaces.UnitOfWorks;
using StudentsManager.Infrastructure.DbContexts;
using StudentsManager.Infrastructure.Repositories;

namespace StudentsManager.Infrastructure.UnitOfWorks
{
    internal class StudentsUnitOfWork : IStudentsUnitOfWork, IDisposable
    {
        private readonly StudentsDbContext _context;
        ICuratorRepository? _curatorRepository;
        IGroupRepository? _groupRepository;
        IPersonRepository? _personRepository;
        ISpecialtyRepository? _specialtyRepository;
        IStudentRepository? _studentRepository;

        public StudentsUnitOfWork(StudentsDbContext context) 
        {
            _context = context;
        }
        public ICuratorRepository CuratorRepository => _curatorRepository ?? (_curatorRepository = new CuratorRepository(_context));

        public IGroupRepository GroupRepository => _groupRepository ?? (_groupRepository = new GroupRepository(_context));

        public IPersonRepository PersonRepository => _personRepository ?? (_personRepository = new PersonRepository(_context));

        public ISpecialtyRepository SpecialtyRepository => _specialtyRepository ?? (_specialtyRepository = new SpecialtyRepository(_context));

        public IStudentRepository StudentRepository => _studentRepository ?? (_studentRepository = new StudentRepository(_context));

        public async Task<ITransaction> BeginTransactionAsync()
        {
            return new Transaction(await _context.Database.BeginTransactionAsync());
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
