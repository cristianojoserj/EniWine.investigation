using System;
using System.Collections.Generic;

namespace EniWine.Core.Repositories.Repositories
{
    public abstract class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity> where TEntity : class
    {

        #region [ Crud ]

        public void Insert(TEntity model)
        {
            using (var x = Session.BeginTransaction())
            {
                try
                {
                    Session.Save(model);
                    Session.Flush();
                    x.Commit();
                }
                catch
                {
                    x.Rollback();
                    throw;
                }
            }
        }

        public void Insert(IList<TEntity> entities)
        {
            using (var x = Session.BeginTransaction())
            {
                try
                {
                    foreach (TEntity t in entities)
                    {
                        Session.Save(t);
                    }

                    Session.Flush();
                    x.Commit();
                }
                catch
                {
                    x.Rollback();
                    throw;
                }
            }
        }

        public void Update(TEntity model)
        {
            using (var x = Session.BeginTransaction())
            {
                try
                {
                    Session.Update(model);
                    Session.Flush();
                    x.Commit();
                }
                catch (Exception)
                {
                    x.Rollback();
                    throw;
                }
            }
        }

        public void Update(IList<TEntity> entities)
        {
            using (var x = Session.BeginTransaction())
            {
                try
                {
                    foreach (TEntity t in entities)
                    {
                        Session.Update(t);
                    }
                    Session.Flush();
                    x.Commit();
                }
                catch (Exception)
                {
                    x.Rollback();
                    throw;
                }
            }
        }

        public TEntity SaveOrUpdate(TEntity model)
        {
            using (var x = Session.BeginTransaction())
            {
                try
                {
                    Session.SaveOrUpdate(model);
                    Session.Flush();
                    x.Commit();
                }
                catch
                {
                    x.Rollback();
                    throw;
                }
            }
            return model;
        }

        public void Delete(TEntity model)
        {
            using (var x = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(model);
                    Session.Flush();
                    x.Commit();
                }
                catch
                {
                    x.Rollback();
                    throw;
                }
            }
        }

        public void Delete(IList<TEntity> entities)
        {
            using (var x = Session.BeginTransaction())
            {
                try
                {
                    foreach (TEntity t in entities)
                    {
                        Session.Delete(t);
                        Session.Flush();
                        x.Commit();
                    }
                }
                catch (Exception)
                {
                    x.Rollback();
                    throw;
                }
            }
        }

        public void Delete(int id)
        {
            using (var x = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(Session.Load<TEntity>(id));
                    Session.Flush();
                    x.Commit();
                }
                catch (Exception)
                {
                    x.Rollback();
                    throw;
                }
            }
        }

        public void Delete(long id)
        {
            using (var x = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(Session.Load<TEntity>(id));
                    Session.Flush();
                    x.Commit();
                }
                catch (Exception)
                {
                    x.Rollback();
                    throw;
                }
            }
        }

        public void Delete(string id)
        {
            using (var x = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(Session.Load<TEntity>(id));
                    Session.Flush();
                    x.Commit();
                }
                catch (Exception)
                {
                    x.Rollback();
                    throw;
                }
            }
        }

        #endregion [ Crud ]

    }
}
