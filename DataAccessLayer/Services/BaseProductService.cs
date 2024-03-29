﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data = ADOLibrary;
using DataAccessLayer.Entities;
using Mappers;
using Microsoft.Extensions.Configuration;
using System.Transactions;
using InterfacesACA.Interfaces;
using System.Data.SqlTypes;

namespace DataAccessLayer.Services
{
    public class BaseProductService : IBaseProductService<BaseProduct,PriceBaseProduct>
    {
        private Data.Connection _co { get; set; }
        public BaseProductService(IConfiguration config)
        {
            _co = new Data.Connection(SqlClientFactory.Instance, config.GetConnectionString("Default"));
        }
        private BaseProduct Convert(IDataRecord reader)
        {
            return reader.MapReader<BaseProduct>();
        }
        private PriceBaseProduct ConvertPrice(IDataRecord reader)
        {
            return reader.MapReader<PriceBaseProduct>();
        }
        public void Create(BaseProduct product)
        {
            using (TransactionScope scope = new())
            {

                try
                {
                    Data.Command cmd = new("InsertBaseProduct", true);
                    cmd.MapToCommand(product);
                    _co.ExecuteNonQuery(cmd);
                    scope.Complete();
                }
                catch (Exception)
                {

                }
            }
        }
        public bool Delete(int id)
        {
            using (TransactionScope scope = new())
            {
                try
                {

                    Data.Command cmd = new("DeleteBaseProduct",true);
                    cmd.AddParameter("@id", id);
                    _co.ExecuteNonQuery(cmd);
                    scope.Complete();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public IEnumerable<BaseProduct> GetAll()
        {
            Data.Command cmd = new("select * from BaseProducts where IsActive = 1");
            return _co.ExecuteReader<BaseProduct>(cmd, Convert);
        }
        public BaseProduct GetById(int Id)
        {
            Data.Command cmd = new("select * from BaseProducts where Id = @id");
            cmd.AddParameter("@id", Id);
            return _co.ExecuteReader<BaseProduct>(cmd, Convert).FirstOrDefault();
        }
        public BaseProduct Update(int Id, BaseProduct product)
        {
            Data.Command cmd = new("UpdateBaseProduct", true);
            cmd.MapToCommand(product);
            cmd.AddParameter("@id", Id);
            _co.ExecuteNonQuery(cmd);
            return GetById(Id);
         
        }
        public void AddQuantity(int Id, int value)
        {

            if (value <= 0)
            {
                throw new Exception(message: "Impossible d'ajouter un nombre inférieur ou égal à 0");
            }
            Data.Command cmd = new("update BaseProducts set Quantity =  Quantity + @quantity where Id = @id");
            cmd.AddParameter("@quantity", value);
            cmd.AddParameter("@id", Id);
            _co.ExecuteNonQuery(cmd);

        }
        public void DeleteQuantity(int Id, int value)
        {
            if (value <= 0)
            {
                throw new Exception(message: "Impossible d'ajouter un nombre inférieur ou égal à 0");
            }
            Data.Command cmd = new("update BaseProducts set Quantity =  Quantity - @quantity where Id = @id");
            cmd.AddParameter("@quantity", value);
            cmd.AddParameter("@id", Id);
            _co.ExecuteNonQuery(cmd);
        }

        public PriceBaseProduct GetPrice(int Id)
        {
            Data.Command cmd = new("select * from PriceBaseProduct where BaseProductId = @Id and (EndDate is null or EndDate>GETDATE()) and DateStart < GETDATE()");
            cmd.AddParameter("@Id", Id);
            return _co.ExecuteReader<PriceBaseProduct>(cmd, ConvertPrice).FirstOrDefault();
        }
        public PriceBaseProduct InsertPrice(int Id, PriceBaseProduct product)
        {
            Data.Command cmd = new("InsertPriceBaseProduct", true);
            cmd.AddParameter("@Id", Id);
            cmd.AddParameter("@priceProduct", product.PriceProduct);
            cmd.AddParameter("@dateStart", product.DateStart);
            _co.ExecuteNonQuery(cmd);
            return GetPrice(Id);
        }

        public IEnumerable<PriceBaseProduct> GetAllPrice()
        {
            Data.Command cmd = new("select * from PriceBaseProduct where GETDATE() between DateStart and EndDate or EndDate is null and DateStart<getdate()");
            return _co.ExecuteReader<PriceBaseProduct>(cmd, ConvertPrice);
        }
    }
}
