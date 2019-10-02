using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
	{
		internal Contexto _context;

		public RepositorioBase()
		{
			_context = new Contexto();
		}

		public virtual bool Eliminar(int id)
		{
			bool ok = false;
			this._context = new Contexto();
			try
			{
				T entity = _context.Set<T>().Find(id);
				_context.Set<T>().Remove(entity);

				if (_context.SaveChanges() > 0)
				{
					ok = true;
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				this._context.Dispose();
			}

			return ok;
		}

		public void Dispose()
		{
			_context.Dispose();
		}

		public virtual T Buscar(int id)
		{
			T entity;
			this._context = new Contexto();
			try
			{
				entity = _context.Set<T>().Find(id);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				this._context.Dispose();
			}

			return entity;
		}

		public virtual List<T> GetList(Expression<Func<T, bool>> expression)
		{
			List<T> list = new List<T>();
			this._context = new Contexto();
			try
			{
				list = _context.Set<T>().Where(expression).ToList();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				this._context = new Contexto();
			}
			return list;
		}



		public virtual bool Modificar(T entity)
		{
			bool ok = false;
			this._context = new Contexto();
			try
			{
				_context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
				if (_context.SaveChanges() > 0)
				{
					ok = true;
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				this._context.Dispose();
			}

			return ok;
		}

		public virtual bool Guardar(T entity)
		{
			bool ok = false;
			this._context = new Contexto();
			try
			{
				if (_context.Set<T>().Add(entity) != null)
				{
					_context.SaveChanges();
					ok = true;
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				this._context.Dispose();
			}

			return ok;
		}


	}
}
