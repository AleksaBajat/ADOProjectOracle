using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleksa_Bajat_PR78_2019_Projekat.Connection;
using Aleksa_Bajat_PR78_2019_Projekat.Models;
using Aleksa_Bajat_PR78_2019_Projekat.Utility;

namespace Aleksa_Bajat_PR78_2019_Projekat.DAO.Impl
{
    internal class RezultatiDAOImpl:IRezultatiDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Rezultat entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            string query = "DELETE FROM REZULTAT";

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

        public int DeleteById(string id)
        {
            string query = "DELETE FROM REZULTAT WHERE IDR = :idr";

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();


                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idr", DbType.String,10);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idr", id);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(string id)
        {
            throw new NotImplementedException();
        }

        public int DeleteById(int id)
        {
            string query = "DELETE FROM REZULTAT WHERE IDV = :idv";

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();


                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command,"idv",DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idv", id);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rezultat> FindAll()
        {
            string query = "SELECT IDR,IDV,IDS,SEZONA,PLASMAN,BODOVI,MAKSBRZINA FROM REZULTAT";
            List<Rezultat> rezultati = new List<Rezultat>();

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
                            Rezultat rezultat = new Rezultat(reader.GetString(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3),
                                reader.GetInt32(4),
                                reader.GetInt32(5),
                                reader.GetDouble(6));

                            rezultati.Add(rezultat);
                        }
                    }
                }
            }

            return rezultati;
        }

        public IEnumerable<Rezultat> FindAllById(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public Rezultat FindById(string idr, int idv)
        {
            string query = "SELECT IDR,IDV,IDS,SEZONA,PLASMAN,BODOVI,MAKSBRZINA FROM REZULTAT WHERE IDR = :idr AND IDV = :idv";

            Rezultat rezultat = null;

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idr", DbType.String, 10);
                    ParameterUtil.AddParameter(command,"idv",DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idr", idr);
                    ParameterUtil.SetParameterValue(command, "idv", idv);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rezultat = new Rezultat(reader.GetString(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3),
                                reader.GetInt32(4),
                                reader.GetInt32(5),
                                reader.GetDouble(6));

                        }
                    }
                }
            }

            return rezultat;
        }

        public Rezultat FindById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rezultat> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rezultat> FindAllById(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT IDR,IDV,IDS,SEZONA,PLASMAN,BODOVI,MAKSBRZINA FROM REZULTAT WHERE IDS = :ids ORDER BY PLASMAN ASC");
           

            List<Rezultat> listaRezultata = new List<Rezultat>();

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    ParameterUtil.AddParameter(command, "ids", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "ids", id);
                    
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rezultat rezultat = new Rezultat(reader.GetString(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3),
                                reader.GetInt32(4),
                                reader.GetInt32(5),
                                reader.GetDouble(6));
                            listaRezultata.Add(rezultat);
                        }
                    }
                }
            }

            return listaRezultata;
        }

        public double GetAverage(int id)
        {
            string query = "SELECT AVG(BODOVI) FROM (SELECT * FROM REZULTAT WHERE IDS = :ids)";

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = query;
                        ParameterUtil.AddParameter(command, "ids", DbType.Int32);
                        command.Prepare();
                        ParameterUtil.SetParameterValue(command, "ids", id);


                        return Convert.ToDouble(command.ExecuteScalar());
                    }
                    catch (InvalidCastException e)
                    {
                        Console.WriteLine("Ne postoji dati rezultat!");
                        return 0;
                    }
                }
            }
        }

        public List<Rezultat> FindFirstPlacementById(int id)
        {
            string query = "SELECT IDR,IDV,IDS,SEZONA,PLASMAN,BODOVI,MAKSBRZINA FROM REZULTAT WHERE IDV = :idv AND PLASMAN = 1";

            List<Rezultat> listaRezultata = new List<Rezultat>();

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
                        while (reader.Read())
                        {
                            Rezultat rezultat = new Rezultat(reader.GetString(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3),
                                reader.GetInt32(4),
                                reader.GetInt32(5),
                                reader.GetDouble(6));
                            listaRezultata.Add(rezultat);
                        }
                        
                    }
                }

            }

            return listaRezultata;
        }

        public int NijePrvi(int id)
        {
            string query = "SELECT COUNT(*) FROM REZULTAT WHERE PLASMAN != 1 AND IDV = :idv";

            using (IDbConnection connection = ConnectionPooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command,"idv",DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idv", id);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public Rezultat FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Rezultat entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Rezultat> entities)
        {
            throw new NotImplementedException();
        }
    }
}
