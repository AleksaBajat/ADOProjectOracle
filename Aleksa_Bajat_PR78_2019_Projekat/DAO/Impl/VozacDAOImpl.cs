using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleksa_Bajat_PR78_2019_Projekat.Connection;
using Aleksa_Bajat_PR78_2019_Projekat.DTA.Zadatak4;
using Aleksa_Bajat_PR78_2019_Projekat.Models;
using Aleksa_Bajat_PR78_2019_Projekat.Utility;

namespace Aleksa_Bajat_PR78_2019_Projekat.DAO.Impl
{
    internal class VozacDAOImpl:IVozacDAO
    {
        private readonly RezultatiDAOImpl rezultatiDAO = new RezultatiDAOImpl();

        public int Count() //DONE
        {
            string query = "SELECT COUNT(*) FROM VOZAC";

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    
                        command.CommandText = query;
                        command.Prepare();
                        return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int Delete(Vozac entity)
        {
            try
            {
                rezultatiDAO.DeleteById(entity.IdV);

                return DeleteById(entity.IdV);
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            
        }

        public int DeleteAll()
        {
            rezultatiDAO.DeleteAll();

            string query = "DELETE FROM VOZAC";

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteById(int id)
        {
           
            rezultatiDAO.DeleteById(id);

            
                string query = "DELETE FROM VOZAC WHERE IDV = :idv";

                using (IDbConnection connection = ConnectionPooling.GetConnection())
                {
                    connection.Open();

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        ParameterUtil.AddParameter(command, "idv", DbType.Int32);
                        command.Prepare();
                        ParameterUtil.SetParameterValue(command, "idv", id);
                        return command.ExecuteNonQuery();
                    }
                }
        }

        public bool ExistsById(int id)
        {
            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                return ExistsById(id, connection);
            }
        }

        private bool ExistsById(int id, IDbConnection connection)
        {
            string query = "SELECT * FROM VOZAC WHERE IDV = :idv";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "idv", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "idv", id);
                return command.ExecuteScalar() != null;
            }
        }

        public IEnumerable<Vozac> FindAll()
        {
            string query = "SELECT IDV, IMEV, PREZV,GODRODJ, BROJTIT, DRZV FROM VOZAC";
            List<Vozac> listaVozaca = new List<Vozac>();

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vozac vozac = new Vozac(reader.GetInt32(0), reader.GetString(1),
                                reader.GetString(2), reader.GetInt32(3),reader.GetInt32(4), reader.GetInt32(5));
                            listaVozaca.Add(vozac);
                        }
                    }
                }
            }

            return listaVozaca;
        }

        public IEnumerable<Vozac> FindAllById(IEnumerable<int> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT IDV, IMEV, PREZV,GODRODJ, BROJTIT, DRZV FROM VOZAC WHERE IDV IN (");
            foreach (int id in ids)
            {
                sb.Append(":id" + id + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");

            List<Vozac> listaVozaca = new List<Vozac>();

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (int id in ids)
                    {
                        ParameterUtil.AddParameter(command, "id" + id, DbType.Int32);
                    }
                    command.Prepare();

                    foreach (int id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "id" + id, id);
                    }
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vozac vozac = new Vozac(reader.GetInt32(0), reader.GetString(1),
                                reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4),reader.GetInt32(5));
                            listaVozaca.Add(vozac);
                        }
                    }
                }
            }

            return listaVozaca;
        }

        public Vozac FindById(int id)
        {
            string query = "SELECT IDV, IMEV, PREZV,GODRODJ, BROJTIT, DRZV" +
                           " FROM VOZAC WHERE IDV = :idv";
            Vozac vozac = null;

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idv", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idv", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            vozac = new Vozac(reader.GetInt32(0), reader.GetString(1),
                                reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5));
                        }
                    }
                }
            }

            return vozac;
        }

        public int Save(Vozac entity)
        {
            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        private int Save(Vozac vozac, IDbConnection connection)
        {
            
            string insertSql = "INSERT INTO VOZAC (IMEV, PREZV, GODRODJ, BROJTIT, DRZV, IDV) " +
                               "VALUES (:imev, :prezv, :godrodj , :brojtit, :drzv, :idv)";
            string updateSql = "UPDATE VOZAC SET IMEV=:imev, PREZV=:prezv, GODRODJ = :godrodj, " +
                               "BROJTIT=:brojtit, DRZV=:drzv where IDV=:idv";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(vozac.IdV, connection) ? updateSql : insertSql;
                ParameterUtil.AddParameter(command, "imev", DbType.String, 50);
                ParameterUtil.AddParameter(command, "prezv", DbType.String, 50);
                ParameterUtil.AddParameter(command, "godrodj", DbType.String, 50);
                ParameterUtil.AddParameter(command, "brojtit", DbType.Int32);
                ParameterUtil.AddParameter(command, "drzv", DbType.Int32);
                ParameterUtil.AddParameter(command, "idv", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "idv", vozac.IdV);
                ParameterUtil.SetParameterValue(command, "imev", vozac.ImeV);
                ParameterUtil.SetParameterValue(command, "prezv", vozac.PrezV);
                ParameterUtil.SetParameterValue(command, "godrodj", vozac.Godrodj);
                ParameterUtil.SetParameterValue(command, "brojtit", vozac.BrojTit);
                ParameterUtil.SetParameterValue(command, "drzv", vozac.DrzV);
                return command.ExecuteNonQuery();
            }
        }

        public int SaveAll(IEnumerable<Vozac> entities)
        {
            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction(); 

                int numSaved = 0;

              
                foreach (Vozac entity in entities)
                {
                   
                    numSaved += Save(entity, connection);
                }

               
                transaction.Commit();

                return numSaved;
            }
        }

        public List<VozacOsnovneInformacijeDTA> ListaOsnovnihInformacija()
        {
            string query = "SELECT IDV, IMEV,PREZV, GODRODJ, BROJTIT, NAZIVD FROM VOZAC v LEFT OUTER JOIN DRZAVA d ON v.DRZV = d.IDD";

            List<VozacOsnovneInformacijeDTA> listaOsnovnihInformacija = new List<VozacOsnovneInformacijeDTA>();

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VozacOsnovneInformacijeDTA info = new VozacOsnovneInformacijeDTA(reader.GetInt32(0), reader.GetString(1),
                                reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4),reader.IsDBNull(5) ? "NULL" : reader.GetString(5));

                            listaOsnovnihInformacija.Add(info);
                        }

                        return listaOsnovnihInformacija;
                    }
                }
            }

            
        }
    }
}
