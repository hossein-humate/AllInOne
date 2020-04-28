using System;
using UnitOfWork.Service.AllInOne;
using UnitOfWork.Service.Application;
using UnitOfWork.Service.BaseInfo;
using UnitOfWork.Service.Blog;
using UnitOfWork.Service.ClientApi;
using UnitOfWork.Service.Finance;
using UnitOfWork.Service.Identity;

namespace UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        #region All In One IService IRepositories

        IProject Projects { get; }

        #endregion All In One IService IRepositories

        #region Base Information IRepositories

        IMasterDetail MasterDetails { get; }

        #endregion Base Information IRepositories

        #region Client Api IRepositories

        IRequest Requests { get; }

        #endregion Client Api IRepositories

        #region Finance IRepositories

        IAccount Accounts { get; }
        ITransaction Transactions { get; }

        #endregion Finance IRepositories

        #region Identity IService IRepositories

        IAddress Address { get; }
        IEmail Emails { get; }
        IPermission Permissions { get; }
        IPerson Persons { get; }
        IPhone Phones { get; }
        IRole Roles { get; }
        IRolePermission RolePermissions { get; }
        ISocialNetwork SocialNetworks { get; }
        IUser Users { get; }
        IUserRole UserRoles { get; }
        IUserSoftware UserSoftwares { get; }
        IVisitor Visitors { get; }

        #endregion Identity IService IRepositories

        #region Application IService IRepositories

        IDatabase Databases { get; }
        ISoftware Softwares { get; }

        #endregion Application IService IRepositories

        #region Blog IRepositories

        IArticle Articles { get; }
        IArticleGroup ArticleGroups { get; }
        IArticleImage ArticleImages { get; }
        IDocument Documents { get; }
        IDocumentImage DocumentImages { get; }

        #endregion Blog IRepositories
        void Save();
    }
}