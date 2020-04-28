using System;
using System.Runtime.InteropServices;
using DataAccess.DbContext;
using Microsoft.Win32.SafeHandles;
using UnitOfWork.Service.AllInOne;
using UnitOfWork.Service.Application;
using UnitOfWork.Service.BaseInfo;
using UnitOfWork.Service.Blog;
using UnitOfWork.Service.ClientApi;
using UnitOfWork.Service.Finance;
using UnitOfWork.Service.Identity;

namespace UnitOfWork
{
    public class UnitOfWork : object, IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        #region IDisposable Support

        private bool _disposed;
        private readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing) _handle.Dispose();
            _disposed = true;
        }

        #endregion

        #region Identity Service Repositories

        private IVisitor _visitor;
        public IVisitor Visitors => _visitor ??= new Visitor(_databaseContext);

        private IUserSoftware _userSoftware;
        public IUserSoftware UserSoftwares => _userSoftware ??= new UserSoftware(_databaseContext);

        private IAddress _address;

        public IAddress Address => _address ??= new Address(_databaseContext);

        private IEmail _email;

        public IEmail Emails => _email ??= new Email(_databaseContext);

        private IPermission _permission;

        public IPermission Permissions => _permission ??= new Permission(_databaseContext);

        private IPerson _person;

        public IPerson Persons => _person ??= new Person(_databaseContext);

        private IPhone _phone;

        public IPhone Phones => _phone ??= new Phone(_databaseContext);

        private IRole _role;

        public IRole Roles => _role ??= new Role(_databaseContext);

        private IRolePermission _rolePermission;

        public IRolePermission RolePermissions => _rolePermission ??= new RolePermission(_databaseContext);

        private ISocialNetwork _socialNetwork;

        public ISocialNetwork SocialNetworks => _socialNetwork ??= new SocialNetwork(_databaseContext);

        private IUser _user;

        public IUser Users => _user ??= new User(_databaseContext);

        private IUserRole _userRole;

        public IUserRole UserRoles => _userRole ??= new UserRole(_databaseContext);

        #endregion Identity Service Repositories

        #region Application Service Repositories

        private IDatabase _database;

        public IDatabase Databases => _database ??= new Database(_databaseContext);

        private ISoftware _software;

        public ISoftware Softwares => _software ??= new Software(_databaseContext);

        #endregion Application Service Repositories

        #region All In One Repositories

        private IProject _project;

        public IProject Projects => _project ??= new Project(_databaseContext);

        #endregion All In One Repositories

        #region Base Information Service Repositories

        private IMasterDetail _masterDetail;

        public IMasterDetail MasterDetails => _masterDetail ??= new MasterDetail(_databaseContext);

        #endregion Base Information Service Repositories

        #region ClientApi Service Repositories

        private IRequest _request;

        public IRequest Requests => _request ??= new Request(_databaseContext);

        #endregion ClientApi Service Repositories

        #region Finance Repositories

        private IAccount _account;

        public IAccount Accounts => _account ??= new Account(_databaseContext);

        private ITransaction _transaction;

        public ITransaction Transactions => _transaction ??= new Transaction(_databaseContext);

        #endregion Finance Repositories

        #region Blog Repositories

        private IArticle _article;

        public IArticle Articles => _article ??= new Article(_databaseContext);

        private IArticleGroup _articleGroup;

        public IArticleGroup ArticleGroups => _articleGroup ??= new ArticleGroup(_databaseContext);

        private IArticleImage _articleImage;

        public IArticleImage ArticleImages => _articleImage ??= new ArticleImage(_databaseContext);

        private IDocument _document;

        public IDocument Documents => _document ??= new Document(_databaseContext);
        
        private IDocumentImage _documentImage;

        public IDocumentImage DocumentImages => _documentImage ??= new DocumentImage(_databaseContext);

        #endregion Blog Repositories
    }
}