using Blogger.Core.Application.Ports.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blogger.Infrastructure.Persistence;

namespace Blogger.Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWork
    {
        #region Fields

        private readonly BloggerContext _dbContext;
        private IDbContextTransaction _transaction;
        private bool isDisposed = false;


        #endregion Fields

        #region Constructors

        public UnitOfWorks(BloggerContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion Constructors

        ~UnitOfWorks()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            try
            {
                this.CheckDisposed();
                _dbContext.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                this.CheckDisposed();
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                this.CheckDisposed();
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch(DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
            _transaction.GetDbTransaction().Dispose();
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
            _transaction.GetDbTransaction().Dispose();
        }

        protected void CheckDisposed()
        {
            if(this.isDisposed)
            {
                throw new ObjectDisposedException("The UnitOfWork is already disposed and cannot be used anymore.");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if(isDisposed) return;

            if(disposing)
            {
                _dbContext?.Dispose();
            }

            this.isDisposed = true;
        }
    }
}
