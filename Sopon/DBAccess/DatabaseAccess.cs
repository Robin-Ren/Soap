using Sopon.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Sopon.DBAccess
{
    public class DatabaseAccess
    {
        private SQLiteConnection m_dbConnection;

        public DatabaseAccess()
        {
            try
            {
                //string dbFilePath = new Uri(string.Format("{0}\\DBFile\\SoponDB.db3", Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase))).AbsolutePath.Replace("%20", " ");
                string dbFilePath = ConfigurationManager.AppSettings["what_do_you_want"];
                //bool isExist = File.Exists(path);

                SQLiteConnectionStringBuilder conn_builder = new SQLiteConnectionStringBuilder
                {

                    DateTimeFormat = SQLiteDateFormats.ISO8601,
                    SyncMode = SynchronizationModes.Off,
                    Version = 3,
                    //JournalMode = SQLiteJournalModeEnum.Memory,
                    //DefaultIsolationLevel = System.Data.IsolationLevel.ReadCommitted,
                    Pooling = true,
                    DataSource = dbFilePath//new Uri(string.Format("{0}\\DBFiles\\MIS_v3.sqlite", Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase))).AbsolutePath

                };

                m_dbConnection = new SQLiteConnection(conn_builder.ConnectionString);
                m_dbConnection.Open();
            }
            catch (Exception ex)
            {
                //LogHelper logger = new LogHelper(m_dbConnection);
                //logger.DoErrorLogging(LogType.Error, OperationType.Query, ex);
                string msg = ex.Message;
            }
        }

        public List<OutCome> GetAllOutcomeDetails()
        {
            List<OutCome> retOutcomeDetails = new List<OutCome>();

            try
            {
                string sql = @"SELECT SID,
                            OutcomeName ,
                            OutcomeAmount,
                            OutcomeDescription,
                            GoodsUnitPrice,
                            GoodsCount,
                            DateCreated,
                            DateModified
                            FROM Outcome WHERE IsDeleted != 1";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        OutCome item = new OutCome();
                        item.ID = Convert.ToInt32(row[0]);
                        item.OutcomeName = row[1].ToString();
                        item.Amout = Convert.ToDouble(row[2]);
                        item.OutcomeDesc = row[3].ToString();
                        item.GoodsUnitPrice = Convert.ToDouble(row[4].ToString());
                        item.GoodsCount = Convert.ToInt32(row[5].ToString());
                        item.CreatedDate = row[6].ToString();
                        item.DateModified = row[7].ToString();

                        retOutcomeDetails.Add(item);
                    }
                }


            }
            catch (Exception ex)
            {
                LogHelper logger = new LogHelper(m_dbConnection);
                logger.DoErrorLogging(LogType.Error, OperationType.Query, ex);
            }

            return retOutcomeDetails;
        }

        public List<OutCome> GetOutcomeBySearchConditions(string outcomeName, string outcomeDesc, string fromDate, string toDate)
        {
            List<OutCome> retOutcomeDetails = new List<OutCome>();

            try
            {
                string sql = @"SELECT SID,
                            OutcomeName,
                            OutcomeAmount,
                            OutcomeDescription,
                            GoodsUnitPrice,
                            GoodsCount,
                            DateCreated,
                            DateModified
                            FROM Outcome WHERE IsDeleted != 1";
                string whereClause = string.Empty;
                if(!string.IsNullOrEmpty(outcomeName))
                {
                    whereClause += " AND OutcomeName like \'%" + outcomeName + "%\'";
                }
                if (!string.IsNullOrEmpty(outcomeDesc))
                {
                    whereClause += " AND OutcomeDescription like \'%" + outcomeDesc + "%\'";
                }
                if (!string.IsNullOrEmpty(fromDate))
                {
                    whereClause += " AND DateCreated>=\'" + fromDate + "\'";
                }
                if (!string.IsNullOrEmpty(toDate))
                {
                    whereClause += " AND DateCreated<=\'" + toDate + "\'";
                }

                SQLiteCommand command = new SQLiteCommand(sql + whereClause, m_dbConnection);

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        OutCome item = new OutCome();
                        item.ID = Convert.ToInt32(row[0]);
                        item.OutcomeName = row[1].ToString();
                        item.Amout = Convert.ToDouble(row[2]);
                        item.OutcomeDesc = row[3].ToString();
                        item.GoodsUnitPrice = Convert.ToDouble(row[4].ToString());
                        item.GoodsCount = Convert.ToInt32(row[5].ToString());
                        item.CreatedDate = row[6].ToString();
                        item.DateModified = row[7].ToString();

                        retOutcomeDetails.Add(item);
                    }
                }


            }
            catch (Exception ex)
            {
                LogHelper logger = new LogHelper(m_dbConnection);
                logger.DoErrorLogging(LogType.Error, OperationType.Query, ex);
            }

            return retOutcomeDetails;
        }

        public OutCome GetOutcomeBySID(int id)
        {
            OutCome retOutcomeDetail = new OutCome();

            try
            {
                string sql = @"SELECT SID,
                            OutcomeName ,
                            OutcomeAmount,
                            OutcomeDescription,
                            GoodsUnitPrice,
                            GoodsCount,
                            DateCreated,
                            DateModified
                            FROM Outcome WHERE SID = " + id.ToString();
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        retOutcomeDetail.ID = Convert.ToInt32(row[0]);
                        retOutcomeDetail.OutcomeName = row[1].ToString();
                        retOutcomeDetail.Amout = Convert.ToDouble(row[2]);
                        retOutcomeDetail.OutcomeDesc = row[3].ToString();
                        retOutcomeDetail.GoodsUnitPrice = Convert.ToDouble(row[4].ToString());
                        retOutcomeDetail.GoodsCount = Convert.ToInt32(row[5].ToString());
                        retOutcomeDetail.CreatedDate = row[6].ToString();
                        retOutcomeDetail.DateModified = row[7].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper logger = new LogHelper(m_dbConnection);
                logger.DoErrorLogging(LogType.Error, OperationType.Query, ex);
            }

            return retOutcomeDetail;
        }

        public int AddNewOutcomeRecord(OutCome newRec)
        {
            if (newRec == null)
                return -1;

            try
            {
                string sql = @"INSERT INTO Outcome (
                            OutcomeName ,
                            OutcomeAmount,
                            OutcomeDescription,
                            GoodsUnitPrice,
                            GoodsCount,
                            IsDeleted,
                            DateCreated
                            ) VALUES ('"
                            + newRec.OutcomeName.ToString() + "\',\'"
                            + newRec.Amout + "\',\'"
                            + newRec.OutcomeDesc + "\',\'"
                            + newRec.GoodsUnitPrice + "\',\'"
                            + newRec.GoodsCount + "\',\'"
                            + "0\',\'"
                            + newRec.CreatedDate + "\')";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogHelper logger = new LogHelper(m_dbConnection);
                logger.DoErrorLogging(LogType.Error, OperationType.Query, ex);
                return -1;
            }
        }

        public int UpdateOutcomeRecord(OutCome newRec)
        {
            if (newRec == null)
                return -1;

            try
            {
                string sql = @"UPDATE Outcome 
                            SET OutcomeName ='" + newRec.OutcomeName.ToString() + "\'," +
                            "OutcomeAmount = \'" + newRec.Amout.ToString() + "\'," +
                            "OutcomeDescription= \'" + newRec.OutcomeDesc.ToString() + "\'," +
                            "GoodsUnitPrice= \'" + +newRec.GoodsUnitPrice + "\'," +
                            "GoodsCount= \'" + newRec.GoodsCount + "\'," +
                            "DateModified= \'" + DateTime.Now.ToString("yyyy-MM-dd") + "\'," +
                            "DateCreated= \'" + newRec.CreatedDate + "\' " +
                            "WHERE sid=\'" + newRec.ID + "\'";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogHelper logger = new LogHelper(m_dbConnection);
                logger.DoErrorLogging(LogType.Error, OperationType.Query, ex);
                return -1;
            }
        }

        public int DeleteOutcomeBySID(string id)
        {
            OutCome retOutcomeDetail = new OutCome();

            try
            {
                string sql = @"UPDATE Outcome
                               SET IsDeleted=1,
                                   DateModified='" + DateTime.Now.ToString("yyyy-MM-dd")
                              + "\' WHERE SID = " + id;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogHelper logger = new LogHelper(m_dbConnection);
                logger.DoErrorLogging(LogType.Error, OperationType.Query, ex);
            }

            return -1;
        }

    }
}