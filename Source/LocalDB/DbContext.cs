using System;

namespace LocalDB
{
    public class DbContext : IDisposable
    {
        #region Fields + Properties

        private bool _disposed;

        #endregion

        // Public Methods

        public virtual void Dispose()
        {

            //if (_dbContextPool == null
            //    && !_disposed)
            //{
            //    _dbContextDependencies?.InfrastructureLogger.ContextDisposed(this);

            //    _disposed = true;

            //    _dbContextDependencies?.StateManager.Unsubscribe();

            //    _serviceScope?.Dispose();
            //    _dbContextDependencies = null;
            //    _changeTracker = null;
            //    _database = null;
            //}
        }


        //


        //public virtual EntityEntry Add([NotNull] object entity)
        //{
        //    CheckDisposed();

        //    return SetEntityState(Check.NotNull(entity, nameof(entity)), EntityState.Added);
        //}

        //public virtual async Task<EntityEntry> AddAsync(
        //    [NotNull] object entity,
        //    CancellationToken cancellationToken = default)
        //{
        //    CheckDisposed();

        //    var entry = EntryWithoutDetectChanges(Check.NotNull(entity, nameof(entity)));

        //    await SetEntityStateAsync(entry.GetInfrastructure(), EntityState.Added, cancellationToken);

        //    return entry;
        //}






        //public virtual int SaveChanges() => SaveChanges(acceptAllChangesOnSuccess: true);

        //public virtual int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    CheckDisposed();

        //    TryDetectChanges();

        //    try
        //    {
        //        var entitiesSaved = DbContextDependencies.StateManager.SaveChanges(acceptAllChangesOnSuccess);

        //        DbContextDependencies.UpdateLogger.SaveChangesCompleted(this, entitiesSaved);

        //        return entitiesSaved;
        //    }
        //    catch (Exception exception)
        //    {
        //        DbContextDependencies.UpdateLogger.SaveChangesFailed(this, exception);

        //        throw;
        //    }
        //}

        //private void TryDetectChanges()
        //{
        //    if (ChangeTracker.AutoDetectChangesEnabled)
        //    {
        //        ChangeTracker.DetectChanges();
        //    }
        //}


        //public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //    => SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);


        //public virtual async Task<int> SaveChangesAsync(
        //    bool acceptAllChangesOnSuccess,
        //    CancellationToken cancellationToken = default)
        //{
        //    CheckDisposed();

        //    DbContextDependencies.UpdateLogger.SaveChangesStarting(this);

        //    TryDetectChanges();

        //    try
        //    {
        //        var entitiesSaved = await DbContextDependencies.StateManager.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        //        DbContextDependencies.UpdateLogger.SaveChangesCompleted(this, entitiesSaved);

        //        return entitiesSaved;
        //    }
        //    catch (Exception exception)
        //    {
        //        DbContextDependencies.UpdateLogger.SaveChangesFailed(this, exception);

        //        throw;
        //    }
        //}

        //// Private Methods


        //[DebuggerStepThrough]
        //private void CheckDisposed()
        //{
        //    if (_disposed)
        //    {
        //        throw new ObjectDisposedException(GetType().FullName, "DbContext is already disposed!");
        //    }
        //}

    }
}
