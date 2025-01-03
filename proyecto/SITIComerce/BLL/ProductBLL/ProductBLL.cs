﻿using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;


namespace BLL
{
    public class ProductBLL
    {
        #region Variables & properties
        ProductDAL _dal;

        private DAO.DAOCLASS Dao { get { return _dal?.Dao; } }
        #endregion

        #region Constructors
        public ProductBLL(DAO.DAOCLASS dao) : base()
        {
            _dal = new(dao);
        }
        #endregion

        #region Methods
        public Product GetById(int id)
        {
            Product product = null;
            using (DataTable dt = _dal.GetById(id))
            {
                if (dt?.Rows?.Count > 0)
                    product = Utilities.CommonUtils.ConvertToObject<Product>(dt.Rows[0]);
            }
            return product;
        }

        public List<Product> GetAll()
        {
            using (DataTable dt = _dal.GetAll())
                return Utilities.CommonUtils.ConvertDataTableToList<Product>(dt);
        }


        public bool ExecuteDBAction(eDbAction action, Product product)
        {
            bool ok;

            try
            {

                ok = action switch
                {
                    eDbAction.Insert => Insert(product),
                    eDbAction.Update => Update(product),
                    eDbAction.Delete => Delete(product.Id),
                    _ => false
                };

            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return ok;
        }
        #endregion

        #region Private methods
        private bool Insert(Product product)
        {
            DAO.DAOCLASS dao = Dao;
            return Utilities.TransactionUtils.ExecuteWithTransaction(ref dao, () =>
            {
                return _dal.Insert(product);
            });
        }

        private bool Update(Product product)
        {
            DAO.DAOCLASS dao = Dao;
            return Utilities.TransactionUtils.ExecuteWithTransaction(ref dao, () =>
            {
                return _dal.Update(product);
            });
        }

        private bool Delete(int id)
        {
            DAO.DAOCLASS dao = Dao;
            return Utilities.TransactionUtils.ExecuteWithTransaction(ref dao, () =>
            {
                return _dal.Delete(id);
            });
        }
        #endregion
    }
}