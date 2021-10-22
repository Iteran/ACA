using ADOLibrary;
using DataAccessLayer.Entities;
using InterfacesACA.Interfaces;
using Mappers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer.Services
{
    public class SubcontractorService : ICRUD<Subcontractors, int>
    {
        private readonly Connection co;

        public SubcontractorService(IConfiguration config)
        {
            this.co = new(SqlClientFactory.Instance, config.GetConnectionString("Default"));
        }
        private Subcontractors Convert(IDataRecord reader)
        {
            return reader.MapReader<Subcontractors>();
        }

        public void Create(Subcontractors Entity)
        {
            Command cmd = new("InsertSubcontractor", true);
            cmd.MapToCommand(Entity);
            co.ExecuteNonQuery(cmd);
        }

        public bool Delete(int Id)
        {
            using (TransactionScope scope = new())
            {
                try
                {
                    Command cmd = new("Delete from Subcontractors where Id = @Id");
                    cmd.AddParameter("@Id", Id);
                    co.ExecuteNonQuery(cmd);
                    scope.Complete();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            
        }

        public IEnumerable<Subcontractors> GetAll()
        {
            Command cmd = new("select * from Subcontractors");
            return co.ExecuteReader<Subcontractors>(cmd, Convert);
        }

        public Subcontractors GetById(int Id)
        {
            Command cmd = new("select * from Subcontractors where Id = @Id");
            cmd.AddParameter("@Id", Id);
            return co.ExecuteReader<Subcontractors>(cmd, Convert).FirstOrDefault();
        }

        public Subcontractors Update(int Id, Subcontractors Entity)
        {
            using (TransactionScope scope = new())
            {
                try
                {
                    Command cmd = new("Update Subcontractors set Name = @name, Email = @email, Address = @address where Id = @Id");
                    cmd.MapToCommand(Entity);
                    cmd.AddParameter("@Id", Id);
                    co.ExecuteNonQuery(cmd);
                    Subcontractors result = GetById(Id);
                    scope.Complete();
                    return result;
                }
                catch (ArgumentNullException e)
                {

                    throw new ArgumentNullException(e.Message);
                }
                catch (Exception ex)
                {
                    throw new ArgumentOutOfRangeException(ex.Message);
                }

            }

        }
    }
}
